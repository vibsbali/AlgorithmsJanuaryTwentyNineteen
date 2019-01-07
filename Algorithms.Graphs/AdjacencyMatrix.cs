using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Algorithms.Graphs
{
    public class AdjacencyMatrix : IGraph
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

        public AdjacencyMatrix(int numberOfVertices, bool isDirected)
        {
            if (NumberOfVertices < 0)
            {
                throw new InvalidOperationException();
            }

            NumberOfVertices = numberOfVertices;
            IsDirected = isDirected;
            _backingStore = new int[numberOfVertices,numberOfVertices];
            _edgesWithWeights = new Dictionary<Edge, int>();
        }

        private int[,] _backingStore;
        private Dictionary<Edge, int> _edgesWithWeights;
        
        public int NumberOfVertices { get; private set; }
        public int NumberOfEdges { get; private set; }
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
            _backingStore[start, end] = 1;

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
            if (NumberOfVertices == _backingStore.GetUpperBound(0))
            {
                var temp = new int[NumberOfVertices * 2, NumberOfVertices * 2];
                for (int i = 0; i < NumberOfVertices; i++)
                {
                    for (int j = 0; j < NumberOfVertices; j++)
                    {
                        temp[i, j] = _backingStore[i, j];
                    }
                }

                _backingStore = temp;
            }

            ++NumberOfVertices;
        }

        public List<int> GetReachableNeighbours(int vertex)
        {
            if (vertex >= NumberOfVertices)
            {
                throw new InvalidOperationException();
            }

            var listOfNeighbours = new List<int>();
            for (int i = 0; i < _backingStore.GetUpperBound(0); i++)
            {
                if (_backingStore[vertex, i] == 1)
                {
                    listOfNeighbours.Add(i);
                }
            }

            return listOfNeighbours;
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

            throw new InvalidOperationException("No edge present");
        }

        public bool IsDirected { get; }
    }
}
