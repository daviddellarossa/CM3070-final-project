using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace FightShipArena.Assets.Scripts.Managers.OrchestrationManagement2
{
    [Serializable]
    public class EnemyType
    {
        public EnemyTypeSettings Settings;
        [HideInInspector] public int TotalSpawned { get; set; }
        [HideInInspector] public int CurrentlySpawned { get; set; }
    }
}
