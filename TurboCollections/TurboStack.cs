namespace TurboCollections
{
    public class TurboStack<T> : ITurboStack<T>
    {
        private T[] items = System.Array.Empty<T>();
        public int Count { get; private set; }

        public void Push(T item)
        {
            CollectionUtil.EnsureSize(ref items, Count+1);
            items[Count++] = item;
        }

        public T Peek()
        {
            return items[Count - 1];
        }
        
        public T Pop()
        {
            var result = items[--Count];
            items[Count] = default;
            return result;
        }
    }
}