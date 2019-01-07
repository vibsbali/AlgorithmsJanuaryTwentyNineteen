using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Algorithms.Graphs
{
    public class BreadthFirstSearch : IGraphSearch
    {
        public BreadthFirstSearch(IGraph graph)
        {
            Graph = graph;
        }

        public IGraph Graph { get; }

        public bool AreConnected(int start, int goal)
        {
            //check that start and goal are not same and are within bound
            ValidateInputs(start, goal);

            var queue = new Queue<int>();
            var listOfVisited = new HashSet<int>();

            queue.Enqueue(start);
            while (queue.Count > 0)
            {
                var curr = queue.Dequeue();

                if (listOfVisited.Contains(curr))
                {
                    continue;
                }

                listOfVisited.Add(curr);
                var neighbours = Graph.GetReachableNeighbours(curr);
                foreach (var neighbour in neighbours.Where(n => !listOfVisited.Contains(n)))
                {
                    if (neighbour == goal)
                    {
                        return true;
                    }

                    queue.Enqueue(neighbour);
                }
            }

            return false;
        }

        private void ValidateInputs(int start, int goal)
        {
            if (start >= Graph.NumberOfVertices || goal >= Graph.NumberOfVertices 
                || start == goal)
            {
                throw new ArgumentOutOfRangeException();
            }
        }

        public List<int> GetPath(int start, int goal)
        {
            ValidateInputs(start, goal);

            var queue = new Queue<int>();
            var parentMap = new Dictionary<int, int>();
            var listOfVisited = new HashSet<int>();

            queue.Enqueue(start);
            while (queue.Count > 0)
            {
                var curr = queue.Dequeue();

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

                    queue.Enqueue(neighbour);
                }
            }

            return null;
        }

        private List<int> Path(int start, int goal, Dictionary<int, int> parentMap)
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
