using System;
using System.Collections.Generic;

namespace TurboCollections
{
    public class TurboList<T>
    {
        public int Count { get; private set; }
        private T[] items = Array.Empty<T>();
        public void Add(T item)
        {
            EnsureSize(Count + 1);
            items[Count++] = item;
        }
        /// <summary>
        /// This method ensures that the array is at least 'size' big
        /// </summary>
        /// <param name="size">The size that your array should have</param>
        void EnsureSize(int size)
        {
            //if the array is large enough, return
            if (items.Length >= size)
                return;

            //double the array size, or set it to given size if doubling is not enough
            int newSize = Math.Max(size, items.Length * 2);
            
            //create new array 
            T[] newArray = new T[newSize];
            for (int i = 0; i < Count; i++)
            {//copy old items
                newArray[i] = items[i];
            }
            //assign new array
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
        public void Set(int index, T item)
        {
            if (index >= Count)
            {
                EnsureSize(index+1);
                Count = index + 1;
            }
            items[index] = item;
        }
    }
}
