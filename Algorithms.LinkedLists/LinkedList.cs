using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

[assembly:InternalsVisibleTo("Algorithms.LinkedListTests")]
namespace Algorithms.LinkedLists
{
    public class LinkedList<T> : ICollection<T>
        where T : IComparable<T>
    {
        internal class Node
        {
            public Node(T value)
            {
                Value = value;
            }

            internal T Value { get; }
            internal Node Next { get; set; }
        }

        internal Node Head { get; private set; }
        internal Node Tail { get; private set; }

        public IEnumerator<T> GetEnumerator()
        {
            var current = Head;
            while (current != null)
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
            var node = new Node(item);
            if (Head == null)
            {
                Head = Tail = node;
            }
            else
            {
                Tail.Next = node;
                Tail = node;
            }

            ++Count;
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
            Node previous = null;
            while (current != null)
            {
                if (current.Value.CompareTo(item) == 0)
                {
                    //We are at head
                    if (previous == null)
                    {
                        if (current.Next == null)
                        {
                            Clear();
                            return true;
                        }

                        if (current.Next == Tail)
                        {
                            Head = Tail;
                        }
                        else
                        {
                            Head = current.Next;
                        }
                    }
                    //We are at tail
                    else if (current.Next == null)
                    {
                        Tail = previous;
                    }
                    else
                    {
                        current = current.Next;
                        previous.Next = current;
                    }

                    --Count;
                    return true;
                }

                previous = current;
                current = current.Next;
            }

            return false;
        }

        public int Count { get; private set; }
        public bool IsReadOnly => false;
    }
}
