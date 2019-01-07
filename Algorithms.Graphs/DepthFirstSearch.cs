using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Graphs
{
    public class DepthFirstSearch : IGraphSearch
    {
        private readonly IGraph _graph;

        public DepthFirstSearch(IGraph graph)
        {
            _graph = graph;
        }

        public bool AreConnected(int start, int goal)
        {
            AssertWithinBounds(start, goal);

            var stack = new Stack<int>();
            var dictOfHasVisited = new Dictionary<int, int>();
            while (stack.Count > 0)
            {
                var curr = stack.Pop();

                if (dictOfHasVisited.ContainsKey(curr))
                {
                    continue;
                }

                dictOfHasVisited.Add(curr, curr);
                var neighboursOfCurr = _graph.GetReachableNeighbours(curr);
                foreach (var neighbour in neighboursOfCurr.Where(n => !dictOfHasVisited.ContainsKey(n)))
                {
                    if (neighbour == goal)
                    {
                        return true;
                    }
                    stack.Push(neighbour);
                }
            }

            return false;
        }

        private void AssertWithinBounds(int start, int end)
        {
            if (start >= _graph.NumberOfVertices || end >= _graph.NumberOfVertices || start == end)
            {
                throw new InvalidOperationException();
            }
        }

        public List<int> GetPath(int start, int goal)
        {
            var stack = new Stack<int>();
            var dictOfHasVisited = new Dictionary<int, int>();
            
            //will hold child, parent
            var parentMap = new Dictionary<int, int>();

            stack.Push(start);
            while (stack.Count > 0)
            {
                var curr = stack.Pop();

                if (curr == goal)
                {
                    return Path(start, goal, parentMap);
                }

                if (dictOfHasVisited.ContainsKey(curr))
                {
                    continue;
                }

                dictOfHasVisited.Add(curr, curr);
                var neighbours = _graph.GetReachableNeighbours(curr);
                foreach (var neighbour in neighbours.Where(n => !dictOfHasVisited.ContainsKey(n)))
                {
                    parentMap.AddOrUpdate(neighbour, curr);

                    if (neighbour == goal)
                    {
                        return Path(start, goal, parentMap);
                    }
                }
            }

            return null;
        }

        private List<int> Path(int start, int goal, IDictionary<int, int> parentMap)
        {
            var stack = new Stack<int>();
            stack.Push(goal);
            while (true)
            {
                var parent = parentMap[goal];
                stack.Push(parent);

                if (parent == start)
                {
                    return stack.ToList();
                }
            }
        }
    }

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
    }
}
