using Algorithms.LinkedLists;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Algorithms.LinkedListTests
{
    [TestClass]
    public class DoublyLinkedListTests
    {
        private DoublyLinkedList<int> _linkedList;

        [TestInitialize]
        public void Setup()
        {
            _linkedList = new DoublyLinkedList<int>();
        }

        [TestMethod]
        public void Empty_LinkedList_Assert_Count_Zero_Head_Tail_Null()
        {
            Assert.IsTrue(_linkedList.Count == 0, "Should be zero");
            Assert.IsNull(_linkedList.Head);
            Assert.IsNull(_linkedList.Tail);
        }

        [TestMethod]
        public void Add_One_To_LinkedList_Assert_Count_One_Head_Tail_Pointing_To_Same_Object()
        {
            _linkedList.Add(0);
            Assert.IsTrue(_linkedList.Count == 1, "Should be one");
            Assert.IsNotNull(_linkedList.Head);
            Assert.IsNotNull(_linkedList.Tail);

            Assert.AreEqual(_linkedList.Head, _linkedList.Tail, "Both Head and Tail should point to one object");
        }

        [TestMethod]
        public void Add_Two_Items_To_LinkedList_Assert_Count_Two_Head_Tail_Pointing_To_Different_Object()
        {
            _linkedList.Add(0);
            _linkedList.Add(1);
            Assert.IsTrue(_linkedList.Count == 2, "Should be two");
            Assert.IsNotNull(_linkedList.Head);
            Assert.IsNotNull(_linkedList.Tail);

            Assert.AreNotEqual(_linkedList.Head, _linkedList.Tail, "Both Head and Tail should point to one object");

            Assert.IsTrue(_linkedList.Head.Value == 0);
            Assert.IsTrue(_linkedList.Tail.Value == 1);
        }

        [TestMethod]
        public void Add_Three_Items_To_LinkedList_Assert_Count_Three_Head_Tail_Pointing_To_Different_Object()
        {
            _linkedList.Add(0);
            _linkedList.Add(1);
            _linkedList.Add(2);
            Assert.IsTrue(_linkedList.Count == 3, "Should be three");
            Assert.IsNotNull(_linkedList.Head);
            Assert.IsNotNull(_linkedList.Tail);

            Assert.AreNotEqual(_linkedList.Head, _linkedList.Tail, "Both Head and Tail should point to one object");

            Assert.IsTrue(_linkedList.Head.Value == 0);
            Assert.IsTrue(_linkedList.Tail.Value == 2);
        }

        [TestCategory("Searching within Linked List")]
        [TestMethod]
        public void Add_One_To_LinkedList_Assert_Can_Find()
        {
            _linkedList.Add(0);
            var isPresent = _linkedList.Contains(0);

            Assert.IsTrue(isPresent, "Should be true");

            isPresent = _linkedList.Contains(1);
            Assert.IsFalse(isPresent, "Should not be present");
        }

        [TestCategory("Searching within Linked List")]
        [TestMethod]
        public void Add_Nothing_To_LinkedList_Assert_Cannot_Find()
        {
            var isPresent = _linkedList.Contains(0);
            Assert.IsFalse(isPresent, "Should be false");
        }

        [TestCategory("Searching within Linked List")]
        [TestMethod]
        public void Add_Three_Items_To_LinkedList_Assert_Can_Find()
        {
            _linkedList.Add(0);
            _linkedList.Add(1);
            _linkedList.Add(2);

            var isPresent = _linkedList.Contains(0);
            Assert.IsTrue(isPresent, "Should be present");
            
            isPresent = _linkedList.Contains(1);
            Assert.IsTrue(isPresent, "Should be present");

            isPresent = _linkedList.Contains(2);
            Assert.IsTrue(isPresent, "Should be present");
        }


        [TestCategory("Deleting Within Linked List")]
        [TestMethod]
        public void Add_Three_Items_To_LinkedList_Remove_Middle_Assert_Count_Of_Two_And_Head_Tail_Next_To_One_Another()
        {
            _linkedList.Add(0);
            _linkedList.Add(1);
            _linkedList.Add(2);

            _linkedList.Remove(1);

            Assert.IsTrue(_linkedList.Count == 2, "Should be 2");
            Assert.AreEqual(_linkedList.Head.Next, _linkedList.Tail, "Tail should be next to head");

            _linkedList.Add(3);
            Assert.IsTrue(_linkedList.Count == 3, "Should be 3");
            Assert.AreNotEqual(_linkedList.Head.Next, _linkedList.Tail, "Tail should not be next to head now");
        }



        [TestCleanup]
        public void TearDown()
        {
            _linkedList = null;
        }
    }
}
