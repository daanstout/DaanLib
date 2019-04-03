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
    public sealed class BinaryTree<T> where T : IComparable {
        /// <summary>
        /// The root of the Tree
        /// </summary>
        private Node<T> root;

        /// <summary>
        /// The depth of the Tree (The length of the longest fork of the tree)
        /// </summary>
        public int depth => Depth(root);

        /// <summary>
        /// The size of the Tree (The number of elements)
        /// </summary>
        public int size => Size(root);

        /// <summary>
        /// Instantiates a new Tree
        /// </summary>
        public BinaryTree() { }

        /// <summary>
        /// Instantiates a new Tree
        /// </summary>
        /// <param name="element">The element to sit at the root</param>
        public BinaryTree(T element) => root = new Node<T>(element);

        /// <summary>
        /// Instantiates a new Tree
        /// </summary>
        /// <param name="elements">A list of elements to add</param>
        public BinaryTree(T[] elements) {
            root = new Node<T>(elements[0]);

            for (int i = 1; i < elements.Length; i++)
                Insert(elements[i]);
        }

        /// <summary>
        /// Instantiates a new Tree
        /// </summary>
        /// <param name="elements">A list of elements to add</param>
        public BinaryTree(List<T> elements) {
            root = new Node<T>(elements[0]);

            for (int i = 1; i < elements.Count; i++)
                Insert(elements[i]);
        }

        /// <summary>
        /// Add an element to the Tree
        /// </summary>
        /// <param name="element">The element to add</param>
        public void Insert(T element) {
            if (root == null)
                root = new Node<T>(element);
            else
                Insert(element, root);
        }

        /// <summary>
        /// Add an element to the Tree
        /// </summary>
        /// <param name="element">The element to add</param>
        /// <param name="current">The current node</param>
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

        /// <summary>
        /// Gets the lowest element
        /// </summary>
        /// <returns>The lowest element</returns>
        public T GetMin() => GetMin(root);

        /// <summary>
        /// Gets the lowest element
        /// </summary>
        /// <param name="current">The current node</param>
        /// <returns>The lowest element</returns>
        private T GetMin(Node<T> current) {
            if (current == null)
                return default(T);
            else
                return current.left == null ? current.data : GetMin(current.left);
        }

        /// <summary>
        /// Gets the highest element
        /// </summary>
        /// <returns>The highest element</returns>
        public T GetMax() => GetMax(root);

        /// <summary>
        /// Gets the highest element
        /// </summary>
        /// <param name="current">The current node</param>
        /// <returns>The highest element</returns>
        private T GetMax(Node<T> current) {
            if (current == null)
                return default(T);
            else
                return current.right == null ? current.data : GetMax(current.right);
        }

        /// <summary>
        /// Removes the lowest node
        /// </summary>
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
