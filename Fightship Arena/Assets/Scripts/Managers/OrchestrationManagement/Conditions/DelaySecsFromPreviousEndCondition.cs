using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace FightShipArena.Assets.Scripts.Managers.OrchestrationManagement.Conditions
{
    [CreateAssetMenu(fileName = "DelayFromPreviousEnd", menuName = "Orchestration/Delay from previous end condition")]
    public class DelaySecsFromPreviousEndCondition : ConditionBase
    {
        public float Delay;
        public override bool Verify()
        {
            throw new NotImplementedException();
        }
    }
}
