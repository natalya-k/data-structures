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

            Console.WriteLine("Current list is");
            list.Print();
            Console.WriteLine();

            Console.WriteLine("Remove first 7, 5, 100 values.");
            Console.WriteLine();
            list.Remove(7);
            list.Remove(5);
            list.Remove(100);

            Console.WriteLine("Current list is");
            list.Print();
            Console.WriteLine();

            Console.WriteLine("Count = {0}", list.Count);
            Console.WriteLine();

            Console.WriteLine("Reversed list is");
            list.Reverse();
            list.Print();
            Console.WriteLine();

            Console.WriteLine("Recursively reversed list is");
            list.ReverseRecursively();
            list.Print();
        }

        public static void TestStack()
        {
            //ArrayStack<int> stack = new ArrayStack<int>(4);
            LinkedListStack<int> stack = new LinkedListStack<int>();

            try
            {
                Console.WriteLine("Try to return the value at the top.");
                stack.Peek();
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine();
            }

            Console.WriteLine("Add 4 items.");
            Console.WriteLine();

            stack.Push(0);
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);

            try
            {
                Console.WriteLine("Try to add one more item.");
                stack.Push(4);
                Console.WriteLine("Success!");
                Console.WriteLine();
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine();
            }

            Console.WriteLine("Current stack is");
            stack.Print();
            Console.WriteLine();

            Console.WriteLine("Count = {0}", stack.Count);
            Console.WriteLine("The peek is {0}.", stack.Peek());
            Console.WriteLine("The 1st popped value is {0}.", stack.Pop());
            Console.WriteLine("The 2nd popped value is {0}.", stack.Pop());
            Console.WriteLine();

            try
            {
                Console.WriteLine("Try to pop last 4 values.");
                stack.Pop();
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
                    Console.WriteLine("Try to return the value at the beggining.");
                    queue.Peek();
                }
                catch (InvalidOperationException e)
                {
                    Console.WriteLine(e.Message);
                    Console.WriteLine();
                }

                Console.WriteLine("Add 4 items.");
                Console.WriteLine();

                queue.Enqueue(0);
                queue.Enqueue(1);
                queue.Enqueue(2);
                queue.Enqueue(3);

                try
                {
                    Console.WriteLine("Try to add one more item.");
                    queue.Enqueue(4);
                    Console.WriteLine("Success!");
                    Console.WriteLine();
                }
                catch (InvalidOperationException e)
                {
                    Console.WriteLine(e.Message);
                    Console.WriteLine();
                }

                Console.WriteLine("Current queue is");
                queue.Print();
                Console.WriteLine();

                Console.WriteLine("Count = {0}", queue.Count);

                Console.WriteLine("The peek is {0}.", queue.Peek());

                Console.WriteLine("The 1st removed value is {0}.", queue.Dequeue());
                Console.WriteLine("The 2nd removed value is {0}.", queue.Dequeue());
                Console.WriteLine();

                Console.WriteLine("Current queue is");
                queue.Print();
                Console.WriteLine();

                Console.WriteLine("Add one more item.");
                Console.WriteLine("In the array implementation the value will be added at the beginning.");
                Console.WriteLine();
                queue.Enqueue(5);

                Console.WriteLine("Current queue is");
                queue.Print();
                Console.WriteLine();

                try
                {
                    Console.WriteLine("Try to return first 5 values.");
                    queue.Dequeue();
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
            //BinaryTree<int> tree = BinaryTree<int>.SampleTree();
            BinaryTree<int> tree = BinaryTree<int>.SampleBSTree();

            Console.WriteLine("Preorder traversal:");
            tree.PreOrderTraversal();
            Console.WriteLine();

            Console.WriteLine("Inorder traversal:");
            tree.InOrderTraversal();
            Console.WriteLine();

            Console.WriteLine("Inorder stack traversal:");
            tree.InOrderStackTraversal();
            Console.WriteLine();

            Console.WriteLine("Postorder traversal:");
            tree.PostOrderTraversal();
            Console.WriteLine();

            Console.WriteLine("Left order traversal:");
            tree.LevelOrderTraversal();
            Console.WriteLine();

            Console.WriteLine();
            Console.WriteLine("Max width = {0}", tree.MaxWidth());
            Console.WriteLine("Max height = {0}", tree.MaxHeight());

            Console.WriteLine();
            Console.WriteLine("Balanced = {0}", tree.IsBalanced());
            Console.WriteLine("BST = {0}", tree.IsBST());
        }

        public static void TestBinarySearchTree()
        {
            BinarySearchTree<int> tree = new BinarySearchTree<int>();

            try
            {
                Console.WriteLine("Try to return the minimum value.");
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
        }

        public static void TestDynamicTable()
        {
            DynamicTable table = new DynamicTable();

            for (int i = 0; i < 10; i++)
            {
                table.Add(i + 1);
            }
        }
    }
}
