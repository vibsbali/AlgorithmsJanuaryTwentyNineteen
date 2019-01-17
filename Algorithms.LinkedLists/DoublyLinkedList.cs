using System;
using System.Collections;
using System.Collections.Generic;

namespace Algorithms.LinkedLists
{
    public class DoublyLinkedList<T> : ICollection<T>
        where T : IComparable<T>
    {
        internal class Node
        {
            public Node(T value)
            {
                Value = value;
            }

            internal T Value { get; private set; }
            internal Node Next { get; set; }
            internal Node Previous { get; set; }
        }


        internal Node Head { get; set; }
        internal Node Tail { get; set; }

        public void AddFirst(T value)
        {
            var nodeToAdd = new Node(value);
            if (Head == null)
            {
                Head = Tail = null;
            }
            else
            {
                Head.Previous = nodeToAdd;
                nodeToAdd.Next = Head;
                Head = nodeToAdd;
            }

            ++Count;
        }

        public void AddLast(T value)
        {
            var nodeToAdd = new Node(value);
            if (Tail == null)
            {
                Head = Tail = nodeToAdd;
            }
            else
            {
                Tail.Next = nodeToAdd;
                nodeToAdd.Previous = Tail;
                Tail = nodeToAdd;
            }

            ++Count;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var current = Head;
            while(current != null)
            {
                yield return current.Value;
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Add(T item)
        {
            AddLast(item);
        }

        public void Clear()
        {
            Head = Tail = null;
            Count = 0;
        }

        public bool Contains(T item)
        {
            var current = Head;
            while (current != null)
            {
                if (current.Value.CompareTo(item) == 0)
                {
                    return true;
                }

                current = current.Next;
            }

            return false;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            var current = Head;
            while (current != null)
            {
                array[arrayIndex++] = current.Value;
                current = current.Next;
            }
        }

        public bool Remove(T item)
        {
            var current = Head;
            while (current != null)
            {
                //we have a match
                if (current.Value.CompareTo(item) == 0)
                {
                    //We are at Head
                    if (current.Previous == null)
                    {
                        if (current.Next == null)
                        {
                            Clear();
                            return true;
                        }

                        Head = current.Next;
                        current.Previous = null;
                    }
                    else if (current.Next == null)
                    {
                        Tail = current.Previous;
                        Tail.Next = null;
                    }
                    else
                    {
                        current.Previous.Next = current.Next;
                        current.Next.Previous = current.Previous;
                    }

                    --Count;
                    return true;
                }


                current = current.Next;
            }

            return false;
        }

        public int Count { get; private set; }
        public bool IsReadOnly => false;
    }
}
