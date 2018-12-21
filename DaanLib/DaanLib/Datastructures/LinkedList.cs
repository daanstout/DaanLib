using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace DaanLib.Datastructures {
    /// <summary>
    /// A node from the Linked List
    /// </summary>
    /// <typeparam name="T">The class type stored in the Node</typeparam>
    internal sealed class LinkedListNode<T> {
        /// <summary>
        /// The data in the Node
        /// </summary>
        public T data { get; set; }
        /// <summary>
        /// The next Node in the Linked List
        /// </summary>
        public LinkedListNode<T> next { get; set; }
        /// <summary>
        /// The previous Node in the Linked List
        /// </summary>
        public LinkedListNode<T> previous { get; set; }

        /// <summary>
        /// Instantiates a new LinkedListNode
        /// </summary>
        /// <param name="data">The data for the Node</param>
        public LinkedListNode(T data) => this.data = data;

        /// <summary>
        /// Tests two Nodes for equality
        /// </summary>
        /// <param name="n1">The first Node to test</param>
        /// <param name="n2">The second Node to test</param>
        /// <returns>True if they have the same data, next and previous</returns>
        public static bool operator ==(LinkedListNode<T> n1, LinkedListNode<T> n2) => n1.data.Equals(n2.data) && object.ReferenceEquals(n1.next, n2.next) && object.ReferenceEquals(n1.previous, n2.previous);
        /// <summary>
        /// Tests two Nodes for equality
        /// </summary>
        /// <param name="n1">The first Node to test</param>
        /// <param name="n2">The second Node to test</param>
        /// <returns>True if they do not have the same, next or previous</returns>
        public static bool operator !=(LinkedListNode<T> n1, LinkedListNode<T> n2) => !(n1.data.Equals(n2.data) && object.ReferenceEquals(n1.next, n2.next) && object.ReferenceEquals(n1.previous, n2.previous));

        /// <summary>
        /// Checks if two Nodes are equal
        /// </summary>
        /// <param name="obj">The object to test</param>
        /// <returns>True if they are equal</returns>
        public override bool Equals(object obj) {
            if (obj == null)
                return false;
            if (obj is LinkedListNode<T> n)
                return data.Equals(n.data) && object.ReferenceEquals(next, n.next) && object.ReferenceEquals(previous, n.previous);
            else
                return false;
        }

        /// <summary>
        /// Gets a Unique Hash Code
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode() {
            // Get the base hash and multiply with 29
            int hash = 159389 + base.GetHashCode() * 29;
            // Add the data's hash, multiplied with 23
            hash += 23 * data.GetHashCode();
            // If we have a next, add its hash multiplied with 27
            hash += 27 * (next?.GetHashCode() ?? 0);
            // If we have a previous, add its hash multiplied with 31
            hash += 31 * (previous?.GetHashCode() ?? 0);
            // We add the hashes of the previous' and next's data to the hash as well to decrease the odds of mulitple hashes
            // as it's possible to have two different nodes with the same data, but the chance the data of the neighbours of those nodes is the same is substantially lower
            return hash;
        }

        /// <summary>
        /// Creates a string representation of this Node's data
        /// </summary>
        /// <returns>A string representation of this Node's data</returns>
        public override string ToString() => data.ToString();
    }

    /// <summary>
    /// A Linked List
    /// </summary>
    /// <typeparam name="T">The type stored in the nodes</typeparam>
    public sealed class LinkedList<T> : ICollection<T>, IEnumerable<T>, IEnumerable {
        /// <summary>
        /// The header of the list
        /// </summary>
        internal LinkedListNode<T> header;
        /// <summary>
        /// The tail of the list
        /// </summary>
        internal LinkedListNode<T> tail;

        /// <summary>
        /// Gets or Sets the data at a specified index
        /// </summary>
        /// <param name="index">The index of the Node to edit</param>
        /// <returns>The data of the node</returns>
        public T this[int index] {
            get {
                //  Make sure the index is not less than zero and we even have a list
                if (index < 0 || header.next == tail) // Throw an exception if either is the case
                    throw new IndexOutOfRangeException();

                // The current Node we are looking at is the first node. We know we have a node because of our previous if statement
                LinkedListNode<T> current = header.next;
                // While the next Node is not the tail of the list and we are not at the requested index yet, go through the list
                while (current.next != tail && index >= 1) {
                    // Iterate to the next Node
                    current = current.next;
                    // Redude the index
                    index--;
                }

                // If the index is 0, we have come to the requested Node
                if (index == 0)
                    return current.data;
                else // If not, we ran out of List to iterate through
                    throw new IndexOutOfRangeException();
            }
            set {
                //  Make sure the index is not less than zero and we even have a list
                if (index < 0 || header.next == tail) // Throw an exception if either is the case
                    throw new IndexOutOfRangeException();

                // The current Node we are looking at is the first node. We know we have a node because of our previous if statement
                LinkedListNode<T> current = header.next;
                // While the next Node is not the tail of the list and we are not at the requested index yet, go through the list
                while (current.next != tail && index >= 1) {
                    // Iterate to the next Node
                    current = current.next;
                    // Redude the index
                    index--;
                }

                // If the index is 0, we have come to the requested Node
                if (index == 0)
                    current.data = value;
                else // If not, we ran out of List to iterate through
                    throw new IndexOutOfRangeException();
            }
        }

        public int Count {
            get {
                int i = 0;
                LinkedListNode<T> current = header.next;
                while (current != tail) {
                    current = current.next;
                    i++;
                }
                return i;
            }
        }

        public bool IsReadOnly => false;

        public IEnumerator<T> GetEnumerator() => new LinkedListEnumerator<T>(this);

        IEnumerator IEnumerable.GetEnumerator() => new LinkedListEnumerator<T>(this);

        /// <summary>
        /// Instantiates a new Linked List
        /// </summary>
        public LinkedList() {
            // Create the header with a default value for T
            header = new LinkedListNode<T>(default(T));
            // Create the tail with a default value for T
            tail = new LinkedListNode<T>(default(T));
            // Set the next Node of the header to the tail
            header.next = tail;
            // Set the next Node of the tail to the header
            tail.previous = header;
        }

        public LinkedList(IEnumerable<T> collection) {
            header = new LinkedListNode<T>(default(T));
            tail = new LinkedListNode<T>(default(T));
            header.next = tail;
            tail.previous = header;
            LinkedListNode<T> current = header;
            foreach (T item in collection) {
                LinkedListNode<T> temp = new LinkedListNode<T>(item) {
                    next = current.next,
                    previous = current
                };
                current.next = temp;
                temp.next.previous = temp;
            }
        }

        /// <summary>
        /// Adds data to the first spot in the list
        /// </summary>
        /// <param name="data">The data stored in the node</param>
        public void AddFirst(T data) {
            // Create the new node and set its next and previous
            LinkedListNode<T> temp = new LinkedListNode<T>(data) {
                next = header.next,
                previous = header
            };
            // Update the header and the next nod
            header.next = temp;
            temp.next.previous = temp;
        }

        public void Add(T item) {
            LinkedListNode<T> temp = new LinkedListNode<T>(item) {
                next = tail,
                previous = tail.previous
            };
            tail.previous = temp;
            temp.previous.next = temp;
        }

        /// <summary>
        /// Prints the Linked List to the console
        /// </summary>
        public void Print() {
            LinkedListNode<T> current = header.next;
            while (current != tail) {
                Console.WriteLine(current.data);
                current = current.next;
            }
        }

        public void Clear() {
            header.next = tail;
            tail.previous = header;
        }

        public T GetFirst() => header.next.data;
        public T GetLast() => tail.previous.data;

        public void Insert(int index, T data) {
            if (index < 0)
                throw new IndexOutOfRangeException();

            LinkedListNode<T> current = header.next;
            while (current.next != tail && index >= 1) {
                current = current.next;
                index--;
            }
            if (index > 1)
                throw new IndexOutOfRangeException();
            else {
                LinkedListNode<T> temp = new LinkedListNode<T>(data) {
                    next = current.next,
                    previous = current
                };
                current.next = temp;
                temp.next.previous = temp;
            }
        }

        public void RemoveFirst() {
            if (header.next != tail) {
                header.next = header.next.next;
                header.next.previous = header;
            }
        }

        public void RemoveLast() {
            if (tail.previous != header) {
                tail.previous = tail.previous.previous;
                tail.previous.next = tail;
            }
        }

        public bool Remove(int index) {
            if (index < 0)
                throw new IndexOutOfRangeException();

            LinkedListNode<T> current = header.next;
            while (current.next != tail && index >= 1) {
                current = current.next;
                index--;
            }
            if (index > 1)
                return false;
            else {
                current.previous.next = current.next;
                current.next.previous = current.previous;
                return true;
            }
        }

        public bool Remove(T data) {
            LinkedListNode<T> current = header.next;
            while (!current.data.Equals(data) && current != tail) {
                current = current.next;
            }
            if (current != tail) {
                current.previous.next = current.next;
                current.next.previous = current.previous;
                return true;
            }
            return false;
        }

        public bool Contains(T item) {
            //LinkedListNode<T> current = header.next;
            for (LinkedListNode<T> current = header.next; current != tail; current = current.next) {
                if (current.data.Equals(item))
                    return true;
            }
            return false;
        }

        public void CopyTo(T[] array) {
            if (array == null)
                throw new ArgumentNullException();

            if (array.Length < Count)
                throw new ArgumentException();

            if (array.Rank != 1)
                throw new ArgumentException();

            LinkedListNode<T> current = header.next;
            for (int i = 0; current != tail; i++, current = current.next)
                array[i] = current.data;
        }

        public void CopyTo(T[] array, int startIndex) {
            if (array == null)
                throw new ArgumentNullException();

            if (startIndex < 0)
                throw new ArgumentOutOfRangeException();

            if (array.Length < Count + startIndex)
                throw new ArgumentException();

            if (array.Rank != 1)
                throw new ArgumentException();

            LinkedListNode<T> current = header.next;
            for (int i = startIndex; current != tail; i++, current = current.next)
                array[i] = current.data;
        }

        public void CopyTo(T[] array, int startIndex, int count) {
            if (array == null)
                throw new ArgumentNullException();

            if (startIndex < 0)
                throw new ArgumentOutOfRangeException();

            if (array.Length < count + startIndex)
                throw new ArgumentException();

            if (array.Rank != 1)
                throw new ArgumentException();

            LinkedListNode<T> current = header.next;
            for (int i = startIndex; i < startIndex + count && current != tail; i++, current = current.next)
                array[i] = current.data;
        }

        public void CopyTo(T[] array, int startIndex, int arrayIndex, int count) {
            if (array == null)
                throw new ArgumentNullException();

            if (startIndex < 0 || arrayIndex < 0)
                throw new ArgumentOutOfRangeException();

            if (array.Length < count + startIndex)
                throw new ArgumentException();

            if (array.Rank != 1)
                throw new ArgumentException();

            LinkedListNode<T> current = header.next;
            for (int i = startIndex; i < startIndex + count; i++)
                array[i] = this[arrayIndex + i];
        }
    }

    public class LinkedListEnumerator<T> : IEnumerator<T> {
        private LinkedList<T> _collection;
        private int curIndex;
        private LinkedListNode<T> curNode;

        public LinkedListEnumerator(LinkedList<T> collection) {
            _collection = collection;
            curIndex = -1;
            curNode = _collection.header;
        }

        public bool MoveNext() {
            if (++curIndex >= _collection.Count || curNode.next == _collection.tail) {
                return false;
            } else {
                curNode = curNode.next;
            }
            return true;
        }

        public void Reset() {
            curIndex = -1;
            curNode = _collection.header;
        }

        void IDisposable.Dispose() { }

        object IEnumerator.Current => Current;

        public T Current => curNode.data;
    }
}