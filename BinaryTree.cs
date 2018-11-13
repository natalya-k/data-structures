using System;
using System.Collections;
using System.Collections.Generic;

namespace DataStructures
{
    class BinaryTree<T> : IEnumerable<T> 
        where T : IComparable
    {
        public bool IsEmpty { get { return (Root == null); } }

        protected Node Root { get; set; }

        public BinaryTree() { }

        public BinaryTree(T rootKey)
        {
            Root = new Node(rootKey);
        }

        public static BinaryTree<int> SampleTree()
        {
            BinaryTree<int> tree = new BinaryTree<int>(1);
            tree.Root.AddLeft(2);
            tree.Root.AddRight(3);
            tree.Root.Left.AddLeft(4);
            tree.Root.Left.AddRight(5);

            return tree;
        }        

        public void PreOrderTraversal()
        {
            PreOrderTraversal(Root);
        }

        public void InOrderTraversal()
        {
            InOrderTraversal(Root);
        }        

        public void InOrderStackTraversal()
        {
            foreach (T key in this)
            {
                Console.Write("{0} ", key.ToString());
            }
        }

        public void PostOrderTraversal()
        {
            PostOrderTraversal(Root);
        }

        public void LevelOrderTraversal()
        {
            LevelOrderTraversal(Root);
        }

        public int MaxWidth()
        {
            if (IsEmpty)
            {
                return 0;
            }                

            int result = 0;

            Queue<Node> queue = new Queue<Node>();

            queue.Enqueue(Root);

            while (queue.Count > 0)
            {
                int count = queue.Count;

                if (count > result)
                {
                    result = count;
                }

                while (count > 0)
                {
                    Node current = queue.Dequeue();

                    if (current.Left != null)
                    {
                        queue.Enqueue(current.Left);
                    }

                    if (current.Right != null)
                    {
                        queue.Enqueue(current.Right);
                    }

                    count--;
                }
            }

            return result;
        }

        public int MaxHeight()
        {
            return MaxHeight(Root);
        }

        public bool IsBalanced()
        {
            int height = 0;
            return IsBalanced(Root, ref height);
        }

        public bool IsBST()
        {
            return IsBST(Root, null, null);
        }       

        private void PreOrderTraversal(Node node)
        {
            if (node == null)
            {
                return;
            }

            node.Print();

            PreOrderTraversal(node.Left);

            PreOrderTraversal(node.Right);
        }

        private void InOrderTraversal(Node node)
        {
            if (node == null)
            {
                return;
            }

            InOrderTraversal(node.Left);

            node.Print();

            InOrderTraversal(node.Right);
        }

        private void PostOrderTraversal(Node node)
        {
            if (node == null)
            {
                return;
            }

            PostOrderTraversal(node.Left);

            PostOrderTraversal(node.Right);

            node.Print();
        }

        private void LevelOrderTraversal(Node node)
        {
            if (node == null)
            {
                return;
            }

            Queue<Node> queue = new Queue<Node>();

            queue.Enqueue(node);

            while (queue.Count > 0)
            {
                Node current = queue.Dequeue();

                current.Print();

                if (current.Left != null)
                {
                    queue.Enqueue(current.Left);
                }

                if (current.Right != null)
                {
                    queue.Enqueue(current.Right);
                }
            }
        }

        private int MaxHeight(Node node)
        {
            if (node == null)
            {
                return 0;
            }

            int leftHeight = MaxHeight(node.Left);
            int rightHeight = MaxHeight(node.Right);

            int maxHeight = Math.Max(leftHeight, rightHeight);

            return maxHeight + 1;
        }

        private bool IsBalanced(Node node, ref int height)
        {
            if (node == null)
            {
                height = 0;
                return true;
            }

            int leftHeight = 0;
            int rightHeight = 0;

            bool leftBalanced = IsBalanced(node.Left, ref leftHeight);
            bool rightBalanced = IsBalanced(node.Right, ref rightHeight);

            height = (leftHeight > rightHeight ? leftHeight : rightHeight) + 1;

            if (Math.Abs(leftHeight - rightHeight) >= 2)
            {
                return false;
            }

            return true;
        }

        private bool IsBST(Node node, Node leftParent, Node rightParent)
        {
            if (node == null)
            {
                return true;
            }
            
            if (leftParent != null)
            {
                int compared = node.Key.CompareTo(leftParent.Key);

                if (compared < 0)
                {
                    return false;
                }
            }

            if (rightParent != null)
            {
                int compared = node.Key.CompareTo(rightParent.Key);

                if (compared > 0)
                {
                    return false;
                }
            }

            return 
                IsBST(node.Left, leftParent, node) && 
                IsBST(node.Right, node, rightParent);
        }

        public IEnumerator<T> GetEnumerator()
        {
            //нерекурсивная реализация inorder traversal

            if (IsEmpty)
            {
                yield return default(T);
            }

            Stack<Node> stack = new Stack<Node>();

            Node current = Root;

            bool goLeftNext = true;

            stack.Push(current);

            while (stack.Count > 0)
            {
                if (goLeftNext)
                {
                    while (current.Left != null)
                    {
                        stack.Push(current);
                        current = current.Left;
                    }
                }

                yield return current.Key;

                if (current.Right != null)
                {
                    current = current.Right;
                    goLeftNext = true;
                }
                else
                {
                    current = stack.Pop();
                    goLeftNext = false;
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        protected class Node
        {
            public Node Left { get; set; }
            public Node Right { get; set; }
            public T Key { get; private set; }

            public Node(T key = default(T), Node left = null, Node right = null)
            {
                Key = key;
                Left = left;
                Right = right;
            }

            public void AddLeft(T key)
            {
                Left = new Node(key);
            }

            public void AddRight(T key)
            {
                Right = new Node(key);
            }

            public void Print()
            {
                Console.Write("{0} ", this.ToString());
            }

            public override string ToString()
            {
                return Key.ToString();
            }
        }
    }
}
