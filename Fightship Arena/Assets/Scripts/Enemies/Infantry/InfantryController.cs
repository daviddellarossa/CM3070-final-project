using System;
using FightShipArena.Assets.Scripts.Managers.HealthManagement;
using FightShipArena.Assets.Scripts.Managers.Levels;
using FightShipArena.Assets.Scripts.Player;
using FightShipArena.Assets.Scripts.Weapons;
using UnityEngine;

namespace FightShipArena.Assets.Scripts.Enemies.Infantry
{
    /// <summary>
    /// Specialization of a EnemyController for an Infantry enemy type
    /// </summary>
    public class InfantryController : EnemyController
    {
        /// <summary>
        /// Event handler for a HealthLevelChanged event from the HealthManager
        /// </summary>
        /// <param name="value">New health level</param>
        /// <param name="maxValue">Max value of health</param>
        private void HealthManager_HealthLevelChanged(int value, int maxValue)
        {
        }
        /// <summary>
        /// Event handler for a HasDied event from the HealthManager
        /// </summary>
        private void HealthManager_HasDied()
        {
            Debug.Log($"Destroying object {this.gameObject.name}");
            
            _SoundManager.PlayExplodeSound();

            var eeInstance = Instantiate(this.ExplosionEffect, this.gameObject.transform);
            eeInstance.transform.SetParent(null);

            Destroy(eeInstance, 4);

            GameObject.Destroy(this.gameObject);
            ReleasePowerUp();
        }
        
        /// <summary>
        /// Invoked on Awake
        /// </summary>
        void Awake()
        {
            HealthManager = new HealthManager(InitSettings.InitHealth, InitSettings.InitHealth, false);
            HealthManager.HasDied += HealthManager_HasDied;
            HealthManager.HealthLevelChanged += HealthManager_HealthLevelChanged;

            CheckWeaponsConfiguration();

            Core = new InfantryControllerCore(this, HealthManager, InitSettings);

        }
        
        /// <summary>
        /// Invoked on Start
        /// </summary>
        /// <exception cref="NullReferenceException"></exception>
        void Start()
        {
            var sceneManagerGO = GameObject.FindGameObjectWithTag("SceneManager");
            var sceneManager = sceneManagerGO?.GetComponent<LevelManager>();

            if(sceneManager == null)
            {
                Debug.LogError("SceneManager not found");
            }

            _SoundManager = gameObject.GetComponent<EnemySoundManager>();

            if(_SoundManager == null)
            {
                Debug.LogError("SoundManager not found");
            }

            _SoundManager.SceneManager = sceneManager;


            if (InitSettings == null)
            {
                throw new NullReferenceException("InitSettings");
            }

            var player = GameObject.FindGameObjectWithTag("Player");

            if (player == null)
            {
                Debug.Log("Player object not found");
            }
            else
            {
                Core.PlayerControllerCore = player.GetComponent<PlayerController>().Core;
            }

            Core.OnStart();
        }

        void OnCollisionEnter2D(Collision2D col)
        {
            Debug.Log($"Collision detected with {col.gameObject.name}");

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
                    _SoundManager.PlayHitSound();

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
