using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaanLib.Datastructures {
    internal sealed class Node<T> where T : IComparable {
        internal T element;
        internal Node<T> left;
        internal Node<T> right;

        internal Node() { }

        internal Node(T element) => this.element = element;
    }

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
            if (current.element.CompareTo(element) < 0) {
                if (current.left == null)
                    current.left = new Node<T>(element);
                else
                    Insert(element, current.left);
            } else if (current.element.CompareTo(element) > 0) {
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
                return current.left == null ? current.element : GetMin(current.left);
        }

        public T GetMax() => GetMax(root);

        private T GetMax(Node<T> current) {
            if (current == null)
                return default(T);
            else
                return current.right == null ? current.element : GetMax(current.right);
        }

        public void RemoveMin() => RemoveMin(root, null);

        private void RemoveMin(Node<T> current, Node<T> previous) {
            if (current == null)
                return;
            else {
                if (current.left == null) {
                    if (current.right != null)
                        previous.left = current.right;
                    else
                        previous.left = null;
                } else
                    RemoveMin(current.left, current);
            }
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
            else if (current.element.Equals(item)) {
                throw new NotImplementedException();
            } else if (current.element.CompareTo(item) < 0) {
                Remove(item, current.left, current);
            } else if (current.element.CompareTo(item) > 0) {
                Remove(item, current.right, current);
            }
        }

        public bool Contains(T item) => Contains(item, root);

        private bool Contains(T item, Node<T> current) {
            if (current == null)
                return false;
            else if (current.element.Equals(item))
                return true;
            else if (current.element.CompareTo(item) < 0)
                return Contains(item, current.left);
            else if (current.element.CompareTo(item) > 0)
                return Contains(item, current.right);

            return false;
        }

        public override string ToString() => root == null ? "" : ToString(root);

        private string ToString(Node<T> current) {
            if (current == null)
                return "NULL";
            else
                return $"[ {ToString(current.left)} {current.element.ToString()} {ToString(current.right)} ]";
        }
    }
}
