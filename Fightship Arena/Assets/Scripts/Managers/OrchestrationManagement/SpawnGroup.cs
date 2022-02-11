using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace FightShipArena.Assets.Scripts.Managers.OrchestrationManagement
{
    [CreateAssetMenu(fileName = "New SpawnGroup", menuName = "Orchestration/SpawnGroup")]

    public class SpawnGroup : SpawnBase
    {
        public List<SpawnBase> Spawns = new List<SpawnBase>();
        public override void Execute()
        {
            foreach (var spawn in Spawns)
            {
                spawn.Execute();
            }
        }
    }
}
