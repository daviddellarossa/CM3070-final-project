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

        private float _lastStart;
        private float _lastEnd;


        void OnEnable()
        {
            this.State = OrchestrationState.NotStarted;
        }

        public override event Action<GameObject> EnemySpawned;
        public override event Action<GameObject> EnemyKilled;
        public override event Action<SpawnBase, OrchestrationState> StateChanged;

        public override void Execute()
        {
            ChangeState(OrchestrationState.Running);

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
            _lastStart = Time.fixedTime;
            _lastEnd = float.PositiveInfinity;

            for (CurrentIndex = 0; CurrentIndex < Spawns.Count; ++CurrentIndex)
            {
                var currentWave = Spawns[CurrentIndex];

                yield return new WaitUntil(() => currentWave.StartCondition.Verify(_lastStart, _lastEnd));

                currentWave.EnemyKilled += EnemyKilledEventHandler;
                currentWave.EnemySpawned += EnemySpawnedEventHandler;
                currentWave.StateChanged += StateChangedEventHandler;

                currentWave.Execute();

                if (State == OrchestrationState.Cancelled)
                {
                    yield break;
                }

                //yield return new WaitForEndOfFrame();
            }

            yield return new WaitUntil(() => Spawns.TrueForAll(x => x.State == OrchestrationState.Finished));

            this.State = OrchestrationState.Finished;
        }

        private void StateChangedEventHandler(SpawnBase sender, OrchestrationState newState)
        {
            switch (newState)
            {
                case OrchestrationState.Running:
                    _lastStart = Time.fixedTime;
                    break;
                case OrchestrationState.Finished:
                    sender.EnemyKilled -= EnemyKilledEventHandler;
                    sender.EnemySpawned -= EnemySpawnedEventHandler;
                    sender.StateChanged -= StateChangedEventHandler;

                    _lastEnd = Time.fixedTime;
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
