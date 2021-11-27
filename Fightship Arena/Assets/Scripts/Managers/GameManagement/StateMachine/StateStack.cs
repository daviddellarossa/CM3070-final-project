using System;
using System.Collections.Generic;
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

    public class TestableStack<T> : IStack<T>
    {
        protected Stack<T> _stack = new Stack<T>();

        public int Count { get; }
        public void Clear() => _stack.Clear();

        public bool Contains(T item) => _stack.Contains(item);

        public T Peek() => _stack.Peek();

        public T Pop() => _stack.Pop();

        public void Push(T item) => _stack.Push(item);

        public T[] ToArray() => _stack.ToArray();
    }


    public interface IStack<T>
    {
        int Count { get; }
        void Clear();
        bool Contains(T item);
        T Peek();
        T Pop();
        void Push(T item);
        T[] ToArray();
    }
}
