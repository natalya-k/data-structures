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

        public void Push(T key)
        {
            top = new Node(key, top);
        }

        public T Pop()
        {
            if (IsEmpty)
            {
                throw new InvalidOperationException("The stack is empty.");
            }

            T result = top.Key;
            top = top.Next;
            return result;
        }

        public T Peek()
        {
            if (IsEmpty)
            {
                throw new InvalidOperationException("The stack is empty.");
            }

            return top.Key;
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

            public Node(T key) : this (key, null) { }

            public Node(T key, Node next)
            {
                Key = key;
                Next = next;
            }
        }
    }
}