using System;
using System.Collections;
using UnityEngine;

namespace FightShipArena.Assets.Scripts.Enemies.Infantry.StateMachine
{
    public class AttackState : IInfantryState
    {
        public void Move()
        {
            var mag = UnityEngine.Random.value * Parent.InitSettings.MaxMovementMagnitude;
            var impulse = UnityEngine.Random.insideUnitCircle * mag;

            Parent.Rigidbody.AddForce(impulse);
        }

        public void Rotate()
        {
            LookAtPlayer();
        }

        public void OnEnter()
        {
            Debug.Log($"State {this.GetType().Name}: OnEnter");
            Parent.Parent.StartCoroutine(SeekPlayer());
            Parent.Parent.StartCoroutine(Fire());
        }

        public void OnExit()
        {
            Debug.Log($"State {this.GetType().Name}: OnExit");
            Parent.Parent.StopCoroutine(SeekPlayer());
            Parent.Parent.StopCoroutine(Fire());

        }

        protected void LookAtPlayer()
        {
            if (Parent.PlayerControllerCore.Transform == null)
            {
                return;
            }

            float rotationSpeed = 0.1f;

            //Improve the aim of the enemy implementing this suggestion
            //https://stackoverflow.com/questions/3211374/2d-game-algorithm-to-calculate-a-bullets-needed-speed-to-hit-target

            var playerDirection = (Parent.PlayerControllerCore.Transform.position - Parent.Transform.position);

            float angle = (Mathf.Atan2(playerDirection.y, playerDirection.x) * Mathf.Rad2Deg) - 90;
            var rotation = Quaternion.Euler(0, 0, angle);

            Parent.Transform.rotation = Quaternion.Slerp(Parent.Transform.rotation, rotation, rotationSpeed);

        }

        protected IEnumerator Fire()
        {
            var stopFiringInterval = 1.0f;
            var firingInterval = 1.0f;

            while (true)
            {
                var startFiringAt = Time.fixedTime;
                Parent.CurrentWeapon.StartFiring();
                yield return new WaitWhile(() => startFiringAt + firingInterval > Time.fixedTime);

                var stopFiringAt = Time.fixedTime;
                Parent.CurrentWeapon.StopFiring();
                yield return new WaitWhile(() => stopFiringAt + stopFiringInterval > Time.fixedTime);

            }
        }

        private IEnumerator SeekPlayer()
        {
            while (true)
            {
                yield return new WaitUntil(() => Parent.PlayerControllerCore == null);
                //Player found
                ChangeState?.Invoke(Factory.IdleState);
                yield return new WaitForSeconds(1);
            }
        }


        public event Action<IInfantryState> ChangeState;
        public InfantryControllerCore Parent { get; set; }
        public StateFactory Factory { get; set; }

        public AttackState(InfantryControllerCore parent, StateFactory factory)
        {
            Parent = parent;
            Factory = factory;
        }
    }
}
