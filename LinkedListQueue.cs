using System;
using System.Collections;
using System.Collections.Generic;

namespace DataStructures
{
    class LinkedListQueue<T> : IEnumerable<T>
    {
        private Node first = null, last = null;

        public bool IsEmpty { get { return (first == null); } }

        public int Count
        {
            get
            {
                int count = 0;

                Node current = first;

                while (current != null)
                {
                    count++;
                    current = current.Next;
                }

                return count;
            }
        }

        public void Enqueue(T key)
        {
            Node node = new Node(key);

            if (IsEmpty)
            {
                first = node;
                last = first;
            }
            else
            {
                last.Next = node;
                last = last.Next;
            }
        }

        public T Dequeue()
        {
            if (IsEmpty)
            {
                throw new InvalidOperationException("Queue underflow.");
            }
            
            Node result = first;

            first = first.Next;

            if (IsEmpty)
            {
                last = null;
            }

            return result.Key;
        }

        public T Peek()
        {
            if (IsEmpty)
            {
                throw new InvalidOperationException("The queue is empty.");
            }

            return first.Key;
        }

        public void Print()
        {
            foreach (T item in this)
            {
                Console.Write("{0} ", item.ToString());
            }

            Console.WriteLine();
        }

        public IEnumerator<T> GetEnumerator()
        {
            Node current = first;

            while (current != null)
            {
                yield return current.Key;
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private class Node
        {
            public T Key { get; private set; }
            public Node Next { get; set; }

            public Node(T key) : this(key, null) { }

            public Node(T key, Node next)
            {
                Key = key;
                Next = next;
            }
        }
    }
}