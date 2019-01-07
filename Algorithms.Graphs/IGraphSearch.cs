using System.Collections.Generic;

namespace Algorithms.Graphs
{
    public interface IGraphSearch
    {
        bool AreConnected(int start, int goal);
        List<int> GetPath(int start, int goal);
    }
}