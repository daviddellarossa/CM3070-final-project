using UnityEngine;

namespace FightShipArena.Assets.Scripts.Managers.OrchestrationManagement.Conditions
{
    public abstract class ConditionBase : ScriptableObject
    {
        public abstract bool Verify(float prevStart, float prevEnd);
    }
}