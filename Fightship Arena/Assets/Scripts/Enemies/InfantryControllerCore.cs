using FightShipArena.Assets.Scripts.Managers.HealthManagement;
using FightShipArena.Assets.Scripts.Player;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace FightShipArena.Assets.Scripts.Enemies
{
    public class InfantryControllerCore : IEnemyControllerCore
    {
        public IPlayerControllerCore PlayerControllerCore { get; set; }
        public IMyMonoBehaviour Parent { get; protected set; }
        public Transform Transform { get; protected set; }
        public Rigidbody2D Rigidbody { get; protected set; }
        public EnemySettings InitSettings { get; protected set; }
        public IHealthManager HealthManager { get; }

        public event Action<IEnemyControllerCore> HasDied;

        public InfantryControllerCore(IMyMonoBehaviour parent, IHealthManager healthManager, EnemySettings settings)
        {
            Parent = parent;
            Transform = parent.GameObject.transform;
            Rigidbody = parent.GameObject.GetComponent<Rigidbody2D>();
            HealthManager = healthManager;
            HealthManager.HasDied += HealthManager_HasDied;
            HealthManager.HealthLevelChanged += HealthManager_HealthLevelChanged;
            InitSettings = settings;
        }

        private void HealthManager_HealthLevelChanged(int obj) { }

        private void HealthManager_HasDied()
        {
            HasDied?.Invoke(this);
        }

        public void HandleCollisionWithPlayer()
        {
            HealthManager.Kill();
        }

        public void Move()
        {
        }

        public void LookAtPlayer()
        {
            float rotationSpeed = 0.1f;

            var playerPosition = PlayerControllerCore.Transform.position;
            var playerDirection = (playerPosition - Transform.position).normalized;
            //var rotation = Quaternion.FromToRotation(Transform.up, playerDirection);

            var rotation = Quaternion.LookRotation(Transform.up, playerDirection);
            Transform.rotation = Quaternion.Slerp(Transform.rotation, rotation, rotationSpeed);

        }

        //private IEnumerator DoRotate(Quaternion quaternion)
        //{
        //    float tolerance = 0.95f;
        //    float rotationSpeed = 0.1f;

        //    while (Mathf.Abs(Quaternion.Dot(Transform.rotation, quaternion)) < tolerance)
        //    {
        //        Transform.rotation = Quaternion.Slerp(Transform.rotation, quaternion, rotationSpeed);
        //        yield return null;
        //    }

        //    Transform.rotation = quaternion;
        //}

    }
}
