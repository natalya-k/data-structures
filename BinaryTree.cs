using System;
using System.Collections.Generic;

namespace DataStructures
{
    class BinaryTree<T>        
    {
        public bool IsEmpty { get { return (Root == null); } }

        protected Node Root { get; set; }        

        public BinaryTree() { }

        public BinaryTree(T rootData)
        {
            Root = new Node(rootData);
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

        public void PostOrderTraversal()
        {
            PostOrderTraversal(Root);
        }

        public void LevelOrderTraversal()
        {
            LevelOrderTraversal(Root);
        }

        protected virtual void PrintNode(Node node)
        {
            Console.Write("{0} ", node.ToString());
        }

        private void PreOrderTraversal(Node node)
        {
            if (node == null)
            {
                return;
            }

            PrintNode(node);

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

            PrintNode(node);            

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

            PrintNode(node);
        }

        private void LevelOrderTraversal(Node node)
        {
            Queue<Node> queue = new Queue<Node>();

            queue.Enqueue(node);

            while (queue.Count > 0)
            {
                Node current = queue.Dequeue();

                PrintNode(current);

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

        protected class Node
        {
            public Node Left { get; set; }
            public Node Right { get; set; }
            public T Data { get; set; }

            public Node() : this(default(T), null, null) { }

            public Node(T data) : this(data, null, null) { }

            public Node(T data, Node left, Node right)
            {
                Data = data;
                Left = left;
                Right = right;
            }

            public void AddLeft(T data)
            {
                Left = new Node(data);
            }

            public void AddRight(T data)
            {
                Right = new Node(data);
            }

            public override string ToString()
            {
                return Data.ToString();
            }
        }
    }
}