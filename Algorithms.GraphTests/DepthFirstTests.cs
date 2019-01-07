using Algorithms.Graphs;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Algorithms.GraphTests
{
    [TestClass]
    public class DepthFirstTests
    {
        IGraph adjacencyGraph;
        IGraph adjacencyList;
        IGraphSearch depthFirstSearchForAdjacencyGraph;
        IGraphSearch depthFirstSearchForAdjacencyList;

        [TestInitialize]
        public void TestSetup()
        {
            adjacencyGraph = new AdjacencyMatrix(12, false);
            adjacencyList = new AdjacencyList(12, false);

            depthFirstSearchForAdjacencyGraph = new DepthFirstSearch(adjacencyGraph);

            depthFirstSearchForAdjacencyList = new DepthFirstSearch(adjacencyList);
        }

        [TestMethod]
        public void Assert_Path()
        {
            /*  1--2
                |
                3--0
                |
                4--5
                |  |
                7--6
                |
                8--9

               10--11

             */

            adjacencyGraph.AddEdge(1, 2);
            adjacencyGraph.AddEdge(1, 3);
            adjacencyGraph.AddEdge(3, 0);
            adjacencyGraph.AddEdge(3, 4);
            adjacencyGraph.AddEdge(4, 5);
            adjacencyGraph.AddEdge(5, 6);
            adjacencyGraph.AddEdge(4, 7);
            adjacencyGraph.AddEdge(7, 6);
            adjacencyGraph.AddEdge(7, 8);
            adjacencyGraph.AddEdge(8, 9);
            adjacencyGraph.AddEdge(10, 11);

            /* -------------------------------*/

            adjacencyList.AddEdge(1, 2);
            adjacencyList.AddEdge(1, 3);
            adjacencyList.AddEdge(3, 0);
            adjacencyList.AddEdge(3, 4);
            adjacencyList.AddEdge(4, 5);
            adjacencyList.AddEdge(5, 6);
            adjacencyList.AddEdge(4, 7);
            adjacencyList.AddEdge(7, 6);
            adjacencyList.AddEdge(7, 8);
            adjacencyList.AddEdge(8, 9);
            adjacencyList.AddEdge(10, 11);

            Assert.IsTrue(depthFirstSearchForAdjacencyGraph.AreConnected(9, 0), "DFS One Failed");
            Assert.IsFalse(depthFirstSearchForAdjacencyGraph.AreConnected(10, 0), "DFS Two Failed");


            Assert.IsTrue(depthFirstSearchForAdjacencyList.AreConnected(9, 0), "DFS Three Failed");
            Assert.IsFalse(depthFirstSearchForAdjacencyList.AreConnected(10, 0), "DFS Fourth Failed");
        }
    }
}
