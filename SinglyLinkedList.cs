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

        public void AddFirst(T data)
        {
            Node node = new Node(data);
            node.Next = head;
            head = node;
        }        

        public void AddLast(T data)
        {
            Node node = new Node(data);

            if (head == null)
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

        public void Remove(T data)
        {
            if (head == null)
            {
                return;
            }

            if (head.Data.Equals(data))
            {
                head = head.Next;
                return;
            }

            Node current = head;

            while (current.Next != null)
            {
                if (current.Next.Data.Equals(data))
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
            Node current = head;

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
            public T Data { get; private set; }
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
