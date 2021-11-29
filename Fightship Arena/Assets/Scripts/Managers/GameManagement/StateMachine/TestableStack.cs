using System.Collections.Generic;

namespace FightShipArena.Assets.Scripts.Managers.GameManagement.StateMachine
{
    /// <summary>
    /// Bridge pattern is applied here to decouple the code from the actual implementation of the Stack class.
    /// This is to improve testability in dependent classes.
    /// This class, on the contrary, is not testable as the Stack class is not mockable.
    /// </summary>
    /// <typeparam name="T"></typeparam>
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