using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FightShipArena.Assets.Scripts.Managers.OrchestrationManagement.Conditions;
using UnityEngine;

namespace FightShipArena.Assets.Scripts.Managers.OrchestrationManagement
{
    [CreateAssetMenu(fileName = "New Wave", menuName = "Orchestration/Wave")]

    public class Wave : ScriptableObject
    {
        public List<SpawnBase> Spawns = new List<SpawnBase>();
        public ConditionBase StartCondition;
        private int _currentIndex;
        public OrchestrationState State { get; private set; } = OrchestrationState.NotStarted;

        public void Start()
        {
            if (State != OrchestrationState.NotStarted)
            {
                Debug.Log("Wave already started");
                return;
            }

            State = OrchestrationState.Running;

            throw new NotImplementedException();
        }
    }
}
