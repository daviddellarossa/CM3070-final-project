using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FightShipArena.Assets.Scripts.Enemies;
using UnityEngine;

namespace FightShipArena.Assets.Scripts.Managers.OrchestrationManagement
{
    [CreateAssetMenu(fileName = "New Spawn", menuName = "Orchestration/Spawn")]

    public class Spawn : SpawnBase
    {
        public EnemyType EnemyType;
        public float DelayTime;
        public GameObject SpawnPoint;
        public override void Execute()
        {
            //TODO: Spawn Enemy of EnemyType at SpawnPoint
            throw new NotImplementedException();
        }
    }
}
