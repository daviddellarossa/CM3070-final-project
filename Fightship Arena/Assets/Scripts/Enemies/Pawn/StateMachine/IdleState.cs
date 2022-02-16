using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace FightShipArena.Assets.Scripts.Enemies.Pawn.StateMachine
{
    public class IdleState : IPawnState
    {
        public void Move()
        {
            var mag = UnityEngine.Random.value * Parent.InitSettings.MaxMovementMagnitude;
            var impulse = UnityEngine.Random.insideUnitCircle * mag;

            Parent.Rigidbody.AddForce(impulse);
        }

        public void Rotate()
        {
        }

        public void OnEnter()
        {
            Debug.Log($"State {this.GetType().Name}: OnEnter");
            Parent.Parent.StartCoroutine(SeekPlayer());
        }

        public void OnExit()
        {
            Debug.Log($"State {this.GetType().Name}: OnExit");
            Parent.Parent.StopCoroutine(SeekPlayer());
        }

        private IEnumerator SeekPlayer()
        {
            while (true)
            {
                yield return new WaitWhile(() => Parent.PlayerControllerCore.HealthManager.IsDead);
                //Player found
                ChangeState?.Invoke(Factory.AttackState);
                yield return new WaitForFixedUpdate();
            }
        }


        public IdleState(PawnControllerCore parent, StateFactory factory)
        {
            Parent = parent;
            Factory = factory;
        }

        public event Action<IPawnState> ChangeState;
        public PawnControllerCore Parent { get; set; }
        public StateFactory Factory { get; set; }
    }
}
