using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Algorithms.Graphs
{
    public static class ExtensionMethods
    {
        public static void AddOrUpdate<T, TV>(this IDictionary<T, TV> dictionary, T key, TV value)
        {
            if (dictionary.ContainsKey(key))
            {
                dictionary.Remove(key);
            }
            dictionary.Add(key, value);
        }

        public static (int vertex, int weight) Dequeue(this List<ValueTuple<int, int>> priorityQueue)
        {
            var itemToRemove = priorityQueue.OrderBy(i => i.Item2).First();
            priorityQueue.Remove(itemToRemove);
            return itemToRemove;
        }

        public static void Enqueue(this List<ValueTuple<int, int>> priorityQueue, int vertex, int weight)
        {
            priorityQueue.Add(new ValueTuple<int, int>(vertex, weight));
        }
    }
}