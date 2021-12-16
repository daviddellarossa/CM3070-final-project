using FightShipArena.Assets.Scripts.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace FightShipArena.Assets.Scripts.Enemies
{
    public class PawnControllerCore : IEnemyControllerCore
    {
        public IPlayerControllerCore PlayerControllerCore { get; set; }
        public IMyMonoBehaviour Parent { get; protected set; }
        public Transform Transform { get; protected set; }
        public Rigidbody2D Rigidbody { get; protected set; }
        public EnemySettings EnemySettings { get; protected set; }

        public PawnControllerCore(IMyMonoBehaviour parent)
        {
            Parent = parent;
            Transform = parent.GameObject.transform;
            Rigidbody = parent.GameObject.GetComponent<Rigidbody2D>();
         }

        public int Health { get; set; }

        public void Start(EnemySettings settings)
        {
            EnemySettings = settings;
        }

        public void FixedUpdate()
        {
            if(PlayerControllerCore == null) return;

            var distance = PlayerControllerCore.Transform.position - this.Transform.position;

            var direction = (distance).normalized;

            //add impulse - Impulse increases (clamped) with the distance from the player
            var forceMagnitude = UnityEngine.Mathf.Clamp(distance.magnitude, EnemySettings.MinAttractiveForceMagnitude, EnemySettings.MaxAttractiveForceMagnitude);
            var force = direction * forceMagnitude;
            Rigidbody.AddForce(force, ForceMode2D.Impulse);

            //force movement - This effect increases when the distance lowers
            var movementMagnitude = UnityEngine.Mathf.Clamp(0.1f / distance.magnitude, EnemySettings.MinMovementMagnitude, EnemySettings.MaxMovementMagnitude);
            var movement = direction * movementMagnitude;
            Rigidbody.position += new Vector2(movement.x, movement.y);

            //Clamp maximum velocity
            Rigidbody.velocity = Vector2.ClampMagnitude(Rigidbody.velocity, EnemySettings.MaxSpeed);

        }

    }
}
