using System;
using System.Collections;
using ICSharpCode.NRefactory.Ast;
using UnityEngine;

namespace FightShipArena.Assets.Scripts.Enemies.Infantry.StateMachine
{
    public class IdleState : IInfantryState
    {
        public event Action<IInfantryState> ChangeState;

        public void Move()
        {
            var mag = UnityEngine.Random.value * Parent.InitSettings.MaxMovementMagnitude;
            var impulse = UnityEngine.Random.insideUnitCircle * mag;

            Parent.Rigidbody.AddForce(impulse);
        }

        public void Rotate() { }

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
                yield return new WaitWhile(() => Parent.PlayerControllerCore == null);
                //Player found
                ChangeState?.Invoke(Factory.AttackState);
                yield return new WaitForFixedUpdate();
            }
        }

        public InfantryControllerCore Parent { get; set; }
        public StateFactory Factory { get; set; }

        public IdleState(InfantryControllerCore parent, StateFactory factory)
        {
            Parent = parent;
            Factory = factory;
        }
    }
}
