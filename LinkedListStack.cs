using System;
using System.Collections;
using System.Collections.Generic;

namespace DataStructures
{
    class LinkedListStack<T> : IEnumerable<T>
    {
        private Node top = null;

        public bool IsEmpty { get { return (top == null); } }

        public int Count
        {
            get
            {
                int count = 0;

                Node current = top;

                while (current != null)
                {
                    count++;
                    current = current.Next;
                }

                return count;
            }
        }

        public void Push(T data)
        {
            Node node = new Node(data, top);
            top = node;
        }

        public T Pop()
        {
            if (IsEmpty)
            {
                throw new InvalidOperationException("The stack is empty.");
            }

            Node result = top;
            top = top.Next;
            return result.Data;
        }

        public T Peek()
        {
            if (IsEmpty)
            {
                throw new InvalidOperationException("The stack is empty.");
            }

            return top.Data;
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
            Node current = top;

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

            public Node(T data) : this (data, null) { }

            public Node(T data, Node next)
            {
                Data = data;
                Next = next;
            }
        }
    }
}
