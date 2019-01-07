using Algorithms.Graphs;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Algorithms.GraphTests
{
    [TestClass]
    public class AdjacencyListTests
    {
        IGraph UndirectedGraph;
        IGraph DirectedGraph;

        [TestInitialize]
        public void Initialise()
        {
            UndirectedGraph = new AdjacencyList(10, false);
            DirectedGraph = new AdjacencyList(10, true);
        }

        [TestMethod]
        public void Create_AdjacencyMatrix_With_Ten_Vertices_Assert_Number_Of_Vertices_Equal_Ten()
        {
            var numberOfVertices = UndirectedGraph.NumberOfVertices;
            Assert.AreEqual(10, numberOfVertices);
            
        }


        [TestMethod]
        public void Add_Edge_Between_Zero_And_One_Assert_Are_Neighbours()
        {
            UndirectedGraph.AddEdge(0, 1, 0);
            var neighboursOfZero = UndirectedGraph.GetReachableNeighbours(0);
            var neighboursOfOne = UndirectedGraph.GetReachableNeighbours(1);

            Assert.IsTrue(neighboursOfZero.Contains(1));
            Assert.IsTrue(neighboursOfOne.Contains(0));

            DirectedGraph.AddEdge(0, 1, 0);
            neighboursOfZero = DirectedGraph.GetReachableNeighbours(0);
            neighboursOfOne = DirectedGraph.GetReachableNeighbours(1);

            Assert.IsTrue(neighboursOfZero.Contains(1));
            Assert.IsFalse(neighboursOfOne.Contains(0));
        }

        [TestMethod]
        public void Add_Edge_Between_Zero_And_One_With_Weight_Assert_Neighbours_With_Weight()
        {
            UndirectedGraph.AddEdge(0, 1, 2);
            var neighboursOfZero = UndirectedGraph.GetReachableNeighbours(0);
            var neighboursOfOne = UndirectedGraph.GetReachableNeighbours(1);

            Assert.IsTrue(neighboursOfZero.Contains(1));
            Assert.IsTrue(neighboursOfOne.Contains(0));
            Assert.AreEqual(2, UndirectedGraph.GetWeight(0, 1));
            Assert.AreEqual(2, UndirectedGraph.GetWeight(1, 0));

            DirectedGraph.AddEdge(0, 1, 2);
            neighboursOfZero = DirectedGraph.GetReachableNeighbours(0);
            neighboursOfOne = DirectedGraph.GetReachableNeighbours(1);

            Assert.IsTrue(neighboursOfZero.Contains(1));
            Assert.IsFalse(neighboursOfOne.Contains(0));
            Assert.AreEqual(2, DirectedGraph.GetWeight(0, 1));
        }
    }
}