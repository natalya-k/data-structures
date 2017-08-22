using System;

namespace DataStructures
{
    static class Test
    {
        public static void TestLinkedList()
        {
            SinglyLinkedList<int> list = new SinglyLinkedList<int>();

            list.AddLast(2);

            list.AddLast(3);
            list.AddLast(4);

            list.AddFirst(1);
            list.AddFirst(0);
            list.AddFirst(7);

            list.AddLast(5);
            list.AddLast(5);
            list.AddLast(6);

            list.Print();

            list.Remove(7);
            list.Remove(5);
            list.Remove(100);

            list.Print();

            Console.WriteLine();
            Console.WriteLine("Count = {0}", list.Count);
            Console.WriteLine();

            list.Reverse();
            list.Print();
        }

        public static void TestStack()
        {
            ArrayStack<int> stack = new ArrayStack<int>(4);
            //LinkedListStack<int> stack = new LinkedListStack<int>();

            try
            {
                stack.Peek();
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine();
            }

            stack.Push(0);
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);

            try
            {
                stack.Push(4);
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine();
            }

            stack.Print();

            Console.WriteLine();
            Console.WriteLine("Count = {0}", stack.Count);

            int peek = stack.Peek();
            Console.WriteLine("The peek is {0}.", peek);

            stack.Pop();

            int popped = stack.Pop();
            Console.WriteLine("The popped value is {0}.", popped);

            Console.WriteLine();

            try
            {
                stack.Pop();
                stack.Pop();
                stack.Pop();
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine();
            }
        }

        public static void TestQueue()
        {
            try
            {
                ArrayQueue<int> queue = new ArrayQueue<int>(4);
                //LinkedListQueue<int> queue = new LinkedListQueue<int>();

                try
                {
                    queue.Peek();
                }
                catch (InvalidOperationException e)
                {
                    Console.WriteLine(e.Message);
                    Console.WriteLine();
                }

                queue.Enqueue(0);
                queue.Enqueue(1);
                queue.Enqueue(2);
                queue.Enqueue(3);

                try
                {
                    queue.Enqueue(4);
                }
                catch (InvalidOperationException e)
                {
                    Console.WriteLine(e.Message);
                    Console.WriteLine();
                }

                queue.Print();
                Console.WriteLine();

                Console.WriteLine("Count = {0}", queue.Count);

                int peek = queue.Peek();
                Console.WriteLine("The peek is {0}.", peek);

                queue.Dequeue();

                int popped = queue.Dequeue();
                Console.WriteLine("The removed value is {0}.", popped);
                Console.WriteLine();

                //in the array implementation the value will be added at the beginning of an array
                queue.Enqueue(5);
                
                queue.Print();
                Console.WriteLine();

                try
                {
                    queue.Dequeue();
                    queue.Dequeue();
                    queue.Dequeue();
                    queue.Dequeue();
                }
                catch (InvalidOperationException e)
                {
                    Console.WriteLine(e.Message);
                    Console.WriteLine();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public static void TestBinaryTree()
        {
            BinaryTree<int> tree = BinaryTree<int>.SampleTree();

            Console.WriteLine("Preorder traversal:");
            tree.PreOrderTraversal();
            Console.WriteLine();

            Console.WriteLine("Inorder traversal:");
            tree.InOrderTraversal();
            Console.WriteLine();

            Console.WriteLine("Postorder traversal:");
            tree.PostOrderTraversal();
            Console.WriteLine();

            Console.WriteLine("Left order traversal:");
            tree.LevelOrderTraversal();
            Console.WriteLine();
        }

        public static void TestBinarySearchTree()
        {
            BinarySearchTree<int> tree = new BinarySearchTree<int>();

            try
            {
                Console.WriteLine("The minimum value is {0}.", tree.Min);
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine();
            }

            tree.Add(8);
            tree.Add(4);
            tree.Add(2);
            tree.Add(3);
            tree.Add(10);
            tree.Add(6);
            tree.Add(7);

            Console.WriteLine("LEVEL ORDER TRAVERSAL");
            tree.LevelOrderTraversal();
            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("Contains 0? {0}", tree.Contains(0));
            Console.WriteLine("Contains 2? {0}", tree.Contains(2));
            Console.WriteLine("Contains 5? {0}", tree.Contains(5));
            Console.WriteLine("Contains 7? {0}", tree.Contains(7));
            Console.WriteLine("Contains 8? {0}", tree.Contains(8));
            Console.WriteLine("Contains 9? {0}", tree.Contains(9));
            Console.WriteLine("Contains 10? {0}", tree.Contains(10));

            Console.WriteLine();
            Console.WriteLine("The minimum value is {0}.", tree.Min);
            Console.WriteLine("The maximum value is {0}.", tree.Max);

            tree.Remove(4);
            Console.WriteLine();
            Console.WriteLine("The 4 node was removed.");

            Console.WriteLine();
            Console.WriteLine("LEVEL ORDER TRAVERSAL");
            tree.LevelOrderTraversal();
            Console.WriteLine();
            Console.WriteLine();
        }
    }
}
