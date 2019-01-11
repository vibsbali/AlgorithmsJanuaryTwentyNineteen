using Algorithms.Sorting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace Algorithm.SortingTests
{
    [TestClass]
    public class InsertionSortTests
    {
        [TestMethod]
        public void Sort_21_UnSorted_Array_To_12()
        {
            var arrayToSort = new[] { 2, 1 };
            var copy = arrayToSort.OrderBy(i => i).ToArray();
            var insertionSort = new InsertionSort<int>();

            insertionSort.Sort(arrayToSort);
            for (int i = 0; i < arrayToSort.Length - 1; i++)
            {
                Assert.IsTrue(arrayToSort[i] == copy[i], $"Should be false i is {i} and values are {arrayToSort[i]}, {copy[i]}");
            }
        }

        [TestMethod]
        public void Sort_231_UnSorted_Array_To_123()
        {
            var arrayToSort = new[] { 2, 3, 1 };
            var copy = arrayToSort.OrderBy(i => i).ToArray();
            var insertionSort = new InsertionSort<int>();

            insertionSort.Sort(arrayToSort);
            for (int i = 0; i < arrayToSort.Length - 1; i++)
            {
                Assert.IsTrue(arrayToSort[i] == copy[i], $"Should be false i is {i} and values are {arrayToSort[i]}, {copy[i]}");
            }
        }


        [TestMethod]
        public void Sort_An_UnSorted_Array()
        {
            var arrayToSort = new[] {3, 5, 12, 2, 34, 1, -4, 0};
            var copy = arrayToSort.OrderBy(i => i).ToArray();
            var insertionSort = new InsertionSort<int>();

            insertionSort.Sort(arrayToSort);
            for (int i = 0; i < arrayToSort.Length; i++)
            {
                Assert.IsTrue(arrayToSort[i] == copy[i], $"Should be false i is {i} and values are {arrayToSort[i]}, {copy[i]}");
            }
        }

        [TestMethod]
        public void Sort_A_Sorted_Array()
        {
            var arrayToSort = new[] { 1, 2, 3, 4, 5, 6, 7 };
            var copy = arrayToSort.OrderBy(i => i).ToArray();
            var insertionSort = new InsertionSort<int>();

            insertionSort.Sort(arrayToSort);
            for (int i = 0; i < arrayToSort.Length - 1; i++)
            {
                Assert.IsTrue(arrayToSort[i] == copy[i], $"Should be false i is {i} and values are {arrayToSort[i]}, {copy[i]}");
            }            
        }

        [TestMethod]
        public void Sort_An_UnSorted_Array_Includes_IntMin_And_IntMax_Values()
        {
            var arrayToSort = new[] { 3, int.MaxValue, int.MinValue, 5, 12, 2, 34, 1, -4, -4, 0 };
            var copy = arrayToSort.OrderBy(i => i).ToArray();
            var insertionSort = new InsertionSort<int>();

            insertionSort.Sort(arrayToSort);
            for (int i = 0; i < arrayToSort.Length - 1; i++)
            {
                Assert.IsTrue(arrayToSort[i] == copy[i], $"Should be false i is {i} and values are {arrayToSort[i]}, {copy[i]}");
            }
        }
    }
}
