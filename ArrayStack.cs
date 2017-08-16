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

        public ArrayStack() : this(10) { }

        public ArrayStack(uint capacity)
        {
            items = new T[capacity];
        }

        public void Push(T data)
        {
            if (!IsFull)
            {
                items[Count++] = data;
            }
            else
            {
                throw new Exception("Stack overflow.");
            }
        }

        public T Pop()
        {
            if (!IsEmpty)
            {
                T result = items[--Count];
                items[Count] = default(T);
                return result;
            }
            else
            {
                throw new Exception("Stack underflow.");
            }
        }

        public T Peek()
        {
            if (!IsEmpty)
            {
                return items[Count - 1];
            }
            else
            {
                throw new Exception("The stack is empty.");
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
