using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Codice.Client.BaseCommands.Import;
using FightShipArena.Assets.Scripts.Enemies;
using FightShipArena.Assets.Scripts.Managers.EnemyManagement;
using UnityEngine;

namespace FightShipArena.Assets.Scripts.Managers.OrchestrationManagement
{
    [CreateAssetMenu(fileName = "New Spawn", menuName = "Orchestration/Spawn")]

    public class Spawn : SpawnBase
    {
        
        public GameObject EnemyPrefab;
        public float DelayTime;
        public GameObject SpawnPoint;
        private GameObject _enemyInstance;
        private IEnemyControllerCore _core;

        void OnEnable()
        {
            this.State = OrchestrationState.NotStarted;
        }

        public override event Action<GameObject> EnemySpawned;
        public override event Action<GameObject> EnemyKilled;
        public override event Action<SpawnBase, OrchestrationState> StateChanged;

        protected void ChangeState(OrchestrationState newState)
        {
            this.State = newState;

            StateChanged?.Invoke(this, newState);
        }

        public override void Execute()
        {
            ChangeState(OrchestrationState.Running);

            _enemyInstance = Instantiate(EnemyPrefab, SpawnPoint.transform.position, Quaternion.identity);

            _core = _enemyInstance.GetComponent<EnemyController>().Core;
            _core.HasDied += HasDiedEventHandler;

            EnemySpawned?.Invoke(_enemyInstance);

        }

        public override void CancelExecution()
        {
        }

        private void HasDiedEventHandler(IEnemyControllerCore obj)
        {

            EnemyKilled?.Invoke(obj.Parent.GameObject);

            ChangeState(OrchestrationState.Finished);

            _core.HasDied -= HasDiedEventHandler;
        }
    }
}
