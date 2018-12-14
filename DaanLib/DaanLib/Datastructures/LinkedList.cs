using System;
using System.Collections.Generic;
using System.Text;

namespace DaanLib.Datastructures {
    /// <summary>
    /// A node from the Linked List
    /// </summary>
    /// <typeparam name="T">The class type stored in the Node</typeparam>
    public class LinkedListNode<T> {
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
    }

    /// <summary>
    /// A Linked List
    /// </summary>
    /// <typeparam name="T">The type stored in the nodes</typeparam>
    public class LinkedList<T> {
        /// <summary>
        /// The header of the list
        /// </summary>
        private LinkedListNode<T> header;
        /// <summary>
        /// The tail of the list
        /// </summary>
        private LinkedListNode<T> tail;

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

        public T this[int index] {
            get {
                LinkedListNode<T> current = header;
                while(current.next != tail && index > 1) {
                    current = current.next;
                    index--;
                }
                if (index == 0)
                    return current.data;
                else
                    throw new IndexOutOfRangeException();
            }
            set {

            }
        }

        /// <summary>
        /// Adds data to the first spot in the list
        /// </summary>
        /// <param name="data">The data stored in the node</param>
        public void AddFirst(T data) {
            LinkedListNode<T> temp = new LinkedListNode<T>(data) {
                next = header.next,
                previous = header
            };
            header.next = temp;
            temp.next.previous = temp;
        }
    }
}
