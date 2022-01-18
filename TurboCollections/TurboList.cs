using System;
using System.Collections.Generic;

namespace TurboCollections
{
    public class TurboList<T>
    {
        public int Count => items.Length;
        private T[] items = Array.Empty<T>();
        public TurboList()
        {
            Console.WriteLine("Hello, Turbo!");
        }
        public void Add(T item)
        {
            //Resize Array, new Array, get counts, put new array to our "List"
            T[] newArray = new T[Count + 1];
            for (int i = 0; i < Count; i++)
            {
                newArray[i] = items[i];
            }

            newArray[Count] = item;
            items = newArray;
        }
        public T Get(int index)
        {
            return items[index];
        }
        public void Clear()
        {
            items = Array.Empty<T>();
        }
        public void RemoveAt(int index)
        {
            T[] newArray = new T[Count - 1];
            for (int i = 0; i < Count; i++)
            {
                if (i == index)
                {
                    break;
                }
                newArray[i] = items[i];
            }
            items = newArray;
        }
        public bool Contains(T item)
        {
            foreach (var elements in items)
            {
                if (elements.Equals(item))
                    return true;
            }

            return false;
        }
        public int IndexOf(T item)
        {
            var temp = 0;
            foreach (var elements in items)
            {
                if (elements.Equals(item))
                    return temp;
                else
                {
                    temp++;
                }
            }
            return -1;
        }
        public void Remove(T item)
        {
            var temp = 0;
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
            }
        }
        public void AddRange(IEnumerable<T> items)
        {
            using var enumerator = items.GetEnumerator();
            while (enumerator.MoveNext()) Add(enumerator.Current);
        }
    }
}
