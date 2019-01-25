using System;
using System.Collections.Generic;

namespace Algorithms.GraphRevised
{
    public class AdjacencyList : IGraph
    {
        public int NumberOfVertex { get; private set; }
        public int NumberOfEdges { get; private set; }
        public bool IsDirected { get; }

        private Dictionary<Tuple<int, int>, int> _backingStore;

        public AdjacencyList(int numberOfVertex, bool isDirected)
        {
            _backingStore = new Dictionary<Tuple<int, int>, int>();
            NumberOfVertex = numberOfVertex;
            IsDirected = isDirected;
        }

        public void AddVertex()
        {
            NumberOfVertex++;
        }

        public void AddEdge(int startingVertex, int endingVertex, int weight = 0)
        {
            if (startingVertex > NumberOfVertex - 1 || endingVertex > NumberOfVertex - 1)
            {
                throw new ArgumentOutOfRangeException();
            }

            AddEdgeWithWeight(startingVertex, endingVertex, weight);
        }

        private void AddEdgeWithWeight(int startingVertex, int endingVertex, int weight)
        {
            var tuple = new Tuple<int, int>(startingVertex, endingVertex);
            if (_backingStore.ContainsKey(tuple))
            {
                _backingStore.Remove(tuple);
            }

            _backingStore.Add(tuple, weight);
            ++NumberOfEdges;
        }

        public bool AreConnected(int startingVertex, int endingVertex)
        {
            if (startingVertex > NumberOfVertex - 1 || endingVertex > NumberOfVertex - 1)
            {
                throw new ArgumentOutOfRangeException();
            }

            return _backingStore.ContainsKey(new Tuple<int, int>(startingVertex, endingVertex));
        }

        public int GetWeight(int startingVertex, int endingVertex)
        {
            if (startingVertex > NumberOfVertex - 1 || endingVertex > NumberOfVertex - 1)
            {
                throw new ArgumentOutOfRangeException();
            }

            if (!AreConnected(startingVertex, endingVertex))
            {
                throw new InvalidOperationException("Not Connected");
            }

            return _backingStore[new Tuple<int, int>(startingVertex, endingVertex)];
        }
    }
}