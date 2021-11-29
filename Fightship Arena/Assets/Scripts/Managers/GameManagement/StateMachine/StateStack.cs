using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FightShipArena.Assets.Scripts.Managers.GameManagement.StateMachine
{
    public class StateStack
    {
        public virtual event EventHandler<State> PoppingStateEvent;
        public virtual event EventHandler<State> PushingStateEvent;

        protected IStack<State> _stack = new TestableStack<State>();

        public virtual State Peek() => _stack.Peek();

        public virtual State Pop()
        {
            var state = _stack.Pop(); //throws InvalidOperationException if stack is empty
            state.OnDeactivate();
            state.OnExit();

            RaisePoppingStateEvent(state);

            if (_stack.Count > 0)
            {
                _stack.Peek().OnActivate();
            }

            return state;
        }

        public virtual void Push(State state)
        {
            if (_stack.Count > 0)
            {
                _stack.Peek().OnDeactivate();
            }

            _stack.Push(state);

            RaisePushingStateEvent(state);

            state.OnEnter();
            state.OnActivate();
        }

        public virtual void Clear()
        {
            while (_stack.Count > 0)
            {
                var state = Pop();
            }
        }

        protected void RaisePoppingStateEvent(State state) => PoppingStateEvent?.Invoke(this, state);
        protected void RaisePushingStateEvent(State state) => PushingStateEvent?.Invoke(this, state);
    }
}
