using System;
using UnityEngine;

namespace FightShipArena.Assets.Scripts.Managers.OrchestrationManagement
{
    public abstract class SpawnBase : ScriptableObject
    {
        public abstract void Execute();
    }
}