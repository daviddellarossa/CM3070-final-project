using FightShipArena.Assets.Scripts.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FightShipArena.Assets.Scripts.Managers.HealthManagement;
using UnityEngine;

namespace FightShipArena.Assets.Scripts.Enemies
{
    public class PawnController : EnemyController
    {
        public IEnemyControllerCore Core { get; protected set; }

        public IHealthManager HealthManager { get; protected set; }

        void Awake()
        {
            HealthManager = new HealthManager(InitSettings.InitHealth, InitSettings.InitHealth, false);
            HealthManager.HasDied += HealthManager_HasDied;
            Core = new PawnControllerCore(this, HealthManager, InitSettings);
        }

        private void HealthManager_HasDied()
        {
            GameObject.Destroy(this.gameObject);
        }

        void Start()
        {
            var player = GameObject.FindGameObjectWithTag("Player");

            if (player == null)
            {
                throw new NullReferenceException("Player");
            }

            Core.PlayerControllerCore = player.GetComponent<PlayerController>().Core;

            if (InitSettings == null)
            {
                throw new NullReferenceException("InitSettings");
            }
        }

        void OnCollisionEnter2D(Collision2D col)
        {
            Debug.Log($"Collision detected with {col.gameObject.name}");
            if (col.gameObject.tag == "Player")
            {
                Core.CollisionWithPlayer();
            }
        }

        private void FixedUpdate()
        {
            Core.FixedUpdate();
        }
    }
}
