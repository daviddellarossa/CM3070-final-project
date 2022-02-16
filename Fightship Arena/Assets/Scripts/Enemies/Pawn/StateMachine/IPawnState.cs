using System;
using UnityEngine;

namespace FightShipArena.Assets.Scripts.Enemies.Pawn.StateMachine
{
    public interface IPawnState : IEnemyState<IPawnState>
    {
        PawnControllerCore Parent { get; set; }
        StateFactory Factory { get; set; }
    }

    public abstract class PawnState : IPawnState
    {
        public virtual void Move() { }

        public virtual void Rotate() { }

        public virtual void OnEnter()
        {
            Debug.Log($"State {this.GetType().Name}: OnEnter");
        }

        public virtual void OnExit()
        {
            Debug.Log($"State {this.GetType().Name}: OnExit");
        }

        public abstract event Action<IPawnState> ChangeState;
        public PawnControllerCore Parent { get; set; }
        public StateFactory Factory { get; set; }
    }
}