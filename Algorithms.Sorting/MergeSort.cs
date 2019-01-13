using System;

namespace Algorithms.Sorting
{
    public class MergeSort<T>
           where T : IComparable<T>
    {
        public void Sort(T[] arrayToSort)
        {
            SortRecursively(arrayToSort);
        }

        private void SortRecursively(T[] arrayToSort)
        {
            if (arrayToSort == null)
            {
                throw new NullReferenceException();
            }

            if (arrayToSort.Length == 1)
            {
                return;
            }

            var midPoint = arrayToSort.Length / 2;
            T[] leftArray = new T[midPoint];
            T[] rightArray = new T[arrayToSort.Length - midPoint];
            Array.Copy(arrayToSort, 0, leftArray, 0, midPoint);
            Array.Copy(arrayToSort, midPoint, rightArray, 0, rightArray.Length);
            SortRecursively(leftArray);
            SortRecursively(rightArray);

            Merge(leftArray, rightArray, arrayToSort);
        }

        private void Merge(T[] leftArray, T[] rightArray, T[] arrayToSort)
        {
            var i = 0;
            int j = 0;
            int k = 0;

            while (i != leftArray.Length && j != rightArray.Length)
            {
                if (i < leftArray.Length && leftArray[i].CompareTo(rightArray[j]) <= 0)
                {
                    arrayToSort[k++] = leftArray[i++];
                }
                else if (j < rightArray.Length && leftArray[i].CompareTo(rightArray[j]) > 0)
                {
                    arrayToSort[k++] = rightArray[j++];
                }

                if (i == leftArray.Length)
                {
                    while (j < rightArray.Length)
                    {
                        arrayToSort[k++] = rightArray[j++];
                    }
                }
                else if (j == rightArray.Length)
                {
                    while (i < leftArray.Length)
                    {
                        arrayToSort[k++] = leftArray[i++];
                    }
                }
            }
        }
    }
}
