using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FightShipArena.Assets.Scripts.Managers.GameManagement.StateMachine
{
    public class StateStack
    {
        private Stack<State> _stack = new Stack<State>();

        public State Peek() => _stack.Peek();

        public State Pop()
        {
            var state = _stack.Pop(); //throws InvalidOperationException if stack is empty
            state.OnDeactivate();
            state.OnExit();

            if (_stack.Count > 0)
            {
                _stack.Peek().OnActivate();
            }

            return state;
        }

        public void Push(State state)
        {
            if (_stack.Count > 0)
            {
                _stack.Peek().OnDeactivate();
            }

            _stack.Push(state);
            
            state.OnEnter();
            state.OnActivate();
        }

        public bool Contains(State state) => _stack.Contains(state);
    }
}
