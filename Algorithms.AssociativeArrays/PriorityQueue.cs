using System;
using System.Collections.Generic;

namespace Algorithms.AssociativeArrays
{
   public class PriorityQueue<T>
       where T : IComparable<T>
   {
      public List<T> BackingStore { get; set; }
      public PriorityQueue()
      {
         BackingStore = new List<T>();
      }
      public IEnumerator<T> GetEnumerator()
      {
         foreach (var item in BackingStore)
         {
            yield return item;
         }
      }

      public void Enqueue(T item)
      {
         BackingStore.Insert(Count, item);
         Count++;
         SwimUp();
      }

      private void SwimUp()
      {
         var index = Count - 1;
         var parent = (index - 1) / 2;
         while (parent >= 0 && BackingStore[index].CompareTo(BackingStore[parent]) < 0)
         {
            Swap(index, parent);

            index = parent;
            parent = (index - 1) / 2;
         }
      }

      private void Swap(int left, int right)
      {
         var temp = BackingStore[right];
         BackingStore[right] = BackingStore[left];
         BackingStore[left] = temp;
      }


      public void Clear()
      {
         BackingStore = new List<T>();
      }

      public bool Contains(T item)
      {
         return BackingStore.Contains(item);
      }

      public void CopyTo(T[] array, int arrayIndex)
      {
         Array.Copy(BackingStore.ToArray(), 0, array, arrayIndex, Count);
      }

      public T Dequeue()
      {
         var itemToReturn = BackingStore[0];
         BackingStore[0] = default(T);
         Swap(0, Count - 1);
         --Count;

         SwimDown(0);
         
         return itemToReturn;
      }

      private void SwimDown(int index)
      {
         if (index >= Count - 1)
         {
            return;
         }

         int minChild;
         var leftChild = index * 2 + 1;
         var rightChild = index * 2 + 2;

         if (rightChild > Count - 1)
         {
            if (leftChild > Count - 1)
            {
               return;
            }

            minChild = leftChild;
         }
         else
         {
            minChild = BackingStore[leftChild].CompareTo(BackingStore[rightChild]) < 0 ? leftChild : rightChild;
         }

         //If we have matched min heap property then no need to go down the level
         if (BackingStore[minChild].CompareTo(BackingStore[index]) >= 0)
         {
            return;
         }
         Swap(index, minChild);
         SwimDown(minChild);
      }

      public int Count { get; private set; }
      public bool IsReadOnly => false;
   }
}
