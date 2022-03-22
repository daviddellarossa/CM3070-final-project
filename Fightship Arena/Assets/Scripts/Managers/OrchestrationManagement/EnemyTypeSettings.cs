using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace FightShipArena.Assets.Scripts.Managers.OrchestrationManagement
{
    [Serializable]
    public class EnemyTypeSettings
    {
        public Enemies.EnemyType EnemyTypeEnum;
        public GameObject EnemyType;
        public int NumToSpawn;
        public int MaxNumOfSimultaneousSpawns;
    }
}
