using System;
using System.Collections;
using System.Collections.Generic;

namespace DataStructures
{
    class ArrayStack<T> : IEnumerable<T>
    {
        private T[] items;

        public int Count { get; private set; } = 0;
        public bool IsEmpty { get { return (Count == 0); } }
        public bool IsFull { get { return (Count == items.Length); } }

        public ArrayStack(uint capacity = 10)
        {
            items = new T[capacity];
        }

        public void Push(T key)
        {
            if (IsFull)
            {
                throw new InvalidOperationException("Stack overflow.");
            }

            items[Count++] = key;
        }

        public T Pop()
        {
            if (IsEmpty)
            {
                throw new InvalidOperationException("Stack underflow.");
            }

            T result = items[--Count];
            items[Count] = default(T);
            return result;
        }

        public T Peek()
        {
            if (IsEmpty)
            {
                throw new InvalidOperationException("The stack is empty.");
            }

            return items[Count - 1];
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
            for (int i = Count - 1; i >= 0; i--)
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
