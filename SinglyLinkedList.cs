using System;
using System.Collections;
using System.Collections.Generic;

namespace DataStructures
{
    class SinglyLinkedList<T> : IEnumerable<T>
    {
        private Node head;

        public bool IsEmpty { get { return (head == null); } }

        public int Count
        {
            get
            {
                int count = 0;

                Node current = head;

                while (current != null)
                {
                    count++;
                    current = current.Next;
                }

                return count;
            }
        }

        public void AddFirst(T key)
        {
            head = new Node(key, head);
        }        

        public void AddLast(T key)
        {
            Node node = new Node(key);

            if (IsEmpty)
            {
                head = node;
            }
            else
            {
                Node current = head;

                while (current.Next != null)
                {
                    current = current.Next;
                }

                current.Next = node;
            }
        }

        public void Remove(T key)
        {
            if (IsEmpty)
            {
                return;
            }

            if (head.Key.Equals(key))
            {
                head = head.Next;
                return;
            }

            Node current = head;

            while (current.Next != null)
            {
                if (current.Next.Key.Equals(key))
                {
                    current.Next = current.Next.Next;
                    break;
                }

                current = current.Next;
            }
        }

        public void Reverse()
        {
            Node previous = null;
            Node current = head;
            Node next;

            while (current != null)
            {
                next = current.Next;
                current.Next = previous;
                previous = current;
                current = next;
            }

            head = previous;
        }

        public void ReverseRecursively()
        {
            ReverseRecursively(head);
        }

        public void PrintReverse()
        {
            PrintReverse(head);
        }

        public void Print()
        {
            foreach (T item in this)
            {
                Console.Write("{0} ", item.ToString());
            }

            Console.WriteLine();
        }

        private void ReverseRecursively(Node current)
        {
            if (current == null || current.Next == null)
            {
                head = current;
                return;
            }

            ReverseRecursively(current.Next);

            Node next = current.Next;
            current.Next = null;
            next.Next = current;
        }

        private void PrintReverse(Node current)
        {
            if (current == null)
            {
                return;
            }

            PrintReverse(current.Next);

            Console.Write("{0} ", current.Key);
        }

        public IEnumerator<T> GetEnumerator()
        {
            Node current = head;

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
