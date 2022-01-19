﻿using System;

namespace TurboCollections
{
    public static class CollectionUtil
    {
        public static void EnsureSize<T>(ref T[] items, int size)
        {
            //if the array is large enough, return
            if (items.Length >= size)
                return;

            //double the array size, or set it to given size if doubling is not enough
            int newSize = Math.Max(size, items.Length * 2);
            
            //create new array 
            T[] newArray = new T[newSize];
            for (int i = 0; i < items.Length; i++)
            {//copy old items
                newArray[i] = items[i];
            }
            //assign new array
            items = newArray;
        }
    }
}
