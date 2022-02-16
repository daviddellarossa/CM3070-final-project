using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace FightShipArena.Assets.Scripts.Enemies.Pawn.StateMachine
{
    public class SeekState : PawnState
    {
        public override void Move()
        {
            var mag = UnityEngine.Random.value * Parent.InitSettings.MaxMovementMagnitude;
            var impulse = UnityEngine.Random.insideUnitCircle * mag;

            Parent.Rigidbody.AddForce(impulse);
        }

        public override void OnEnter()
        {
            base.OnEnter();
            Parent.Parent.StartCoroutine(SeekPlayer());
        }

        public override void OnExit()
        {
            base.OnExit();
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


        public SeekState(PawnControllerCore parent, StateFactory factory)
        {
            Parent = parent;
            Factory = factory;
        }

        public override event Action<IPawnState> ChangeState;
    }
}
