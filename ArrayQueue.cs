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

        public void Enqueue(T data)
        {
            if (!IsFull)
            {
                items[last++] = data;                

                if (last == items.Length)
                {
                    last = 0;
                }

                Count++;
            }
            else
            {
                throw new Exception("Queue overflow.");
            }
        }

        public T Dequeue()
        {
            if (!IsEmpty)
            {
                T result = items[first];

                items[first++] = default(T);

                if (first == items.Length)
                {
                    first = 0;
                }

                Count--;

                return result;
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
                return items[first];
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
            for (int i = first; i < last; i++)
            {
                yield return items[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
