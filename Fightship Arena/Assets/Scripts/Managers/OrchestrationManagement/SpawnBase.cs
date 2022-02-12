using System;
using FightShipArena.Assets.Scripts.Managers.OrchestrationManagement.Conditions;
using UnityEngine;

namespace FightShipArena.Assets.Scripts.Managers.OrchestrationManagement
{
    public abstract class SpawnBase : ScriptableObject
    {
        public abstract event Action<GameObject> EnemySpawned;
        public abstract event Action<GameObject> EnemyKilled;
        public abstract event Action<SpawnBase, OrchestrationState> StateChanged;
        public ConditionBase StartCondition;
        public OrchestrationState State { get; protected set; }
        public abstract void Execute();
        public abstract void CancelExecution();

        protected virtual void ChangeState(OrchestrationState newState)
        {
        }


    }
}