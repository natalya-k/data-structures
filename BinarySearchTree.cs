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

        private Node AddTo(Node node, T key)
        {
            if (node == null)
            {
                return new Node(key);
            }

            if (key.CompareTo(node.Key) < 0)
            {
                node.Left = AddTo(node.Left, key);
            }
            else
            {
                node.Right = AddTo(node.Right, key);
            }

            return node;
        }

        private Node RemoveAt(Node node, T key)
        {
            //базовый случай
            if (node == null)
            {
                return node;
            }

            int compared = node.Key.CompareTo(key);

            if (compared > 0)
            {
                //если искомый ключ меньше корневого ключа, 
                //то нужный узел находится в левом поддереве
                node.Left = RemoveAt(node.Left, key);
            }
            else if (compared < 0)
            {
                //если искомый ключ больше корневого ключа, 
                //то нужный узел находится в правом поддереве
                node.Right = RemoveAt(node.Right, key);
            }
            else
            {
                //нужный узел нашелся, его надо удалить

                //узел имеет только одного потомка

                if (node.Left == null)
                {
                    return node.Right;
                }
                else if (node.Right == null)
                {
                    return node.Left;
                }

                //узел имеет двух потомков

                //в правом поддереве нужно найти узел с наименьшим ключом

                Node minNode = MinNode(node.Right);

                //найденный узел нужно удалить из прежней позиции
                //и поставить на место текущего узла

                node.Right = RemoveAt(node.Right, minNode.Key);

                node.Key = minNode.Key;
            }

            return node;
        }

        private Node Search(T key)
        {
            Node current = Root;

            while (current != null)
            {
                int compared = current.Key.CompareTo(key);

                if (compared > 0)
                {
                    current = current.Left;
                }
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

        private Node SearchAt(Node node, T key)
        {
            if (node == null)
            {
                return node;
            }

            int compared = node.Key.CompareTo(key);

            if (compared == 0)
            {
                return node;
            }
            else if (compared > 0)
            {
                return SearchAt(node.Left, key);
            }
            else
            {
                return SearchAt(node.Right, key);
            }
        }

        private Node MinNode(Node node)
        {
            if (IsEmpty)
            {
                throw new Exception("The tree is empty.");
            }

            Node current = node;

            while (current.Left != null)
            {
                current = current.Left;
            }

            return current;
        }

        private Node MaxNode(Node node)
        {
            if (IsEmpty)
            {
                throw new Exception("The tree is empty.");
            }

            Node current = node;

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
                int compared = node.Key.CompareTo(root.Key);

                if (compared > 0)
                {
                    root = root.Right;
                }
                else if (compared < 0)
                {
                    successor = root;
                    root = root.Left;
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
                int compared = node.Key.CompareTo(root.Key);

                if (compared > 0)
                {
                    predecessor = root;
                    root = root.Right;
                }
                else if (compared < 0)
                {
                    root = root.Left;
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