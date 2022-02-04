using System;
using System.Collections;


namespace TurboCollections
{
    public class TurboQueue<T>
    {
        private int _indexNumber;
        private T[] _items = new T[2];
        public int Count { get; private set; }

        public void Enqueue(T item)
        {
            if (Count == _items.Length)
                Resize();
            _items[Count] = item;
            Count++;
        }
        
        public T Peek()
        {
            foreach (var item in _items)
                for (int i = _indexNumber; i < Count + _indexNumber; i++)
                    _items[i - _indexNumber] = _items[i];
            return _items[_indexNumber];
        }

        void Resize()
        {
            var result = new T[_items.Length * 2];
            for (int i = 0; i < Count; i++)
                result[i] = _items[i];
            _items = result;
        }


        public T Dequeue()
        {
            T item = _items[_indexNumber];
            _items[_indexNumber] = default(T);
            _indexNumber++;
            return item;
        }

        public void Clear()
        {
            _indexNumber = 0;
            Count = 0;
            _items = Array.Empty<T>();
        }
    }
}
