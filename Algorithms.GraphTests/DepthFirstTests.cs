using System;
using System.Collections.Generic;
using Algorithms.Graphs;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Algorithms.GraphTests
{
    [TestClass]
    public class DepthFirstTests
    {
        IGraph _adjacencyGraph;
        IGraph _adjacencyList;

        IGraph _adjacencyDirectedGraph;
        IGraph _adjacencyDirectedList;

        IGraphSearch _depthFirstSearchForAdjacencyGraph;
        IGraphSearch _depthFirstSearchForAdjacencyList;

        IGraphSearch _depthFirstSearchForDirectedAdjacencyGraph;
        IGraphSearch _depthFirstSearchForDirectedAdjacencyList;

        [TestInitialize]
        public void TestSetup()
        {
            _adjacencyGraph = new AdjacencyMatrix(12, false);
            _adjacencyList = new AdjacencyList(12, false);

            _adjacencyDirectedGraph = new AdjacencyMatrix(12, true);
            _adjacencyDirectedList = new AdjacencyList(12, true);

            _depthFirstSearchForAdjacencyGraph = new DepthFirstSearch(_adjacencyGraph);
            _depthFirstSearchForAdjacencyList = new DepthFirstSearch(_adjacencyList);

            _depthFirstSearchForDirectedAdjacencyGraph = new DepthFirstSearch(_adjacencyDirectedGraph);
            _depthFirstSearchForDirectedAdjacencyList = new DepthFirstSearch(_adjacencyDirectedList);
        }

        [TestMethod]
        public void Assert_Are_Connected()
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

            _adjacencyGraph.AddEdge(1, 2);
            _adjacencyGraph.AddEdge(1, 3);
            _adjacencyGraph.AddEdge(3, 0);
            _adjacencyGraph.AddEdge(3, 4);
            _adjacencyGraph.AddEdge(4, 5);
            _adjacencyGraph.AddEdge(5, 6);
            _adjacencyGraph.AddEdge(4, 7);
            _adjacencyGraph.AddEdge(7, 6);
            _adjacencyGraph.AddEdge(7, 8);
            _adjacencyGraph.AddEdge(8, 9);
            _adjacencyGraph.AddEdge(10, 11);

            /* -------------------------------*/

            _adjacencyList.AddEdge(1, 2);
            _adjacencyList.AddEdge(1, 3);
            _adjacencyList.AddEdge(3, 0);
            _adjacencyList.AddEdge(3, 4);
            _adjacencyList.AddEdge(4, 5);
            _adjacencyList.AddEdge(5, 6);
            _adjacencyList.AddEdge(4, 7);
            _adjacencyList.AddEdge(7, 6);
            _adjacencyList.AddEdge(7, 8);
            _adjacencyList.AddEdge(8, 9);
            _adjacencyList.AddEdge(10, 11);

            Assert.IsTrue(_depthFirstSearchForAdjacencyGraph.AreConnected(9, 0), "DFS One Failed");
            Assert.IsFalse(_depthFirstSearchForAdjacencyGraph.AreConnected(10, 0), "DFS Two Failed");


            Assert.IsTrue(_depthFirstSearchForAdjacencyList.AreConnected(9, 0), "DFS Three Failed");
            Assert.IsFalse(_depthFirstSearchForAdjacencyList.AreConnected(10, 0), "DFS Fourth Failed");
        }

        [TestMethod]
        public void Assert_Are_Connected_For_Directed_Adjacency_Graph()
        {
            /*  0 --> 1 --> 2 <-- 3
             *  ^     ^
             *  |     |
             *  5 --> 6
             *        
             *
             *  
             */

            _adjacencyDirectedGraph.AddEdge(0, 1);
            _adjacencyDirectedGraph.AddEdge(1, 2);
            _adjacencyDirectedGraph.AddEdge(3, 2);
            _adjacencyDirectedGraph.AddEdge(5, 0);
            _adjacencyDirectedGraph.AddEdge(5, 6);
            _adjacencyDirectedGraph.AddEdge(6, 1);

            Assert.IsTrue(_depthFirstSearchForDirectedAdjacencyGraph.AreConnected(0, 2));
            Assert.IsFalse(_depthFirstSearchForDirectedAdjacencyGraph.AreConnected(1, 6));

            /*  0 --> 1 --> 2 <-- 3
            *  ^     ^| 
            *  |     |* 
            *  5 --> 6
            *        ^
            *        |
            *        7 --> 8
            *
            *  
            */

            _adjacencyDirectedGraph.AddEdge(1, 6);
            _adjacencyDirectedGraph.AddEdge(7, 8);
            _adjacencyDirectedGraph.AddEdge(7, 6);

            Assert.IsFalse(_depthFirstSearchForDirectedAdjacencyGraph.AreConnected(5, 8));
            Assert.IsFalse(_depthFirstSearchForDirectedAdjacencyGraph.AreConnected(0, 8));
        }

        [TestMethod]
        public void Assert_Are_Connected_For_Directed_Adjacency_List()
        {
            /*  0 --> 1 --> 2 <-- 3
             *  ^     ^
             *  |     |
             *  5 --> 6
             *        
             *
             *  
             */

            _adjacencyDirectedList.AddEdge(0, 1);
            _adjacencyDirectedList.AddEdge(1, 2);
            _adjacencyDirectedList.AddEdge(3, 2);
            _adjacencyDirectedList.AddEdge(5, 0);
            _adjacencyDirectedList.AddEdge(5, 6);
            _adjacencyDirectedList.AddEdge(6, 1);

            Assert.IsTrue(_depthFirstSearchForDirectedAdjacencyList.AreConnected(0, 2));
            Assert.IsFalse(_depthFirstSearchForDirectedAdjacencyList.AreConnected(1, 6));

            /*  0 --> 1 --> 2 <-- 3
            *  ^     ^| 
            *  |     |* 
            *  5 --> 6
            *        ^
            *        |
            *        7 --> 8
            *
            *  
            */

            _adjacencyDirectedList.AddEdge(1, 6);
            _adjacencyDirectedList.AddEdge(7, 8);
            _adjacencyDirectedList.AddEdge(7, 6);

            Assert.IsFalse(_depthFirstSearchForDirectedAdjacencyList.AreConnected(5, 8));
            Assert.IsFalse(_depthFirstSearchForDirectedAdjacencyList.AreConnected(0, 8));
        }

        [TestMethod]
        public void Assert_Path_For_Directed_Adjacency_List()
        {
            /*  0 --> 1 --> 2 <-- 3
             *  ^     ^
             *  |     |
             *  5 --> 6
             *        
             *
             *  
             */

            _adjacencyDirectedList.AddEdge(0, 1);
            _adjacencyDirectedList.AddEdge(1, 2);
            _adjacencyDirectedList.AddEdge(3, 2);
            _adjacencyDirectedList.AddEdge(5, 0);
            _adjacencyDirectedList.AddEdge(5, 6);
            _adjacencyDirectedList.AddEdge(6, 1);

            var path = _depthFirstSearchForDirectedAdjacencyList.GetPath(5, 2);
            AssertPathContains(path, new[] {5, 6, 1, 2});

            /*  0 --> 1 --> 2 <-- 3
            *  ^     ^| 
            *  |     |* 
            *  5 --> 6
            *        ^
            *        |
            *        7 --> 8
            *
            *  
            */

            _adjacencyDirectedList.AddEdge(1, 6);
            _adjacencyDirectedList.AddEdge(7, 8);
            _adjacencyDirectedList.AddEdge(7, 6);

            Assert.IsFalse(_depthFirstSearchForDirectedAdjacencyList.AreConnected(5, 8));
            Assert.IsFalse(_depthFirstSearchForDirectedAdjacencyList.AreConnected(0, 8));
            path = _depthFirstSearchForDirectedAdjacencyList.GetPath(7, 2);
            AssertPathContains(path, new[] { 7, 6, 1, 2 });

            path = _depthFirstSearchForDirectedAdjacencyList.GetPath(8, 2);
            Assert.IsNull(path);
        }

        private void AssertPathContains(List<int> actualPath, int[] desiredPath)
        {
            Assert.AreEqual(actualPath.Count, desiredPath.Length);
            for (int i = 0; i < actualPath.Count; i++)
            {
                Assert.AreEqual(actualPath[i], desiredPath[i]);
            }
        }

        [TestCleanup]
        public void TearDown()
        {
            _adjacencyGraph = null;
            _adjacencyList = null;

            _adjacencyDirectedGraph = null;
            _adjacencyDirectedList = null;

            _depthFirstSearchForAdjacencyGraph = null;
            _depthFirstSearchForAdjacencyList = null;

            _depthFirstSearchForDirectedAdjacencyGraph = null;
            _depthFirstSearchForDirectedAdjacencyList = null;
        }
    }
}
