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
    public class PawnControllerCore : IEnemyControllerCore
    {
        public event Action<IEnemyControllerCore> HasDied;

        public IPlayerControllerCore PlayerControllerCore { get; set; }
        public IEnemyController Parent { get; protected set; }
        public Transform Transform { get; protected set; }
        public Rigidbody2D Rigidbody { get; protected set; }
        public EnemySettings InitSettings { get; protected set; }
        public IHealthManager HealthManager { get; }

        public PawnControllerCore(IEnemyController parent, IHealthManager healthManager, EnemySettings settings)
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

        public void Move()
        {
            if(PlayerControllerCore == null || PlayerControllerCore.Transform == null) return;

            var distance = PlayerControllerCore.Transform.position - this.Transform.position;

            var direction = (distance).normalized;

            //add impulse - Impulse increases (clamped) with the distance from the player
            var forceMagnitude = UnityEngine.Mathf.Clamp(distance.magnitude, InitSettings.MinAttractiveForceMagnitude, InitSettings.MaxAttractiveForceMagnitude);
            var force = direction * forceMagnitude;
            Rigidbody.AddForce(force, ForceMode2D.Impulse);

            //force movement - This effect increases when the distance lowers
            var movementMagnitude = UnityEngine.Mathf.Clamp(0.1f / distance.magnitude, InitSettings.MinMovementMagnitude, InitSettings.MaxMovementMagnitude);
            var movement = direction * movementMagnitude;
            Rigidbody.position += new Vector2(movement.x, movement.y);

            //Clamp maximum velocity
            Rigidbody.velocity = Vector2.ClampMagnitude(Rigidbody.velocity, InitSettings.MaxSpeed);
        }

        public void LookAtPlayer() { }

        public void HandleCollisionWithPlayer()
        {
            HealthManager.Kill();
        }

    }
}
