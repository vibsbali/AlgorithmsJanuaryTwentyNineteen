namespace Algorithms.GraphRevised
{
    public interface IGraph
    {
        int NumberOfVertex { get; }
        int NumberOfEdges { get; }
        bool IsDirected { get; }
        void AddVertex();
        void AddEdge(int startingVertex, int endingVertex, int weight);
        bool AreConnected(int startingVertex, int endingVertex);
        int GetWeight(int startingVertex, int endingVertex);
    }
}
