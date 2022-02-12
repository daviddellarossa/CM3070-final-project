using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace FightShipArena.Assets.Scripts.Managers.OrchestrationManagement
{
    [CreateAssetMenu(fileName = "New SpawnGroup", menuName = "Orchestration/SpawnGroup")]

    public class SpawnGroup : SpawnBase
    {
        public int CurrentIndex { get; private set; }

        public List<SpawnBase> Spawns = new List<SpawnBase>();

        void OnEnable()
        {
            this.State = OrchestrationState.NotStarted;
        }

        public override event Action<GameObject> EnemySpawned;
        public override event Action<GameObject> EnemyKilled;
        public override event Action<SpawnBase, OrchestrationState> StateChanged;

        public override void Execute()
        {
            this.State = OrchestrationState.Running;

            StartCoroutine(RunCoroutine());
        }

        public override void CancelExecution()
        {
            ChangeState(OrchestrationState.Cancelled);
        }

        private void StartCoroutine(IEnumerator task)
        {
            if (!Application.isPlaying)
            {
                Debug.LogError("Can not run coroutine outside of play mode.");
                return;
            }

            var coworker = new GameObject("CoWorker_" + task.ToString()).AddComponent<CoroutineWorker>();
            coworker.Work(task);
        }

        IEnumerator RunCoroutine()
        {
            for (CurrentIndex = 0; CurrentIndex < Spawns.Count; ++CurrentIndex)
            {
                var currentWave = Spawns[CurrentIndex];

                yield return new WaitUntil(() => currentWave.StartCondition.Verify());

                currentWave.EnemyKilled += EnemyKilledEventHandler;
                currentWave.EnemySpawned += EnemySpawnedEventHandler;
                currentWave.StateChanged += StateChangedEventHandler;

                currentWave.Execute();

                if (State == OrchestrationState.Cancelled)
                {
                    yield break;
                }
            }

            yield return new WaitUntil(() => Spawns.TrueForAll(x => x.State == OrchestrationState.Finished));

            this.State = OrchestrationState.Finished;
        }

        private void StateChangedEventHandler(SpawnBase sender, OrchestrationState newState)
        {
            switch (newState)
            {
                case OrchestrationState.Finished:
                    sender.EnemyKilled -= EnemyKilledEventHandler;
                    sender.EnemySpawned -= EnemySpawnedEventHandler;
                    sender.StateChanged -= StateChangedEventHandler;
                    break;
            }
        }

        private void EnemySpawnedEventHandler(GameObject obj)
        {
            EnemySpawned?.Invoke(obj);
        }

        private void EnemyKilledEventHandler(GameObject obj)
        {
            EnemyKilled?.Invoke(obj);
        }
    }
}
