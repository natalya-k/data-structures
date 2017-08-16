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

        public void Enqueue(T data)
        {
            Node lastPrev = last;

            last = new Node(data);

            if (IsEmpty)
            {
                first = last;
            }
            else
            {
                lastPrev.Next = last;
            }
        }

        public T Dequeue()
        {
            if (!IsEmpty)
            {
                Node result = first;

                first = first.Next;

                if (IsEmpty)
                {
                    last = null;
                }

                return result.Data;
            }
            else
            {
                throw new Exception("Queue underflow.");
            }
        }

        public T Peek()
        {
            if (!IsEmpty)
            {
                return first.Data;
            }
            else
            {
                throw new Exception("The queue is empty.");
            }
        }

        public void Print()
        {
            foreach (T item in this)
            {
                Console.WriteLine(item.ToString());
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            Node current = first;

            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private class Node
        {
            public T Data { get; set; }
            public Node Next { get; set; }

            public Node(T data) : this(data, null) { }

            public Node(T data, Node next)
            {
                Data = data;
                Next = next;
            }
        }
    }
}
