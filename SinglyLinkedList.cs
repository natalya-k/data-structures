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

        public void AddFirst(Node node)
        {
            node.Next = head;
            head = node;
        }

        public void AddFirst(T data)
        {
            AddFirst(new Node(data));
        }        

        public void AddLast(Node node)
        {
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

        public void AddLast(T data)
        {
            AddLast(new Node(data));
        }

        public void AddAfter(Node previous, Node node)
        {
            node.Next = previous.Next;
            previous.Next = node;
        }

        public void AddAfter(Node previous, T data)
        {
            AddAfter(previous, new Node(data));
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
                Console.WriteLine(item.ToString());
            }
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

        public class Node
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
