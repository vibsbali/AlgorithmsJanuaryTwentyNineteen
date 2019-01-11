using Algorithms.Sorting;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Algorithm.SortingTests
{
    [TestClass]
    public class BubbleSortTests
    {
        [TestMethod]
        public void Sort_An_UnSorted_Array()
        {
            var arrayToSort = new[] {3, 5, 12, 2, 34, 1, -4, 0};
            var bubbleSort = new BubbleSort<int>();

            bubbleSort.Sort(arrayToSort);
            for (int i = 0; i < arrayToSort.Length - 1; i++)
            {
                Assert.IsTrue(arrayToSort[i] <= arrayToSort[i + 1], $"Should be false i is {i} and values are {arrayToSort[i]}, {arrayToSort[i+1]}");
            }
        }

        [TestMethod]
        public void Sort_A_Sorted_Array()
        {
            var arrayToSort = new[] { 1, 2, 3, 4, 5, 6, 7 };
            var bubbleSort = new BubbleSort<int>();

            bubbleSort.Sort(arrayToSort);
            for (int i = 0; i < arrayToSort.Length - 1; i++)
            {
                Assert.IsTrue(arrayToSort[i] <= arrayToSort[i + 1], $"Should be false i is {i} and values are {arrayToSort[i]}, {arrayToSort[i + 1]}");
            }

            Assert.IsTrue(bubbleSort.NumberOfRuns == 1, "Should only be run once because the array is already sorted");
        }

        [TestMethod]
        public void Sort_An_UnSorted_Array_Includes_IntMin_And_IntMax_Values()
        {
            var arrayToSort = new[] { 3, int.MaxValue, int.MinValue, 5, 12, 2, 34, 1, -4, -4, 0 };
            var bubbleSort = new BubbleSort<int>();

            bubbleSort.Sort(arrayToSort);
            for (int i = 0; i < arrayToSort.Length - 1; i++)
            {
                Assert.IsTrue(arrayToSort[i] <= arrayToSort[i + 1], $"Should be false i is {i} and values are {arrayToSort[i]}, {arrayToSort[i + 1]}");
            }
        }
    }
}
