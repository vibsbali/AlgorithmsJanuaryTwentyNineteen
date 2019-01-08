using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithms.Graphs
{
    public class DepthFirstSearch : IGraphSearch
    {
        private readonly IGraph Graph;

        public DepthFirstSearch(IGraph graph)
        {
            Graph = graph;
        }

        public bool AreConnected(int start, int goal)
        {
            ValidateInputs(start, goal);

            var stack = new Stack<int>();
            var listOfVisited = new HashSet<int>();

            stack.Push(start);
            while (stack.Count > 0)
            {
                var curr = stack.Pop();

                if (listOfVisited.Contains(curr))
                {
                    continue;
                }

                listOfVisited.Add(curr);
                var neighboursOfCurr = Graph.GetReachableNeighbours(curr);
                foreach (var neighbour in neighboursOfCurr.Where(n => !listOfVisited.Contains(n)))
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

        private void ValidateInputs(int start, int end)
        {
            if (start >= Graph.NumberOfVertices || end >= Graph.NumberOfVertices || start == end)
            {
                throw new ArgumentOutOfRangeException();
            }
        }

        public List<int> GetPath(int start, int goal)
        {
            var stack = new Stack<int>();
            var listOfVisited = new HashSet<int>();
            
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

                if (listOfVisited.Contains(curr))
                {
                    continue;
                }

                listOfVisited.Add(curr);
                var neighbours = Graph.GetReachableNeighbours(curr);
                foreach (var neighbour in neighbours.Where(n => !listOfVisited.Contains(n)))
                {
                    parentMap.AddOrUpdate(neighbour, curr);
                    if (neighbour == goal)
                    {
                        return Path(start, goal, parentMap);
                    }
                    stack.Push(neighbour);
                }
            }

            return null;
        }

        private List<int> Path(int start, int goal, IDictionary<int, int> parentMap)
        {
            var stack = new Stack<int>();
            var current = goal;
            stack.Push(current);

            while (true)
            {
                current = parentMap[current];
                stack.Push(current);

                if (current == start)
                {
                    return stack.ToList();
                }
            }
        }
    }
}
