using System;

namespace Algorithms.GraphRevised
{
    public class AdjacencyMatrix : IGraph
    {
        public int NumberOfVertex { get; private set; }
        public int NumberOfEdges { get; private set; }
        public bool IsDirected { get; private set; }

        //creating a 3 dimensional array 
        //3rd dimension for weight
        private int[,,] _backingStore;
        
        public void AddEdge(int startingVertex, int endingVertex, int weight = 0)
        {
            if (startingVertex > _backingStore.GetUpperBound(0) || endingVertex > _backingStore.GetUpperBound(0))
            {
                throw new ArgumentOutOfRangeException();
            }

            AddEdgeWithWeight(startingVertex, endingVertex, weight);
            if (!IsDirected)
            {
                AddEdgeWithWeight(endingVertex, startingVertex, weight);
            }
        }

        private void AddEdgeWithWeight(int startingVertex, int endingVertex, int weight)
        {
            _backingStore[startingVertex, endingVertex, 0] = 1;
            _backingStore[startingVertex, endingVertex, 1] = weight;
            ++NumberOfEdges;
        }

        public bool AreConnected(int startingVertex, int endingVertex)
        {
            return _backingStore[startingVertex, endingVertex, 0] == 1;
        }

        public int GetWeight(int startingVertex, int endingVertex)
        {
            if (startingVertex > _backingStore.GetUpperBound(0) || endingVertex > _backingStore.GetUpperBound(0))
            {
                throw new ArgumentOutOfRangeException();
            }

            if (!AreConnected(startingVertex, endingVertex))
            {
                throw new InvalidOperationException("Not Connected");
            }

            return _backingStore[startingVertex, endingVertex, 1];
        }

        public AdjacencyMatrix(int numberOfVertex, bool isDirected)
        {
            //3d array 0th index to contain edges and 1st index to contain weights
            _backingStore = new int[numberOfVertex,numberOfVertex, 2];
            IsDirected = isDirected;
        }

        public void AddVertex()
        {
            var temp = new int[NumberOfVertex + 1, NumberOfVertex + 1, 2];
            for (int i = 0; i < _backingStore.GetUpperBound(0); i++)
            {
                for (int j = 0; j < _backingStore.GetUpperBound(0); j++)
                {
                    temp[i, j, 0] = _backingStore[i, j, 0];
                    temp[i, j, 1] = _backingStore[i, j, 1];
                }
            }

            _backingStore = temp;
            ++NumberOfVertex;
        }
    }
}