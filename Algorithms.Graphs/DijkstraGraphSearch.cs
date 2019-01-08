using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithms.Graphs
{
    public class DijkstraGraphSearch : IGraphSearch
    {
        public DijkstraGraphSearch(IGraph graph)
        {
            Graph = graph;
        }

        public IGraph Graph { get; }

        public bool AreConnected(int start, int goal)
        {
            ValidateInputs(start, goal);

            var priorityQueue = new List<ValueTuple<int, int>>();
            var visited = new HashSet<int>();

            priorityQueue.Enqueue(start, 0);
            while (priorityQueue.Count > 0)
            {
                var curr = priorityQueue.Dequeue();

                var vertex = curr.vertex;
                if (vertex == goal)
                {
                    return true;
                }

                if (visited.Contains(vertex))
                {
                    continue;
                }

                visited.Add(vertex);
                var unvisitedNeighbours = Graph.GetReachableNeighbours(vertex).Where(v => !visited.Contains(v));
                foreach (var unvisitedNeighbour in unvisitedNeighbours)
                {
                    var weight = Graph.GetWeight(vertex, unvisitedNeighbour);
                    priorityQueue.Enqueue(unvisitedNeighbour, weight + curr.weight);
                }
            }

            return false;
        }

        public List<int> GetPath(int start, int goal)
        {
            ValidateInputs(start, goal);

            var parentMap = new Dictionary<int, int>();
            var priorityQueue = new List<ValueTuple<int, int>>();
            var visited = new HashSet<int>();

            priorityQueue.Enqueue(start, 0);
            while (priorityQueue.Count > 0)
            {
                var curr = priorityQueue.Dequeue();

                var vertex = curr.vertex;
                if (vertex == goal)
                {
                    return Path(parentMap, start, goal);
                }

                if (visited.Contains(vertex))
                {
                    continue;
                }

                visited.Add(vertex);
                var unvisitedNeighbours = Graph.GetReachableNeighbours(vertex).Where(v => !visited.Contains(v));
                foreach (var unvisitedNeighbour in unvisitedNeighbours)
                {
                    var weight = Graph.GetWeight(vertex, unvisitedNeighbour);
                    priorityQueue.Enqueue(unvisitedNeighbour, weight + curr.weight);
                    parentMap.Add(unvisitedNeighbour, vertex);
                }
            }

            return null;
        }

        private List<int> Path(Dictionary<int, int> parentMap, int start, int goal)
        {
            var path = new Stack<int>();
            var curr = goal;

            path.Push(curr);
            while (true)
            {
                curr = parentMap[curr];
                path.Push(curr);

                if (curr == goal)
                {
                    return path.ToList();
                }
            }
        }


        private void ValidateInputs(int start, int end)
        {
            if (start >= Graph.NumberOfVertices || end >= Graph.NumberOfVertices || start == end)
            {
                throw new ArgumentOutOfRangeException();
            }
        }
    }
}
