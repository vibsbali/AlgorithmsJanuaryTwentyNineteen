using System;
using System.Linq;

namespace Algorithms.Sorting
{
    public class QuickSort<T>
        where T : IComparable<T>
    {
        public void Sort(T[] arrayToSort)
        {
            //Step 1 is to shuffle the array
            ShuffleArray(arrayToSort);
            SortArray(arrayToSort, 0, arrayToSort.Length - 1);
        }

        private void SortArray(T[] arrayToSort, int lo, int hi)
        {
            if (lo >= hi)
            {
                return;
            }

            var partion = Partion(arrayToSort, lo, hi);
            SortArray(arrayToSort, lo, partion - 1);
            SortArray(arrayToSort, partion + 1, hi);
        }

        private int Partion(T[] arrayToSort, int lo, int hi)
        {
            //assign to pivot and then increment lo
            var pivot = lo++;
            while (true)
            {
                while (arrayToSort[lo].CompareTo(arrayToSort[pivot]) < 0 && lo < hi)
                {
                    lo++;
                }

                while (arrayToSort[hi].CompareTo(arrayToSort[pivot]) >= 0 && hi >= lo)
                {
                    hi--;
                }

                if (hi > lo)
                {
                    arrayToSort.Swap(hi, lo);
                }
                else
                {
                    arrayToSort.Swap(hi, pivot);
                    break;
                }
            }

            return hi;
        }

        private void ShuffleArray(T[] arrayToSort)
        {
            Random rand = new Random();

            var range = Enumerable.Range(0, arrayToSort.Length - 1);
            var result = range.OrderBy(i => rand.Next()).ToList();

            var temp = 0;
            for (int i = 0; i < result.Count; i++)
            {
                arrayToSort.Swap(temp, result[i]);
                temp = result[i];
            }
        }
    }
}
