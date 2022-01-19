using System;

namespace TurboCollections
{

    public class TurboStack<T> : ITurboStack<T>
    {
        
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
            items[Count] = default;
            return result;
        }
    }
}
