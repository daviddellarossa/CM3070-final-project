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
        
        public EnemySettings EnemySettings;

        void Awake()
        {
            Core = new PawnControllerCore(this);
        }

        void Start()
        {
            var player = GameObject.FindGameObjectWithTag("Player");

            if (player == null)
            {
                throw new NullReferenceException("Player");
            }

            Core.PlayerControllerCore = player.GetComponent<PlayerController>().Core;

            if (EnemySettings == null)
            {
                throw new NullReferenceException("EnemySettings");
            }
            Core.Start(EnemySettings);
        }

        void OnCollisionEnter2D(Collision2D col)
        {
            Debug.Log($"Collision detected with {col.gameObject.name}");
            Destroy(gameObject);
        }

        private void FixedUpdate()
        {
            Core.FixedUpdate();
        }
    }
}
