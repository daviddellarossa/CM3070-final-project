using FightShipArena.Assets.Scripts.Enemies;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace FightShipArena.Assets.Scripts.Managers.OrchestrationManagement2
{
    [Serializable]
    public class Wave
    {
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

        private OrchestrationManager2.CancellationToken RunCancellationToken;
        public OrchestrationManager2.StatusEnum Status { get; private set; } = OrchestrationManager2.StatusEnum.NotStarted;


        public void Run(OrchestrationManager2 manager)
        {
            RunCancellationToken = new OrchestrationManager2.CancellationToken();
            manager.StartCoroutine(CoRun(manager, RunCancellationToken));
        }

        public void Stop()
        {
            RunCancellationToken.Cancel = true;

        }

        public IEnumerator CoRun(OrchestrationManager2 manager, OrchestrationManager2.CancellationToken cancellationToken)
        {
            Status = OrchestrationManager2.StatusEnum.Running;
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

            Status = OrchestrationManager2.StatusEnum.Done;
        }

        private void Enemy_HasDied(IEnemyControllerCore enemyControllerCore)
        {
            enemyControllerCore.HasDied -= Enemy_HasDied;
            var enemyType = EnemyTypes.Single(x => x.Settings.EnemyTypeEnum == enemyControllerCore.Parent.InitSettings.EnemyType);
            enemyType.CurrentlySpawned--;
            TotEnemiesKilled++;
        }
    }
}
