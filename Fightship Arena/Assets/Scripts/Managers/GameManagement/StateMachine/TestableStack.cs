using System.Collections.Generic;

namespace FightShipArena.Assets.Scripts.Managers.GameManagement.StateMachine
{
    public class TestableStack<T> : IStack<T>
    {
        protected Stack<T> _stack = new Stack<T>();

        public int Count => _stack.Count;
        public void Clear() => _stack.Clear();

        public bool Contains(T item) => _stack.Contains(item);

        public T Peek() => _stack.Peek();

        public T Pop() => _stack.Pop();

        public void Push(T item) => _stack.Push(item);

        public T[] ToArray() => _stack.ToArray();
    }
}