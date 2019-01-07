using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Graphs
{
    public interface IGraph
    {
        int NumberOfVertices { get; }
        int NumberOfEdges { get; }
        void AddEdge(int start, int end, int weight = 0);
        void AddVertex();
        List<int> GetReachableNeighbours(int vertex);
        int GetWeight(int start, int end);
        bool IsDirected { get; }
    }
}
