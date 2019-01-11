using System;


namespace Algorithms.Sorting
{
    public class InsertionSort<T>
        where T : IComparable<T>
    {
        public void Sort(T[] arrayToSort)
        {
            for (int i = 1; i < arrayToSort.Length; i++)
            {
                //check if previous index value is greater than current and if so we need to find insertion position
                if (arrayToSort[i - 1].CompareTo(arrayToSort[i]) > 0)
                {                    
                    // j is going to be an index that we are going to compare current value of i against
                    // it is very important that we check for arrayToSort[j - 1] because we want to decrement j
                    // only if it is less than i
                    var j = i;
                    while (j > 0 && arrayToSort[j - 1].CompareTo(arrayToSort[i]) > 0)
                    {
                        --j;
                    }

                    var temp = arrayToSort[i];
                    Array.Copy(arrayToSort, j, arrayToSort, j + 1, i - j);
                    arrayToSort[j] = temp;
                }
            }
        }
    }
}
