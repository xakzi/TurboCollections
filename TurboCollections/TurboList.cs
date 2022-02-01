using System;
using System.Collections;
using System.Collections.Generic;

namespace TurboCollections
{
    public class TurboList<T> : IEnumerable<T>
    {
        public int Count { get; private set; }
        private T[] items = Array.Empty<T>();

        public TurboList()
        {
            
        }
        
        public TurboList(int capacity)
        {
            items = new T[capacity];
        }
        
        public void Add(T item)
        {
            CollectionUtil.EnsureSize(ref items, Count + 1);
            items[Count++] = item;
        }

        public T Get(int index)
        {
            return items[index];
        }

        public void Set(int index, T item)
        {
            items[index] = item;
        }

        public void Swap(int indexA, int indexB)
        {
            (items[indexB], items[indexA]) = (items[indexA], items[indexB]);
        }

        public void Clear()
        {
            for (int i = 0; i < Count; i++)
            {
                items[i] = default;
            }
            Count = 0;
        }

        public void RemoveAt(int index)
        {
            Array.Copy(items, index + 1, items, index, Count - index - 1);
            Count--;
        }

        public bool Contains(T item)
        {
            return IndexOf(item) != -1;
        }
        
        public int IndexOf(T item)
        {
            for (int i = 0; i < Count; i++)
            {
                if (Equals(item, items[i]))
                    return i;
            }
            return -1;
        }

        public void Remove(T item)
        {
            var index = IndexOf(item);
            if (index == -1)
                return;
            RemoveAt(index);
        }

        public void AddRange(IEnumerable<T> items)
        {
            foreach (var item in items)
            {
                Add(item);
            }
        }

        public Enumerator GetEnumerator()
        {
            return new Enumerator(items, Count);
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            return GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        
        public struct Enumerator : IEnumerator<T>
        {
            private readonly T[] _items;
            private readonly int _count;
            private int _index;

            public Enumerator(T[] items, int count)
            {
                _items = items;
                _count = count;
                _index = -1;
            }
            public bool MoveNext()
            {
                if (_index >= _count)
                    return false; // exception
                return ++_index < _count;
            }

            public void Reset()
            {
                _index = -1;
            }

            public T Current => _items[_index];

            object IEnumerator.Current => Current;

            public void Dispose()
            {
                Reset();
            }
        }
    }
}