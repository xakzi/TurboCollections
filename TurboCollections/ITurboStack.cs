namespace TurboCollections
{
    public interface ITurboStack<T>
    {
        int Count { get; }
        void Push(T item);
        T Peek();
        T Pop();
    }
}