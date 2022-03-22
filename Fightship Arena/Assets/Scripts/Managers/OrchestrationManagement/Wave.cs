using FightShipArena.Assets.Scripts.Enemies;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace FightShipArena.Assets.Scripts.Managers.OrchestrationManagement
{
    [Serializable]
    public class Wave
    {
        public event Action<int> SendScore;

        public EnemyType[] EnemyTypes;
        public GameObject[] SpawnPoints;
        public int MaxSimultaneousEnemiesSpawned;
        public float DelayBetweenSpawns = 1.0f;
        public float DelayBeforeStart = 1.0f;
        public float DelayAfterEnd = 1.0f;
        [HideInInspector]public int CurrentSimultaneousEnemiesSpawned;
        [HideInInspector] public int TotEnemiesSpawned;
        [HideInInspector] public int TotEnemiesToSpawn;
        [HideInInspector] public int TotEnemiesKilled;

        private OrchestrationManager.CancellationToken RunCancellationToken;
        public OrchestrationManager.StatusEnum Status { get; private set; } = OrchestrationManager.StatusEnum.NotStarted;


        public void Run(OrchestrationManager manager)
        {
            RunCancellationToken = new OrchestrationManager.CancellationToken();
            manager.StartCoroutine(CoRun(manager, RunCancellationToken));
        }

        public void Stop()
        {
            RunCancellationToken.Cancel = true;

        }

        public IEnumerator CoRun(OrchestrationManager manager, OrchestrationManager.CancellationToken cancellationToken)
        {
            Status = OrchestrationManager.StatusEnum.Running;
            TotEnemiesToSpawn = EnemyTypes.Sum(x => x.Settings.NumToSpawn);

            yield return new WaitForSeconds(DelayBeforeStart);

            while (TotEnemiesSpawned < TotEnemiesToSpawn)
            {
                yield return new WaitForSeconds(DelayBetweenSpawns);

                yield return new WaitUntil(() => CurrentSimultaneousEnemiesSpawned < MaxSimultaneousEnemiesSpawned);

                var nextEnemy = EnemyTypes.Where(x=>x.CurrentlySpawned < x.Settings.MaxNumOfSimultaneousSpawns).OrderBy(x => x.TotalSpawned / (float)x.Settings.NumToSpawn).SingleOrDefault();

                if (nextEnemy == null)
                    continue;

                var spawnPoint = SpawnPoints[UnityEngine.Random.Range(0, SpawnPoints.Length)];

                var nextEnemySpawn = GameObject.Instantiate(nextEnemy.Settings.EnemyType, spawnPoint.transform.position, Quaternion.identity);
                UnityEngine.SceneManagement.SceneManager.MoveGameObjectToScene(nextEnemySpawn, UnityEngine.SceneManagement.SceneManager.GetSceneAt(1));

                var nextEnemyManager = nextEnemySpawn.GetComponent<IEnemyController>();
                nextEnemyManager.Core.HasDied += Enemy_HasDied;

                nextEnemy.TotalSpawned++;
                nextEnemy.CurrentlySpawned++;
                TotEnemiesSpawned++;
            }

            yield return new WaitForSeconds(DelayAfterEnd);

            yield return new WaitUntil(() => TotEnemiesKilled == TotEnemiesToSpawn);

            Status = OrchestrationManager.StatusEnum.Done;
        }

        private void Enemy_HasDied(IEnemyControllerCore enemyControllerCore)
        {
            SendScore?.Invoke(enemyControllerCore.InitSettings.PlayerScoreWhenKilled);

            enemyControllerCore.HasDied -= Enemy_HasDied;
            var enemyType = EnemyTypes.Single(x => x.Settings.EnemyTypeEnum == enemyControllerCore.Parent.InitSettings.EnemyType);
            enemyType.CurrentlySpawned--;
            TotEnemiesKilled++;
        }
    }
}
