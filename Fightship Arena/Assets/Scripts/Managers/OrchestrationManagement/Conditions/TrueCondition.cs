﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace FightShipArena.Assets.Scripts.Managers.OrchestrationManagement.Conditions
{
    [CreateAssetMenu(fileName = "TrueCondition", menuName = "Orchestration/True Condition")]

    public class TrueCondition : ConditionBase
    {
        public override bool Verify()
        {
            return true;
        }
    }
}
