using System;

namespace TurboCollections
{

    public class TurboStack<T> : ITurboStack<T>
    {
        private TurboList<T> items = new();
        public int Count => items.Count;
        public void Push(T item)
        {
            items.Add(item);
        }
        public T Peek()
        {
            return items.Get(Count - 1);
        }
        public T Pop()
        {
            var result = Peek();
            items.RemoveAt(items.Count - 1);
            return result;
        }
    }
}
