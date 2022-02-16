using System;
using UnityEngine;

namespace FightShipArena.Assets.Scripts.Enemies.Infantry.StateMachine
{
    public abstract class InfantryState : IInfantryState{
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

        public abstract event Action<IInfantryState> ChangeState;
        public InfantryControllerCore Parent { get; set; }
        public StateFactory Factory { get; set; }
    }
}