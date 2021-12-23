using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Scripting;

namespace FightShipArena.Assets.Scripts.Enemies
{
    [Serializable]
    public class EnemyPowerUp
    {
        [RequiredMember]
        public GameObject PowerUp;
        [Range(0, 1)]
        public float ReleaseRate;
    }
}
