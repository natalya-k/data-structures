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

                return MinNode(Root).Data;
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

                return MaxNode(Root).Data;
            }
        }

        public void Add(T data)
        {
            if (Root == null)
            {
                Root = new Node(data);                
            }
            else
            {
                AddTo(Root, data);
            }
        }

        public void Remove(T data)
        {
            Root = RemoveAt(Root, data);
        }        

        public bool Contains(T data)
        {
            return Search(data) != null;
            //return SearchAt(Root, data) != null;
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

        private Node AddTo(Node node, T data)
        {
            if (node == null)
            {
                return new Node(data);
            }

            if (data.CompareTo(node.Data) < 0)
            {
                node.Left = AddTo(node.Left, data);
            }
            else
            {
                node.Right = AddTo(node.Right, data);
            }

            return node;
        }

        private Node RemoveAt(Node root, T data)
        {
            //базовый случай
            if (root == null)
            {
                return root;
            }

            int compared = root.Data.CompareTo(data);

            if (compared > 0)
            {
                //если искомый ключ меньше корневого ключа, 
                //то нужный узел находится в левом поддереве
                root.Left = RemoveAt(root.Left, data);
            }
            else if (compared < 0)
            {
                //если искомый ключ больше корневого ключа, 
                //то нужный узел находится в правом поддереве
                root.Right = RemoveAt(root.Right, data);
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

                root.Right = RemoveAt(root.Right, minNode.Data);

                root.Data = minNode.Data;
            }

            return root;
        }

        private Node Search(T data)
        {
            Node current = Root;

            while (current != null)
            {
                int compared = current.Data.CompareTo(data);

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

        private Node SearchAt(Node root, T data)
        {
            if (root == null)
            {
                return root;
            }

            int compared = root.Data.CompareTo(data);

            if (compared == 0)
            {
                return root;
            }
            else if (compared > 0)
            {
                return SearchAt(root.Left, data);
            }
            else
            {
                return SearchAt(root.Right, data);
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
                int compared = node.Data.CompareTo(root.Data);

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
                int compared = node.Data.CompareTo(root.Data);

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
