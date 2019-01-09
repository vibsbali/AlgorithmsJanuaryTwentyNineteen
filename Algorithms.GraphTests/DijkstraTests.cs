using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Algorithms.Graphs;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Algorithms.GraphTests
{
    [TestClass]
    public class DijkstraTests
    {
        IGraph _adjacencyGraph;
        IGraph _adjacencyList;

        IGraph _adjacencyDirectedGraph;
        IGraph _adjacencyDirectedList;

        IGraphSearch _dijkstraSearchForAdjacencyGraph;
        IGraphSearch _dijkstraSearchForAdjacencyList;

        IGraphSearch _dijkstraSearchForDirectedAdjacencyGraph;
        IGraphSearch _dijkstraSearchForDirectedAdjacencyList;

        [TestInitialize]
        public void TestSetup()
        {
            _adjacencyGraph = new AdjacencyMatrix(12, false);
            _adjacencyList = new AdjacencyList(12, false);

            _adjacencyDirectedGraph = new AdjacencyMatrix(12, true);
            _adjacencyDirectedList = new AdjacencyList(12, true);

            _dijkstraSearchForAdjacencyGraph = new DijkstraGraphSearch(_adjacencyGraph);
            _dijkstraSearchForAdjacencyList = new DijkstraGraphSearch(_adjacencyList);

            _dijkstraSearchForDirectedAdjacencyGraph = new DijkstraGraphSearch(_adjacencyDirectedGraph);
            _dijkstraSearchForDirectedAdjacencyList = new DijkstraGraphSearch(_adjacencyDirectedList);
        }

        [TestMethod]
        public void Assert_Path_For_UnDirected_Adjacency_List_And_Undirected_Adjacency_Matrix_Graph()
        {
            /*  1-w4w-2
                |     |
                w     w
                5     5
                w     w
                |     |
                3-w2w-0
                |     |
                w     w
                0     2
                w     w
                |     |
                4-w2w-5                

             */

            _adjacencyGraph.AddEdge(1, 2, 4);
            _adjacencyGraph.AddEdge(1, 3, 5);
            _adjacencyGraph.AddEdge(3, 0, 2);
            _adjacencyGraph.AddEdge(2, 0, 5);
            _adjacencyGraph.AddEdge(3, 4, 0);
            _adjacencyGraph.AddEdge(4, 5, 2);
            _adjacencyGraph.AddEdge(0, 5, 2);

            /* -------------------------------*/

            _adjacencyList.AddEdge(1, 2, 4);
            _adjacencyList.AddEdge(1, 3, 5);
            _adjacencyList.AddEdge(3, 0, 2);
            _adjacencyList.AddEdge(2, 0, 5);
            _adjacencyList.AddEdge(3, 4, 0);
            _adjacencyList.AddEdge(4, 5, 2);
            _adjacencyList.AddEdge(0, 5, 2);

            var path = _dijkstraSearchForAdjacencyGraph.GetPath(1, 0);
            AssertPathContains(new[] { 1, 3, 0 }, path);

            path = _dijkstraSearchForAdjacencyList.GetPath(1, 0);
            AssertPathContains(new[] { 1, 3, 0 }, path);


            path = _dijkstraSearchForAdjacencyGraph.GetPath(1, 5);
            AssertPathContains(new[] { 1, 3, 4, 5 }, path);

            path = _dijkstraSearchForAdjacencyList.GetPath(1, 5);
            AssertPathContains(new[] { 1, 3, 4, 5 }, path);
        }

        [TestMethod]
        public void Assert_Path_Rigourous()
        {
            /* 

            https://www.geeksforgeeks.org/printing-paths-dijkstras-shortest-path-algorithm/
                    
             */

            _adjacencyGraph.AddEdge(0, 1, 4);
            _adjacencyGraph.AddEdge(0, 7, 8);
            _adjacencyGraph.AddEdge(1, 7, 11);
            _adjacencyGraph.AddEdge(1, 2, 8);
            _adjacencyGraph.AddEdge(2, 8, 2);
            _adjacencyGraph.AddEdge(7, 8, 7);
            _adjacencyGraph.AddEdge(8, 6, 6);
            _adjacencyGraph.AddEdge(7, 6, 1);
            _adjacencyGraph.AddEdge(6, 5, 2);
            _adjacencyGraph.AddEdge(2, 5, 4);
            _adjacencyGraph.AddEdge(2, 3, 7);
            _adjacencyGraph.AddEdge(3, 4, 9);
            _adjacencyGraph.AddEdge(3, 5, 14);
            _adjacencyGraph.AddEdge(5, 4, 10);

            /* -------------------------------*/

            _adjacencyList.AddEdge(0, 1, 4);
            _adjacencyList.AddEdge(0, 7, 8);
            _adjacencyList.AddEdge(1, 7, 11);
            _adjacencyList.AddEdge(1, 2, 8);
            _adjacencyList.AddEdge(2, 8, 2);
            _adjacencyList.AddEdge(7, 8, 7);
            _adjacencyList.AddEdge(8, 6, 6);
            _adjacencyList.AddEdge(7, 6, 1);
            _adjacencyList.AddEdge(6, 5, 2);
            _adjacencyList.AddEdge(2, 5, 4);
            _adjacencyList.AddEdge(2, 3, 7);
            _adjacencyList.AddEdge(3, 4, 9);
            _adjacencyList.AddEdge(3, 5, 14);
            _adjacencyList.AddEdge(5, 4, 10);

            var path = _dijkstraSearchForAdjacencyGraph.GetPath(0, 1);
            AssertPathContains(new[] { 0, 1 }, path);

            path = _dijkstraSearchForAdjacencyList.GetPath(0, 1);
            AssertPathContains(new[] { 0, 1 }, path);

            path = _dijkstraSearchForAdjacencyGraph.GetPath(0, 7);
            AssertPathContains(new[] { 0, 7 }, path);

            path = _dijkstraSearchForAdjacencyList.GetPath(0, 7);
            AssertPathContains(new[] { 0, 7 }, path);

            path = _dijkstraSearchForAdjacencyGraph.GetPath(0, 2);
            AssertPathContains(new[] { 0, 1, 2 }, path);

            path = _dijkstraSearchForAdjacencyList.GetPath(0, 2);
            AssertPathContains(new[] { 0, 1, 2 }, path);

            path = _dijkstraSearchForAdjacencyGraph.GetPath(0, 4);
            AssertPathContains(new[] { 0, 7, 6, 5, 4 }, path);

            path = _dijkstraSearchForAdjacencyList.GetPath(0, 4);
            AssertPathContains(new[] { 0, 7, 6, 5, 4 }, path);

            path = _dijkstraSearchForAdjacencyGraph.GetPath(0, 3);
            AssertPathContains(new[] { 0, 1, 2, 3 }, path);

            path = _dijkstraSearchForAdjacencyList.GetPath(0, 3);
            AssertPathContains(new[] { 0, 1, 2, 3 }, path);

        }



        [TestCleanup]
        public void TearDown()
        {
            _adjacencyGraph = null;
            _adjacencyList = null;

            _adjacencyDirectedGraph = null;
            _adjacencyDirectedList = null;

            _dijkstraSearchForAdjacencyGraph = null;
            _dijkstraSearchForAdjacencyList = null;

            _dijkstraSearchForDirectedAdjacencyGraph = null;
            _dijkstraSearchForDirectedAdjacencyList = null;
        }

        private void AssertPathContains(int[] desiredPath, List<int> actualPath)
        {
            Assert.AreEqual(actualPath.Count, desiredPath.Length);
            for (int i = 0; i < actualPath.Count; i++)
            {
                Assert.AreEqual(actualPath[i], desiredPath[i]);
            }
        }
    }
}
