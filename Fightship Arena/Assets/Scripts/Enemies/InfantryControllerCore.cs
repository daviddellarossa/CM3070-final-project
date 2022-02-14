using FightShipArena.Assets.Scripts.Managers.HealthManagement;
using FightShipArena.Assets.Scripts.Player;
using FightShipArena.Assets.Scripts.Weapons;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Random = UnityEngine.Random;

namespace FightShipArena.Assets.Scripts.Enemies
{
    public class InfantryControllerCore : IEnemyControllerCore
    {
        public IPlayerControllerCore PlayerControllerCore { get; set; }
        public IEnemyController Parent { get; protected set; }
        public Transform Transform { get; protected set; }
        public Rigidbody2D Rigidbody { get; protected set; }
        public EnemySettings InitSettings { get; protected set; }
        public IHealthManager HealthManager { get; }
        public WeaponBase[] Weapons { get; }
        public WeaponBase CurrentWeapon { get; set; }

        public EnemyState State { get; set; }


        public event Action<IEnemyControllerCore> HasDied;

        public InfantryControllerCore(IEnemyController parent, IHealthManager healthManager, EnemySettings settings)
        {
            //State = EnemyState.Idle;
            Parent = parent;
            Transform = parent.GameObject.transform;
            Rigidbody = parent.GameObject.GetComponent<Rigidbody2D>();
            HealthManager = healthManager;
            HealthManager.HasDied += HealthManager_HasDied;
            HealthManager.HealthLevelChanged += HealthManager_HealthLevelChanged;
            InitSettings = settings;
            Weapons = parent.Weapons.Select(x => x.GetComponent<WeaponBase>()).ToArray();
            CurrentWeapon = Weapons[0];

            var mb = parent.StartCoroutine(Attack());
        }

        private void HealthManager_HealthLevelChanged(int obj) { }

        private void HealthManager_HasDied()
        {
            State = EnemyState.Dead;
            HasDied?.Invoke(this);
        }

        public void HandleCollisionWithPlayer()
        {
            HealthManager.Kill();
        }

        public void Move()
        {
            var mag = Random.value * InitSettings.MaxMovementMagnitude;
            var impulse = Random.insideUnitCircle * mag;

            Rigidbody.AddForce(impulse);
        }

        public void LookAtPlayer()
        {
            float rotationSpeed = 0.1f;

            //Improve the aim of the enemy implementing this suggestion
            //https://stackoverflow.com/questions/3211374/2d-game-algorithm-to-calculate-a-bullets-needed-speed-to-hit-target

            var playerDirection = (PlayerControllerCore.Transform.position - Transform.position);

            float angle = (Mathf.Atan2(playerDirection.y, playerDirection.x) * Mathf.Rad2Deg) - 90;
            var rotation = Quaternion.Euler(0, 0, angle);

            Transform.rotation = Quaternion.Slerp(Transform.rotation, rotation, rotationSpeed);

            State = EnemyState.Attack;
        }

        public IEnumerator Attack()
        {
            var stopFiringInterval = 1.0f;
            var firingInterval = 1.0f;

            while (State != EnemyState.Dead)
            {
                var startFiringAt = Time.fixedTime;
                CurrentWeapon.StartFiring();
                yield return new WaitWhile(() => startFiringAt + firingInterval > Time.fixedTime);

                var stopFiringAt = Time.fixedTime;
                CurrentWeapon.StopFiring();
                yield return new WaitWhile(() => stopFiringAt + stopFiringInterval > Time.fixedTime);

            }
        }
    }

    public enum EnemyState
    {
        Idle,
        Attack,
        Dead
    }
}
