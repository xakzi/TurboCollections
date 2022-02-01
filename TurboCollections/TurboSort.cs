using System;

namespace TurboCollections
{
    public static class TurboSort
    {
        public static void BubbleSort(TurboList<int> list)
        {
            BubbleSort<int>(list);
        }

        public static void BubbleSort<T>(TurboList<T> list) where T : IComparable<T>
        {
            bool swapped;
            int endIndex = list.Count - 1;
            do
            {
                swapped = false;

                for (int i = 0; i < endIndex; i++)
                {
                    if (list.Get(i).CompareTo(list.Get(i + 1)) > 0)
                    {
                        list.Swap(i, i+1);
                        swapped = true;
                    }
                }

                endIndex--;
            } while (swapped);
        }

        public static void QuickSort(TurboList<int> list, int left = 0, int? right = null)
        {
            int _right = right ?? list.Count-1;
            if(_right-left <= 0)
                return;

            int pivot = list.Get(_right);
            int partition = Partition(list, left, _right, pivot);
            QuickSort(list, left, partition-1);
            QuickSort(list, partition+1, _right);
            
            int Partition(TurboList<int> list, int left, int right, int pivot)
            {
                int leftPointer = left;
                int rightPointer = right - 1;

                while (true)
                {
                    while (list.Get(leftPointer) < pivot)
                    {
                        leftPointer++;
                    }

                    while (rightPointer > 0 && list.Get(rightPointer) > pivot)
                    {
                        rightPointer--;
                    }

                    if (leftPointer >= rightPointer)
                        break;

                    list.Swap(leftPointer, rightPointer);
                }
                
                list.Swap(leftPointer, right);
                return leftPointer;
            }
        }
    }
}