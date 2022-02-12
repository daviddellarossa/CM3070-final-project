using System;
using System.Collections;
using System.Collections.Generic;
using FightShipArena.Assets.Scripts.Enemies;
using PlasticPipe.PlasticProtocol.Messages;
using UnityEngine;

namespace FightShipArena.Assets.Scripts.Managers.OrchestrationManagement
{
    public class OrchestrationManager : MyMonoBehaviour, IOrchestrationManager
    {
        public SpawnGroup Spawns;
        public event Action<int> SendScore;
        public event Action OrchestrationComplete;
        public List<IEnemyControllerCore> Enemies { get; set; }

        void Awake()
        {
            Enemies = new List<IEnemyControllerCore>();
        }

        public void Run()
        {
            if (Spawns == null)
            {
                Debug.Log("Spawns is empty");
                return;
            }

            StartCoroutine(RunCoroutine());
        }

        public void Stop()
        {
            Spawns.CancelExecution();
        }

        IEnumerator RunCoroutine()
        {
            Spawns.EnemyKilled += EnemyKilledEventHandler;
            Spawns.EnemySpawned += EnemySpawnedEventHandler;
            Spawns.StateChanged += StateChangedEventHandler;

            Spawns.Execute();

            yield return new WaitUntil(() => Spawns.State == OrchestrationState.Finished);

            Spawns.EnemyKilled -= EnemyKilledEventHandler;
            Spawns.EnemySpawned -= EnemySpawnedEventHandler;

            OrchestrationComplete?.Invoke();
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
            var enemyCore = obj.GetComponent<EnemyController>().Core;
            Enemies.Add(enemyCore);
        }

        private void EnemyKilledEventHandler(GameObject obj)
        {
            var enemyCore = obj.GetComponent<EnemyController>().Core;

            SendScore?.Invoke(enemyCore.InitSettings.PlayerScoreWhenKilled);

            Debug.Assert(Enemies.Contains(enemyCore), $"Enemy {enemyCore.Parent.GameObject.name} not found in EnemyManager's Enemies collection");

            Enemies.Remove(enemyCore);
        }
    }
}