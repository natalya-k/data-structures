using System;

namespace DataStructures
{
    class BinarySearchTree<T> : BinaryTree<T> 
        where T : IComparable
    {
        public T Min
        {
            get
            {
                if (IsEmpty)
                {
                    throw new InvalidOperationException("The tree is empty.");
                }

                return MinNode(Root).Key;
            }
        }

        public T Max
        {
            get
            {
                if (IsEmpty)
                {
                    throw new InvalidOperationException("The tree is empty.");
                }

                return MaxNode(Root).Key;
            }
        }

        public void Add(T key)
        {
            if (Root == null)
            {
                Root = new Node(key);                
            }
            else
            {
                AddTo(Root, key);
            }
        }

        public void Remove(T key)
        {
            Root = RemoveAt(Root, key);
        }        

        public bool Contains(T key)
        {
            return Search(key) != null;
            //return SearchAt(Root, key) != null;
        }

        protected override void PrintNode(Node node)
        {
            Node predecessor = PredecessorNode(Root, node);

            if (predecessor != null)
            {
                Console.Write("predecessor = {0,3}; ", predecessor.ToString());
            }
            else
            {
                Console.Write("predecessor =   N; ");
            }

            Console.Write("current = {0,3}; ", node.ToString());

            Node successor = SuccessorNode(Root, node);

            if (successor != null)
            {
                Console.WriteLine("successor = {0,3};", successor.ToString());
            }
            else
            {
                Console.WriteLine("successor =   N;");
            }
        }

        private Node AddTo(Node root, T key)
        {
            if (root == null)
            {
                return new Node(key);
            }

            int compared = root.Key.CompareTo(key);

            //root.Key > key
            if (compared > 0)
            {
                root.Left = AddTo(root.Left, key);
            }
            //root.Key < key
            else if (compared < 0)
            {
                root.Right = AddTo(root.Right, key);
            }

            return root;
        }

        private Node RemoveAt(Node root, T key)
        {
            //базовый случай
            if (root == null)
            {
                return root;
            }

            int compared = root.Key.CompareTo(key);

            //root.Key > key
            if (compared > 0)
            {
                //если искомый ключ меньше корневого, 
                //то нужный узел находится в левом поддереве
                root.Left = RemoveAt(root.Left, key);
            }
            //root.Key < key
            else if (compared < 0)
            {
                //если искомый ключ больше корневого, 
                //то нужный узел находится в правом поддереве
                root.Right = RemoveAt(root.Right, key);
            }
            else
            {
                //нужный узел нашелся, его надо удалить

                //узел имеет только одного потомка

                if (root.Left == null)
                {
                    return root.Right;
                }
                else if (root.Right == null)
                {
                    return root.Left;
                }

                //узел имеет двух потомков

                //в правом поддереве нужно найти узел с наименьшим ключом

                Node minNode = MinNode(root.Right);

                //найденный узел нужно удалить из прежней позиции
                //и поставить на место текущего узла

                Node right = RemoveAt(root.Right, minNode.Key);
                root = new Node(minNode.Key, root.Left, right);
            }

            return root;
        }

        private Node Search(T key)
        {
            Node current = Root;

            while (current != null)
            {
                int compared = current.Key.CompareTo(key);

                //current.Key > key
                if (compared > 0)
                {
                    current = current.Left;
                }
                //current.Key < key
                else if (compared < 0)
                {
                    current = current.Right;
                }
                else
                {
                    break;
                }
            }

            return current;
        }

        private Node SearchAt(Node root, T key)
        {
            if (root == null)
            {
                return root;
            }

            int compared = root.Key.CompareTo(key);

            if (compared == 0)
            {
                return root;
            }
            //root.Key > key
            else if (compared > 0)
            {
                return SearchAt(root.Left, key);
            }
            //root.Key < key
            else
            {
                return SearchAt(root.Right, key);
            }
        }

        private Node MinNode(Node root)
        {
            if (IsEmpty)
            {
                throw new Exception("The tree is empty.");
            }

            Node current = root;

            while (current.Left != null)
            {
                current = current.Left;
            }

            return current;
        }

        private Node MaxNode(Node root)
        {
            if (IsEmpty)
            {
                throw new Exception("The tree is empty.");
            }

            Node current = root;

            while (current.Right != null)
            {
                current = current.Right;
            }

            return current;
        }

        private Node SuccessorNode(Node root, Node node)
        {
            if (IsEmpty)
            {
                throw new Exception("The tree is empty.");
            }

            if (node.Right != null)
            {
                return MinNode(node.Right);
            }

            Node successor = null;

            while (root != null)
            {
                int compared = root.Key.CompareTo(node.Key);

                //root.Key > node.Key
                if (compared > 0)
                {
                    successor = root;
                    root = root.Left;
                }
                //root.Key < node.Key
                else if (compared < 0)
                {
                    root = root.Right;
                }
                else
                {
                    break;
                }
            }

            return successor;
        }

        private Node PredecessorNode(Node root, Node node)
        {
            if (IsEmpty)
            {
                throw new Exception("The tree is empty.");
            }

            if (node.Left != null)
            {
                return MaxNode(node.Left);
            }

            Node predecessor = null;

            while (root != null)
            {
                int compared = root.Key.CompareTo(node.Key);

                //root.Key > node.Key
                if (compared > 0)
                {
                    root = root.Left;
                }
                //root.Key < node.Key
                else if (compared < 0)
                {
                    predecessor = root;
                    root = root.Right;
                }
                else
                {
                    break;
                }
            }

            return predecessor;
        }
    }
}