using System.Collections.Generic;
using Algorithms.Graphs;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Algorithms.GraphTests
{
    [TestClass]
    public class BreadthFirstTests
    {
        private IGraph _adjacencyMatrix;
        IGraph _adjacencyList;
        
        IGraphSearch _breadthFirstSearchForAdjacencyMatrix;
        IGraphSearch _breadthFirstSearchForAdjacencyList;

        [TestInitialize]
        public void TestSetup()
        {
            _adjacencyMatrix = new AdjacencyMatrix(12, false);
            _adjacencyList = new AdjacencyList(12, false);

            _breadthFirstSearchForAdjacencyMatrix = new BreadthFirstSearch(_adjacencyMatrix);
            _breadthFirstSearchForAdjacencyList = new BreadthFirstSearch(_adjacencyList);
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

            _adjacencyMatrix.AddEdge(1, 2);
            _adjacencyMatrix.AddEdge(1, 3);
            _adjacencyMatrix.AddEdge(3, 0);
            _adjacencyMatrix.AddEdge(3, 4);
            _adjacencyMatrix.AddEdge(4, 5);
            _adjacencyMatrix.AddEdge(5, 6);
            _adjacencyMatrix.AddEdge(4, 7);
            _adjacencyMatrix.AddEdge(7, 6);
            _adjacencyMatrix.AddEdge(7, 8);
            _adjacencyMatrix.AddEdge(8, 9);
            _adjacencyMatrix.AddEdge(10, 11);

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

            Assert.IsTrue(_breadthFirstSearchForAdjacencyMatrix.AreConnected(9, 0), "BFS One Failed");
            Assert.IsFalse(_breadthFirstSearchForAdjacencyMatrix.AreConnected(10, 0), "BFS Two Failed");

            Assert.IsTrue(_breadthFirstSearchForAdjacencyList.AreConnected(9, 0), "BFS Three Failed");
            Assert.IsFalse(_breadthFirstSearchForAdjacencyList.AreConnected(10, 0), "BFS Fourth Failed");

            _adjacencyMatrix.AddEdge(10, 8);
            _adjacencyList.AddEdge(10, 8);

            Assert.IsTrue(_breadthFirstSearchForAdjacencyMatrix.AreConnected(10, 0), "BFS Fifth Failed");
            Assert.IsTrue(_breadthFirstSearchForAdjacencyList.AreConnected(10, 0), "BFS sixth Failed");
        }

        [TestMethod]
        public void Assert_Path_Exists()
        {
            /*  1--2
                |
                3--0--8--9
                |        |
                4--5     |
                |  |     |
                7--6----10                            

             */

            _adjacencyMatrix.AddEdge(1, 2);
            _adjacencyMatrix.AddEdge(1, 3);
            _adjacencyMatrix.AddEdge(3, 0);
            _adjacencyMatrix.AddEdge(3, 4);
            _adjacencyMatrix.AddEdge(4, 5);
            _adjacencyMatrix.AddEdge(5, 6);
            _adjacencyMatrix.AddEdge(4, 7);
            _adjacencyMatrix.AddEdge(7, 6);
            _adjacencyMatrix.AddEdge(0, 8);
            _adjacencyMatrix.AddEdge(8, 9);
            _adjacencyMatrix.AddEdge(6, 10);
            _adjacencyMatrix.AddEdge(10, 9);

            /* -------------------------------*/

            _adjacencyList.AddEdge(1, 2);
            _adjacencyList.AddEdge(1, 3);
            _adjacencyList.AddEdge(3, 0);
            _adjacencyList.AddEdge(3, 4);
            _adjacencyList.AddEdge(4, 5);
            _adjacencyList.AddEdge(5, 6);
            _adjacencyList.AddEdge(4, 7);
            _adjacencyList.AddEdge(7, 6);
            _adjacencyList.AddEdge(0, 8);
            _adjacencyList.AddEdge(8, 9);
            _adjacencyList.AddEdge(6, 10);
            _adjacencyList.AddEdge(10, 9);

            var path = _breadthFirstSearchForAdjacencyList.GetPath(7, 9);
            AssertPathContains(path, new []{ 7, 6, 10, 9});

            path = _breadthFirstSearchForAdjacencyMatrix.GetPath(7, 9);
            AssertPathContains(path, new []{ 7, 6, 10, 9});

            path = _breadthFirstSearchForAdjacencyList.GetPath(5, 0);
            AssertPathContains(path, new[] { 5, 4, 3, 0 });

            path = _breadthFirstSearchForAdjacencyMatrix.GetPath(5, 0);
            AssertPathContains(path, new[] { 5, 4, 3, 0 });

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
