using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FightShipArena.Assets.Scripts.Enemies;
using FightShipArena.Assets.Scripts.Managers.HealthManagement;
using UnityEngine;

namespace FightShipArena.Assets.Scripts.Player
{
    public class PlayerControllerCore : IPlayerControllerCore
    {
        public IMyMonoBehaviour Parent { get; protected set; }
        public Transform Transform { get; protected set; }
        //public Rigidbody2D Rigidbody { get; protected set; }
        public PlayerSettings InitSettings { get; set; }
        public IHealthManager HealthManager { get; }
        public Vector3 Movement { get; set; }

        public PlayerControllerCore(IMyMonoBehaviour parent, IHealthManager healthManager, PlayerSettings settings)
        {
            Parent = parent;
            Transform = parent.GameObject.transform;
            //Rigidbody = parent.GameObject.GetComponent<Rigidbody2D>();
            HealthManager = healthManager;
            HealthManager.HasDied += HealthManager_HasDied;
            HealthManager.HealthLevelChanged += HealthManager_HealthLevelChanged;
            InitSettings = settings;
        }

        private void HealthManager_HealthLevelChanged(int obj) { }
        private void HealthManager_HasDied() { }

        public void Move()
        {
            Transform.position += Movement;
        }

        public void Fire()
        {
           
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
