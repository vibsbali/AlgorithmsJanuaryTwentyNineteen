using System;
using System.Linq;
using Algorithms.AssociativeArrays;

namespace Algorithms.Console
{
   class Program
   {
      static void Main(string[] args)
      {
         var arrayToSort = new[] { 3, int.MaxValue, int.MinValue, 5, 12, 2, 34, 1, -4, -4, 0 }; 
         
         var priorityQueue = new PriorityQueue<int>();

         foreach (var i in arrayToSort)
         {
            priorityQueue.Enqueue(i);
         }

         for (int i = 0; i < 3; i++)
         {
            var firstItem = priorityQueue.Dequeue();
            System.Console.WriteLine(firstItem);
            var secondItem = priorityQueue.Dequeue();
            System.Console.WriteLine(secondItem);
            Assert.IsTrue(firstItem <= secondItem, $"Should be true values are {firstItem}, {secondItem}");
         }


         priorityQueue.Enqueue(4);
         priorityQueue.Enqueue(int.MaxValue);
         priorityQueue.Enqueue(-42);
         priorityQueue.Enqueue(33);
         priorityQueue.Enqueue(13);
         priorityQueue.Enqueue(3);
         priorityQueue.Enqueue(333);

         for (int i = 0; i < 3; i++)
         {
            var firstItem = priorityQueue.Dequeue();
            System.Console.WriteLine(firstItem);
            var secondItem = priorityQueue.Dequeue();
            System.Console.WriteLine(secondItem);
            Assert.IsTrue(firstItem <= secondItem, $"Should be true values are {firstItem}, {secondItem}");
         }
      }
   }

   static class Assert
   {
      public static void IsTrue(bool b, string s)
      {
         if (!b)
         {
            throw new ApplicationException(s);
         }
      }
   }
}
