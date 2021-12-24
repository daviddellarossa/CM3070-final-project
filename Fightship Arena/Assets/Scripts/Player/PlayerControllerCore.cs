﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FightShipArena.Assets.Scripts.Enemies;
using FightShipArena.Assets.Scripts.Managers.HealthManagement;
using FightShipArena.Assets.Scripts.Weapons;
using UnityEngine;

namespace FightShipArena.Assets.Scripts.Player
{
    public class PlayerControllerCore : IPlayerControllerCore
    {
        public event Action<int> ScoreMultiplierCollected;

        public IPlayerController Parent { get; protected set; }
        public Transform Transform { get; protected set; }
        public Rigidbody2D RigidBody { get; protected set; }
        public PlayerSettings InitSettings { get; set; }
        public IHealthManager HealthManager { get; }
        public WeaponBase[] Weapons { get; }
        public Vector2 PlayerInput { get; set; }
        public WeaponBase CurrentWeapon { get; set; }

        public PlayerControllerCore(IPlayerController parent)
        {
            Parent = parent;
            Transform = parent.GameObject.transform;
            RigidBody = parent.GameObject.GetComponent<Rigidbody2D>();
            HealthManager = parent.HealthManager;
            HealthManager.HasDied += HealthManager_HasDied;
            HealthManager.HealthLevelChanged += HealthManager_HealthLevelChanged;
            InitSettings = parent.InitSettings;
            Weapons = parent.Weapons.Select(x=>x.GetComponent<WeaponBase>()).ToArray();
            CurrentWeapon = Weapons[0];
        }

        private void HealthManager_HealthLevelChanged(int obj) { }

        private void HealthManager_HasDied()
        {

        }

        public void SetPlayerInput(Vector2 playerInput)
        {
            PlayerInput = playerInput;
        }

        public void Move()
        {
            RigidBody.AddForce(PlayerInput * InitSettings.ForceMultiplier, ForceMode2D.Impulse);
            var speed = RigidBody.velocity.magnitude;

            //Limit speed
            if (speed > InitSettings.MaxSpeed)
            {
                RigidBody.velocity = RigidBody.velocity.normalized * InitSettings.MaxSpeed;
            }

            //Stop fightship when input is zero
            if (PlayerInput == Vector2.zero && speed != 0)
            {
                RigidBody.velocity *= InitSettings.Deceleration;
            }
        }

        public void StartFiring()
        {
            CurrentWeapon.StartFiring();
        }

        public void StopFiring()
        {
            CurrentWeapon.StopFiring();
        }

        public void FireAlt()
        {

        }

        public void OpenSelectionMenu()
        {

        }

        public void HandleCollisionWithEnemy(IEnemyControllerCore enemyController)
        {
            var damage = enemyController.InitSettings.DamageAppliedOnCollision;
            HealthManager.Damage(damage);
        }

        public void AddMultiplier(int multiplier)
        {
            ScoreMultiplierCollected?.Invoke(multiplier);
        }

        public void HandleCollisionWithPowerUp(PowerUps.PowerUpBase powerUp)
        {

        }
    }
}
