using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace FightShipArena.Assets.Scripts.Managers.OrchestrationManagement.Conditions
{
    [CreateAssetMenu(fileName = "DelayFromPreviousStart", menuName = "Orchestration/Delay from previous start condition")]
    public class DelaySecsFromPreviousStartCondition : ConditionBase
    {
        public float Delay;
        public override bool Verify()
        {
            throw new NotImplementedException();
        }
    }
}
