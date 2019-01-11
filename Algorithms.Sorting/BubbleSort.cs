using System;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Algorithm.SortingTests")]
namespace Algorithms.Sorting
{
    public class BubbleSort<T>
        where T : IComparable<T>
    {
        internal int NumberOfRuns { get; private set; }
        public void Sort(T[] arrayToSort)
        {
            bool isSwaped;
            do
            {
                //set is swapped to false
                isSwaped = false;
                ++NumberOfRuns;

                for (int i = 0; i < arrayToSort.Length - 1; i++)
                {
                    if (arrayToSort[i].CompareTo(arrayToSort[i + 1]) > 0)
                    {
                        arrayToSort.Swap(i, i + 1);
                        isSwaped = true;
                    }
                }


            } while (isSwaped);
        }
    }
}
