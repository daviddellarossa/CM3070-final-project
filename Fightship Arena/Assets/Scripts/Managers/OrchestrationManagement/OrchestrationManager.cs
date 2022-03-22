using FightShipArena.Assets.Scripts.Managers.OrchestrationManagement;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace FightShipArena.Assets.Scripts.Managers.OrchestrationManagement
{
    public class OrchestrationManager : MyMonoBehaviour, IOrchestrationManager
    {
        public Wave[] Waves;
        private CancellationToken RunCancellationToken;

        public event Action<int> SendScore;
        public event Action OrchestrationComplete;

        public float DelayBetweenWaves = 1.0f;
        public float DelayBeforeStart = 1.0f;
        public float DelayAfterEnd = 1.0f;


        public StatusEnum Status { get; private set; } = StatusEnum.NotStarted;

        public void Run()
        {
            RunCancellationToken = new CancellationToken();
            StartCoroutine(CoRun(RunCancellationToken));
        }

        public void Stop()
        {
            RunCancellationToken.Cancel = true; ;
        }

        public IEnumerator CoRun(CancellationToken cancellationToken)
        {
            Status = StatusEnum.Running;

            yield return new WaitForSeconds(DelayBeforeStart);
            foreach(var wave in Waves)
            {
                wave.SendScore += Wave_SendScore;
                wave.Run(this);

                yield return new WaitUntil(() => wave.Status == StatusEnum.Done);

                yield return new WaitForSeconds(DelayBetweenWaves);
            }

            yield return new WaitForSeconds(DelayAfterEnd);

            Status = StatusEnum.Done;
            OrchestrationComplete?.Invoke();
        }

        private void Wave_SendScore(int obj)
        {
            this.SendScore?.Invoke(obj);
        }

        public class CancellationToken
        {
            public bool Cancel = false;
        }

        public enum StatusEnum
        {
            NotStarted,
            Running,
            Done
        }
    }
}
