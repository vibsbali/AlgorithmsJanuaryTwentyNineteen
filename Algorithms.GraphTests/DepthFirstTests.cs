using System;
using System.Collections.Generic;
using Algorithms.Graphs;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Algorithms.GraphTests
{
    [TestClass]
    public class DepthFirstTests
    {
        IGraph adjacencyGraph;
        IGraph adjacencyList;

        IGraph adjacencyDirectedGraph;
        IGraph adjacencyDirectedList;

        IGraphSearch depthFirstSearchForAdjacencyGraph;
        IGraphSearch depthFirstSearchForAdjacencyList;

        IGraphSearch depthFirstSearchForDirectedAdjacencyGraph;
        IGraphSearch depthFirstSearchForDirectedAdjacencyList;

        [TestInitialize]
        public void TestSetup()
        {
            adjacencyGraph = new AdjacencyMatrix(12, false);
            adjacencyList = new AdjacencyList(12, false);

            adjacencyDirectedGraph = new AdjacencyMatrix(12, true);
            adjacencyDirectedList = new AdjacencyList(12, true);

            depthFirstSearchForAdjacencyGraph = new DepthFirstSearch(adjacencyGraph);
            depthFirstSearchForAdjacencyList = new DepthFirstSearch(adjacencyList);

            depthFirstSearchForDirectedAdjacencyGraph = new DepthFirstSearch(adjacencyDirectedGraph);
            depthFirstSearchForDirectedAdjacencyList = new DepthFirstSearch(adjacencyDirectedList);
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

            adjacencyDirectedGraph.AddEdge(0, 1);
            adjacencyDirectedGraph.AddEdge(1, 2);
            adjacencyDirectedGraph.AddEdge(3, 2);
            adjacencyDirectedGraph.AddEdge(5, 0);
            adjacencyDirectedGraph.AddEdge(5, 6);
            adjacencyDirectedGraph.AddEdge(6, 1);

            Assert.IsTrue(depthFirstSearchForDirectedAdjacencyGraph.AreConnected(0, 2));
            Assert.IsFalse(depthFirstSearchForDirectedAdjacencyGraph.AreConnected(1, 6));

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

            adjacencyDirectedGraph.AddEdge(1, 6);
            adjacencyDirectedGraph.AddEdge(7, 8);
            adjacencyDirectedGraph.AddEdge(7, 6);

            Assert.IsFalse(depthFirstSearchForDirectedAdjacencyGraph.AreConnected(5, 8));
            Assert.IsFalse(depthFirstSearchForDirectedAdjacencyGraph.AreConnected(0, 8));
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

            adjacencyDirectedList.AddEdge(0, 1);
            adjacencyDirectedList.AddEdge(1, 2);
            adjacencyDirectedList.AddEdge(3, 2);
            adjacencyDirectedList.AddEdge(5, 0);
            adjacencyDirectedList.AddEdge(5, 6);
            adjacencyDirectedList.AddEdge(6, 1);

            Assert.IsTrue(depthFirstSearchForDirectedAdjacencyList.AreConnected(0, 2));
            Assert.IsFalse(depthFirstSearchForDirectedAdjacencyList.AreConnected(1, 6));

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

            adjacencyDirectedList.AddEdge(1, 6);
            adjacencyDirectedList.AddEdge(7, 8);
            adjacencyDirectedList.AddEdge(7, 6);

            Assert.IsFalse(depthFirstSearchForDirectedAdjacencyList.AreConnected(5, 8));
            Assert.IsFalse(depthFirstSearchForDirectedAdjacencyList.AreConnected(0, 8));
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

            adjacencyDirectedList.AddEdge(0, 1);
            adjacencyDirectedList.AddEdge(1, 2);
            adjacencyDirectedList.AddEdge(3, 2);
            adjacencyDirectedList.AddEdge(5, 0);
            adjacencyDirectedList.AddEdge(5, 6);
            adjacencyDirectedList.AddEdge(6, 1);

            var path = depthFirstSearchForDirectedAdjacencyList.GetPath(5, 2);
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

            adjacencyDirectedList.AddEdge(1, 6);
            adjacencyDirectedList.AddEdge(7, 8);
            adjacencyDirectedList.AddEdge(7, 6);

            Assert.IsFalse(depthFirstSearchForDirectedAdjacencyList.AreConnected(5, 8));
            Assert.IsFalse(depthFirstSearchForDirectedAdjacencyList.AreConnected(0, 8));
            path = depthFirstSearchForDirectedAdjacencyList.GetPath(7, 2);
            AssertPathContains(path, new[] { 7, 6, 1, 2 });

            path = depthFirstSearchForDirectedAdjacencyList.GetPath(8, 2);
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
    }
}
