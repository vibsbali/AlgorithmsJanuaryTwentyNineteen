using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Graphs
{
    public class AdjacencyList : IGraph
    {
        internal struct Edge
        {
            internal int Start;
            internal int End;

            public Edge(int start, int end)
            {
                Start = start;
                End = end;
            }
        }

        public int NumberOfVertices { get; private set; }
        public int NumberOfEdges { get; private set; }

        private readonly Dictionary<Edge, int> _edgesWithWeights;
        private readonly Dictionary<int, List<int>> _adjacencyList;

        public AdjacencyList(int numberOfVertices, bool isDirected)
        {
            if (numberOfVertices < 0)
            {
                throw new InvalidOperationException();
            }

            NumberOfVertices = numberOfVertices;
            IsDirected = isDirected;
            _edgesWithWeights = new Dictionary<Edge, int>();
            _adjacencyList = new Dictionary<int, List<int>>();
            for (int i = 0; i < numberOfVertices; i++)
            {
                _adjacencyList.Add(i, new List<int>());
            }
        }


        public void AddEdge(int start, int end, int weight)
        {
            if (start >= NumberOfVertices || end >= NumberOfVertices)
            {
                throw new InvalidOperationException();
            }

            AddEdgeInternal(start, end, weight);

            if (!IsDirected)
            {
                AddEdgeInternal(end, start, weight);
            }
        }

        private void AddEdgeInternal(int start, int end, int weight)
        {
            if (!_adjacencyList[start].Contains(end))
            {
                _adjacencyList[start].Add(end);
            }


            var edge = new Edge(start, end);
            if (_edgesWithWeights.ContainsKey(edge))
            {
                _edgesWithWeights.Remove(edge);
            }
            _edgesWithWeights.Add(edge, weight);

            ++NumberOfEdges;
        }

        public void AddVertex()
        {
            _adjacencyList.Add(NumberOfVertices, new List<int>());
            ++NumberOfVertices;
        }

        public List<int> GetReachableNeighbours(int vertex)
        {
            if (vertex >= NumberOfVertices)
            {
                throw new InvalidOperationException();
            }

            return _adjacencyList[vertex].ToList();
        }

        public int GetWeight(int start, int end)
        {
            if (start >= NumberOfVertices || end >= NumberOfVertices)
            {
                throw new InvalidOperationException();
            }

            var edge = new Edge(start, end);
            if (_edgesWithWeights.ContainsKey(edge))
            {
                return _edgesWithWeights[edge];
            }

            throw new InvalidOperationException("Edge doesn't exist");
        }

        public bool IsDirected { get; }
    }
}
