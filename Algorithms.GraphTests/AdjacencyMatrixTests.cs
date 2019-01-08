using System;
using System.Collections.Generic;
using System.Text;
using Algorithms.Graphs;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Algorithms.GraphTests
{
    [TestClass]
    public class AdjacencyMatrixTests
    {
        IGraph _undirectedGraph;
        IGraph _directedGraph;

        [TestInitialize]
        public void Initialise()
        {
            _undirectedGraph = new AdjacencyMatrix(10, false);
            _directedGraph = new AdjacencyMatrix(10, true);
        }

        [TestMethod]
        public void Create_AdjacencyMatrix_With_Ten_Vertices_Assert_Number_Of_Vertices_Equal_Ten()
        {
            Assert.AreEqual(10, _directedGraph.NumberOfVertices);
            Assert.AreEqual(10, _undirectedGraph.NumberOfVertices);
        }

        [TestMethod]
        public void Add_One_More_Vertex()
        {
            _undirectedGraph.AddVertex();
            _directedGraph.AddVertex();

            Assert.AreEqual(11, _directedGraph.NumberOfVertices);
            Assert.AreEqual(11, _undirectedGraph.NumberOfVertices);
        }

        [TestMethod]
        public void Default_Initialization_Zero_Edges()
        {
            Assert.AreEqual(0, _undirectedGraph.NumberOfEdges);
            Assert.AreEqual(0, _directedGraph.NumberOfEdges);
        }


        [TestMethod]
        public void Add_Edge_Between_Zero_And_One_Assert_Are_Neighbours()
        {
            _undirectedGraph.AddEdge(0, 1);
            var neighboursOfZero = _undirectedGraph.GetReachableNeighbours(0);
            var neighboursOfOne = _undirectedGraph.GetReachableNeighbours(1);

            Assert.IsTrue(neighboursOfZero.Contains(1));
            Assert.IsTrue(neighboursOfOne.Contains(0));
            Assert.AreEqual(2, _undirectedGraph.NumberOfEdges);

            _directedGraph.AddEdge(0, 1);
            neighboursOfZero = _directedGraph.GetReachableNeighbours(0);
            neighboursOfOne = _directedGraph.GetReachableNeighbours(1);

            Assert.IsTrue(neighboursOfZero.Contains(1));
            Assert.IsFalse(neighboursOfOne.Contains(0));
            Assert.AreEqual(1, _directedGraph.NumberOfEdges);
        }

        [TestMethod]
        public void Add_Edge_Between_Zero_And_One_With_Weight_Assert_Neighbours_With_Weight()
        {
            _undirectedGraph.AddEdge(0, 1, 2);
            var neighboursOfZero = _undirectedGraph.GetReachableNeighbours(0);
            var neighboursOfOne = _undirectedGraph.GetReachableNeighbours(1);

            Assert.IsTrue(neighboursOfZero.Contains(1));
            Assert.IsTrue(neighboursOfOne.Contains(0));
            Assert.AreEqual(2, _undirectedGraph.GetWeight(0, 1));
            Assert.AreEqual(2, _undirectedGraph.GetWeight(1, 0));

            _directedGraph.AddEdge(0, 1, 2);
            neighboursOfZero = _directedGraph.GetReachableNeighbours(0);
            neighboursOfOne = _directedGraph.GetReachableNeighbours(1);

            Assert.IsTrue(neighboursOfZero.Contains(1));
            Assert.IsFalse(neighboursOfOne.Contains(0));
            Assert.AreEqual(2, _directedGraph.GetWeight(0, 1));

            Assert.ThrowsException<InvalidOperationException>(() => _directedGraph.GetWeight(1, 0));
        }

        [TestCleanup]
        public void TearDown()
        {
            _directedGraph = null;
            _undirectedGraph = null;
        }
    }
}
