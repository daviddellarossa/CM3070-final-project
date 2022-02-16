﻿using System;
using System.Collections;
using UnityEngine;

namespace FightShipArena.Assets.Scripts.Enemies.Infantry.StateMachine
{
    public class AttackState : IInfantryState
    {
        private Coroutine _fireCoroutine;
        private Coroutine _seekPlayerCoroutine;
        private bool fireCondition = false;
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
            fireCondition = true;
            _seekPlayerCoroutine = Parent.Parent.StartCoroutine(SeekPlayer());
            _fireCoroutine = Parent.Parent.StartCoroutine(Fire());
        }

        public void OnExit()
        {
            Debug.Log($"State {this.GetType().Name}: OnExit");
            fireCondition = false;
            Parent.Parent.StopCoroutine(_seekPlayerCoroutine);
            Parent.Parent.StopCoroutine(_fireCoroutine);
            Parent.CurrentWeapon.StopFiring();

        }

        protected void LookAtPlayer()
        {
            if (Parent.PlayerControllerCore.Transform == null )
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

        public IEnumerator Fire()
        {
            var stopFiringInterval = 1.0f;
            var firingInterval = 1.0f;

            while (fireCondition)
            {
                var startFiringAt = Time.fixedTime;
                Parent.CurrentWeapon.StartFiring();
                yield return new WaitWhile(() => startFiringAt + firingInterval > Time.fixedTime);

                var stopFiringAt = Time.fixedTime;
                Parent.CurrentWeapon.StopFiring();
                yield return new WaitWhile(() => stopFiringAt + stopFiringInterval > Time.fixedTime);

            }
        }

        public IEnumerator SeekPlayer()
        {
            while (true)
            {
                yield return new WaitUntil(() => Parent.PlayerControllerCore.HealthManager.IsDead);
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
