﻿using System;
using FightShipArena.Assets.Scripts.Managers.HealthManagement;
using FightShipArena.Assets.Scripts.Player;
using FightShipArena.Assets.Scripts.Weapons;
using UnityEngine;

namespace FightShipArena.Assets.Scripts.Enemies.Infantry
{
    public class InfantryController : EnemyController
    {
        private void HealthManager_HealthLevelChanged(int value, int maxValue)
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

            CheckWeaponsConfiguration();

            Core = new InfantryControllerCore(this, HealthManager, InitSettings);

        }
        void Start()
        {
            var player = GameObject.FindGameObjectWithTag("Player");

            if (player == null)
            {
                Debug.LogWarning("Player not found");
                return;
            }

            Core.PlayerControllerCore = player.GetComponent<PlayerController>().Core;

            if (InitSettings == null)
            {
                throw new NullReferenceException("InitSettings");
            }

            Core.OnStart();
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
            Core?.Move();
        }

        private void CheckWeaponsConfiguration()
        {
            Weapons = this.GameObject.GetComponentsInChildren<WeaponBase>();
            foreach (var weapon in Weapons)
            {
                //If the current weapon has no configuration, throw.
                if (weapon.InitSettings == null)
                {
                    throw new Exception($"No settings for weapon {weapon.WeaponType}");
                }
            }
        }

    }
}
