using System;
using System.Collections;
using System.Collections.Generic;

namespace TurboCollections
{
    public class TurboList<T> : IEnumerable<T>
    {
        public int Count { get; private set; }
        private T[] items = Array.Empty<T>();
        public void Add(T item)
        {
            CollectionUtil.EnsureSize(ref items, Count + 1);
            items[Count++] = item;
        }
        
        public T Get(int index)
        {
            return items[index];
        }
        
        public void Clear()
        {
            //items = Array.Empty<T>();
            
            //mark edit
            for (int i = 0; i < Count; i++)
            {
                items[i] = default;
            }
            Count = 0;
        }
        public void RemoveAt(int index)
        {
           /* T[] newArray = new T[Count - 1];
            for (int i = 0; i < Count; i++)
            {
                if (i == index)
                {
                    break;
                }
                newArray[i] = items[i];
            }
            items = newArray;*/
           
           //Marks Edits

           for (int i = index; i < Count-1; i++)
           {
               items[i] = items[i + 1];
           }
           Count--;
        }
        public bool Contains(T item)
        {
            /*
            foreach (var elements in items)
            {
                if (elements.Equals(item))
                    return true;
            }

            return false;*/
            
            //Marks edits
            //return items.Any(_item => item.Equals(_item));
            
            /*for (int i = 0; i < Count; i++)
            {
                if (item.Equals(items[i]))
                    return true;
            }
            return false;*/

            return IndexOf(item) != -1;
        }
        public int IndexOf(T item)
        {
            /*var temp = 0;
            foreach (var elements in items)
            {
                if (elements.Equals(item))
                    return temp;
                else
                {
                    temp++;
                }
            }
            return -1;*/
            
            //marks edits
            for (int i = 0; i < Count; i++)
            {

                if (Equals(item, items[i])) ;
                    return i;
            }
            return -1;
            
        }
        public void Remove(T item)
        {
            /*var temp = 0;
            foreach (var elements in items)
            {
                if (elements.Equals(item))
                {
                    T[] newArray = new T[Count - 1];
                    for (int i = 0; i < Count; i++)
                    {
                        if (i == temp)
                        {
                            break;
                        }
                        newArray[i] = items[i];
                    }
                    items = newArray;
                }
                else
                {
                    temp++;
                }
            }*/
            
            //marks edit
            var index = IndexOf(item);
            if (index == -1)
                return;
            RemoveAt(index);
        }
        public void AddRange(IEnumerable<T> items)
        {
            /*using var enumerator = items.GetEnumerator();
            while (enumerator.MoveNext()) Add(enumerator.Current);*/
            
            //marks edits
            foreach (var item in items)
            {
                Add(item);
            }
        }
        public void Set(int index, T item)
        {
            items[index] = item;
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
                    return false;
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
