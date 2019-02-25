using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaanLib.Datastructures {
    /// <summary>
    /// A Node in the Binary Tree
    /// </summary>
    /// <typeparam name="T">The type of data to store</typeparam>
    internal sealed class Node<T> where T : IComparable {
        /// <summary>
        /// The data this Node contains
        /// </summary>
        internal T data;
        /// <summary>
        /// The Node to the left of this
        /// </summary>
        internal Node<T> left;
        /// <summary>
        /// The node to the right of this
        /// </summary>
        internal Node<T> right;

        /// <summary>
        /// Instantiates a new empty Node
        /// </summary>
        internal Node() { }

        /// <summary>
        /// Instantiates a new Node with data
        /// </summary>
        /// <param name="data">The data for this Node</param>
        internal Node(T data) => this.data = data;
    }

    /// <summary>
    /// A Binary Tree that stores its data in a binary way
    /// </summary>
    /// <typeparam name="T">The type of data to store</typeparam>
    public sealed class BinaryTree<T> : IBinaryTree<T> where T : IComparable {
        private Node<T> root;

        public int depth => Depth(root);

        public int size => Size(root);

        public BinaryTree() { }

        public BinaryTree(T element) => root = new Node<T>(element);

        public void Insert(T element) {
            if (root == null)
                root = new Node<T>(element);
            else
                Insert(element, root);
        }

        private void Insert(T element, Node<T> current) {
            if (current.data.CompareTo(element) < 0) {
                if (current.left == null)
                    current.left = new Node<T>(element);
                else
                    Insert(element, current.left);
            } else if (current.data.CompareTo(element) > 0) {
                if (current.right == null)
                    current.right = new Node<T>(element);
                else
                    Insert(element, current.right);
            }
        }

        public T GetMin() => GetMin(root);

        private T GetMin(Node<T> current) {
            if (current == null)
                return default(T);
            else
                return current.left == null ? current.data : GetMin(current.left);
        }

        public T GetMax() => GetMax(root);

        private T GetMax(Node<T> current) {
            if (current == null)
                return default(T);
            else
                return current.right == null ? current.data : GetMax(current.right);
        }

        public void RemoveMin() => RemoveMin(root, null);

        private void RemoveMin(Node<T> current, Node<T> previous) {
            if (current == null)
                return;

            if (current.left != null)
                RemoveMin(current.left, current);

            if (current.right == null)
                previous.left = null;

            previous.left = current.right;
        }

        public void RemoveMax() => RemoveMax(root, null);

        private void RemoveMax(Node<T> current, Node<T> previous) {
            if (current == null)
                return;
            else {
                if (current.right == null) {
                    if (current.left != null)
                        previous.right = current.left;
                    else
                        previous.right = null;
                } else
                    RemoveMax(current.right, current);
            }
        }

        private int Depth(Node<T> current) {
            if (current == null)
                return 0;
            else {
                int left = Depth(current.left) + 1;
                int right = Depth(current.right) + 1;

                return Math.Max(left, right);
            }
        }

        private int Size(Node<T> current) => current == null ? 0 : Size(current.left) + Size(current.right) + 1;

        public void Remove(T item) => Remove(item, root, null);

        private void Remove(T item, Node<T> current, Node<T> previous) {
            if (current == null)
                return;
            else if (current.data.Equals(item)) {
                throw new NotImplementedException();
            } else if (current.data.CompareTo(item) < 0) {
                Remove(item, current.left, current);
            } else if (current.data.CompareTo(item) > 0) {
                Remove(item, current.right, current);
            }
        }

        public bool Contains(T item) => Contains(item, root);

        private bool Contains(T item, Node<T> current) {
            if (current == null)
                return false;
            else if (current.data.Equals(item))
                return true;
            else if (current.data.CompareTo(item) < 0)
                return Contains(item, current.left);
            else if (current.data.CompareTo(item) > 0)
                return Contains(item, current.right);

            return false;
        }

        public override string ToString() => root == null ? "" : ToString(root);

        private string ToString(Node<T> current) {
            if (current == null)
                return "NULL";
            else
                return $"[ {ToString(current.left)} {current.data.ToString()} {ToString(current.right)} ]";
        }
    }
}
