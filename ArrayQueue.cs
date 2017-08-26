using System;
using System.Collections;
using System.Collections.Generic;

namespace DataStructures
{
    class ArrayQueue<T> : IEnumerable<T>
    {
        private T[] items;

        private int first = 0, last = 0;

        public int Count { get; private set; } = 0;
        public bool IsEmpty { get { return (Count == 0); } }
        public bool IsFull { get { return (Count == items.Length); } }

        public ArrayQueue() : this(10) { }

        public ArrayQueue(uint capacity)
        {
            items = new T[capacity];
        }

        public void Enqueue(T key)
        {
            if (IsFull)
            {
                throw new InvalidOperationException("Queue overflow.");
            }

            items[last++] = key;

            if (last == items.Length)
            {
                last = 0;
            }

            Count++;
        }

        public T Dequeue()
        {
            if (IsEmpty)
            {
                throw new InvalidOperationException("Queue underflow.");
            }
            
            T result = items[first];

            items[first++] = default(T);

            if (first == items.Length)
            {
                first = 0;
            }

            Count--;

            return result;
        }

        public T Peek()
        {
            if (IsEmpty)
            {
                throw new InvalidOperationException("The queue is empty.");
            }
            
            return items[first];            
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
            int k = first;

            for (int i = 0; i < Count; i++)
            {
                yield return items[k];

                k++;

                if (k == items.Length)
                {
                    k = 0;
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}