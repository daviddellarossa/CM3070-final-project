using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FightShipArena.Assets.Scripts.Managers.GameManagement.StateMachine
{
    public class StateStack
    {
        public event EventHandler<State> PoppingStateEvent;
        public event EventHandler<State> PushingStateEvent;

        private Stack<State> _stack = new Stack<State>();

        public State Peek() => _stack.Peek();

        public State Pop()
        {
            var state = _stack.Pop(); //throws InvalidOperationException if stack is empty
            state.OnDeactivate();
            state.OnExit();

            PoppingStateEvent?.Invoke(this, state);

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

            PushingStateEvent?.Invoke(this, state);
            
            state.OnEnter();
            state.OnActivate();
        }

        public void Clear()
        {
            while (_stack.Count > 0)
            {
                var state = Pop();
            }
        }
        public bool Contains(State state) => _stack.Contains(state);
    }
}
