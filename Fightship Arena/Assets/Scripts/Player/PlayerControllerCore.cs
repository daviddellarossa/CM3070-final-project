using System;
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
        public IPlayerController Parent { get; protected set; }
        public Transform Transform { get; protected set; }
        //public Rigidbody2D Rigidbody { get; protected set; }
        public PlayerSettings InitSettings { get; set; }
        public IHealthManager HealthManager { get; }
        public WeaponBase[] Weapons { get; }
        public Vector3 Movement { get; set; }
        public bool IsFiring { get; set; }
        public WeaponBase CurrentWeapon { get; set; }

        public PlayerControllerCore(IPlayerController parent/*, IHealthManager healthManager, PlayerSettings settings*/)
        {
            Parent = parent;
            Transform = parent.GameObject.transform;
            //Rigidbody = parent.GameObject.GetComponent<Rigidbody2D>();
            HealthManager = parent.HealthManager;
            HealthManager.HasDied += HealthManager_HasDied;
            HealthManager.HealthLevelChanged += HealthManager_HealthLevelChanged;
            InitSettings = parent.InitSettings;
            Weapons = parent.Weapons.Select(x=>x.GetComponent<WeaponBase>()).ToArray();
            CurrentWeapon = Weapons[0];
        }

        private void HealthManager_HealthLevelChanged(int obj) { }
        private void HealthManager_HasDied() { }

        public void SetMovement(Vector2 movement)
        {
            Movement = new Vector3(movement.x, movement.y);
        }

        public void Move()
        {
            Transform.position += Movement;
        }

        public void Fire()
        {
            //CurrentWeapon.Fire();
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
    }
}
