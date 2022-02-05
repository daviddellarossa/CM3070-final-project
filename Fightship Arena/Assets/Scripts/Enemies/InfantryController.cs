using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FightShipArena.Assets.Scripts.Managers.HealthManagement;
using FightShipArena.Assets.Scripts.Player;
using UnityEngine;

namespace FightShipArena.Assets.Scripts.Enemies
{
    public class InfantryController : EnemyController
    {
        private void HealthManager_HealthLevelChanged(int obj)
        {
        }
        private void HealthManager_HasDied()
        {
            Debug.Log($"Destroying object {this.gameObject.name}");
            GameObject.Destroy(this.gameObject);
            ReleasePowerUp();
        }
        void Awake()
        {
            HealthManager = new HealthManager(InitSettings.InitHealth, InitSettings.InitHealth, false);
            HealthManager.HasDied += HealthManager_HasDied;
            HealthManager.HealthLevelChanged += HealthManager_HealthLevelChanged;
            Core = new InfantryControllerCore(this, HealthManager, InitSettings);
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
            //if (col.gameObject.tag == "Player")
            //{
            //    Core.HandleCollisionWithPlayer();
            //}

            switch (col.gameObject.tag)
            {
                case "Player":
                {
                    Core.HandleCollisionWithPlayer();
                    break;
                }
                case "Bullet":
                {
                    //The collision is managed by the bullet
                    break;
                }
            }
        }
        private void FixedUpdate()
        {
            Core.LookAtPlayer();
            Core.Move();
        }

    }
}
