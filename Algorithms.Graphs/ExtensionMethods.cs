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

        public static void AddOrUpdate<T, TV>(this IDictionary<T, TV> dictionary, T key, TV value, Dictionary<Tuple<T, TV>, int> cummulativeWeightDictionary, int cummulativeWeight)
        {
            //child already has an existing parent
            if (dictionary.ContainsKey(key))
            {
                var existingParent = dictionary[key];
                var tuple = new Tuple<T, TV>(key, existingParent);
                var existingWeight = cummulativeWeightDictionary[tuple];
                if (existingWeight <= cummulativeWeight)
                {
                    return;
                }

                dictionary.Remove(key);
                cummulativeWeightDictionary.Remove(tuple);
            }

            dictionary.Add(key, value);
            cummulativeWeightDictionary.Add(new Tuple<T, TV>(key, value), cummulativeWeight);
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