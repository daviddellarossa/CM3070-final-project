using FightShipArena.Assets.Scripts.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace FightShipArena.Assets.Scripts.Enemies
{
    public class PawnController : MyMonoBehaviour
    {
        public IEnemyControllerCore Core { get; set; }
        
        public EnemyType EnemyType;

        void Awake()
        {
            Core = new PawnControllerCore(this);
        }

        void Start()
        {
            var player = GameObject.FindGameObjectWithTag("Player");
            Core.PlayerControllerCore = player.GetComponent<PlayerController>().Core;
            Core.EnemyType = EnemyType;
        }

        private void FixedUpdate()
        {
            Core.FixedUpdate();
        }
    }
}
