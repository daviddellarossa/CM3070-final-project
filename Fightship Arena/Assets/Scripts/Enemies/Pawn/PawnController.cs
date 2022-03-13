using System;
using FightShipArena.Assets.Scripts.Managers.HealthManagement;
using FightShipArena.Assets.Scripts.Managers.Levels;
using FightShipArena.Assets.Scripts.Player;
using UnityEngine;

namespace FightShipArena.Assets.Scripts.Enemies.Pawn
{
    public class PawnController : EnemyController
    {

        private void HealthManager_HealthLevelChanged(int value, int maxValue)
        {
        }

        private void HealthManager_HasDied()
        {
            Debug.Log($"Destroying object {this.gameObject.name}");

            _SoundManager.PlayExplodeSound();

            var eeInstance = Instantiate(this.ExplosionEffect, this.gameObject.transform);
            eeInstance.transform.SetParent(null);

            GameObject.Destroy(this.gameObject);
            ReleasePowerUp();
        }

        void Awake()
        {
            HealthManager = new HealthManager(InitSettings.InitHealth, InitSettings.InitHealth, false);
            HealthManager.HasDied += HealthManager_HasDied;
            HealthManager.HealthLevelChanged += HealthManager_HealthLevelChanged;
            Core = new PawnControllerCore(this, HealthManager, InitSettings);
        }

        void Start()
        {
            var player = GameObject.FindGameObjectWithTag("Player");

            if (player == null)
            {
                throw new NullReferenceException("Player");
            }

            var sceneManagerGO = GameObject.FindGameObjectWithTag("SceneManager");
            var sceneManager = sceneManagerGO?.GetComponent<LevelManager>();

            if (sceneManager == null)
            {
                Debug.LogError("SceneManager not found");
            }

            _SoundManager = gameObject.GetComponent<EnemySoundManager>();

            if (_SoundManager == null)
            {
                Debug.LogError("SoundManager not found");
            }

            _SoundManager.SceneManager = sceneManager;


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
            //if (Time.frameCount % InitSettings.UpdateEveryXFrames != 0)
            //    return;

            Core.Move();
        }
    }
}
