using System.Collections;
using System.Collections.Generic;
using PlasticPipe.PlasticProtocol.Messages;
using UnityEngine;

namespace FightShipArena.Assets.Scripts.Managers.OrchestrationManagement
{
    public class OrchestrationManager : MyMonoBehaviour, IOrchestrationManager
    {
        public List<Wave> Waves = new List<Wave>();
        public int CurrentIndex { get; private set; }
        private Coroutine _runCoroutineInstance;

        public void Run()
        {
            if (Waves == null || Waves.Count == 0)
            {
                Debug.Log("Wave is empty");
                return;
            }


            _runCoroutineInstance = StartCoroutine(RunCoroutine());
        }

        IEnumerator RunCoroutine()
        {
            for (CurrentIndex = 0; CurrentIndex < Waves.Count; ++CurrentIndex)
            {
                var currentWave = Waves[CurrentIndex];

                yield return new WaitUntil(() => currentWave.StartCondition.Verify());

                currentWave.Start();

                yield return new WaitUntil(() => currentWave.State != OrchestrationState.Finished);
            }
        }
    }
}