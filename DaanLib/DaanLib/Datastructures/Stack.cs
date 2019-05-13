using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaanLib.Datastructures {
    /// <summary>
    /// A Stack that follows the FILO rules
    /// </summary>
    /// <typeparam name="T">The Type to store in the stack</typeparam>
    public sealed class Stack<T> {
        /// <summary>
        /// The stack
        /// </summary>
        private T[] stack;
        /// <summary>
        /// The top of the stack
        /// </summary>
        private int top;
        /// <summary>
        /// The max number of elements the stack can hold
        /// </summary>
        private int maxStackSize;
        /// <summary>
        /// The current number of relevant elements in the stack
        /// </summary>
        private int stackSize;

        public bool IsEmpty => stackSize == 0;

        /// <summary>
        /// Instantiates a new Stack with a size of 5
        /// </summary>
        public Stack() : this(5) { }

        /// <summary>
        /// Instantiates a new Stack with a given size
        /// </summary>
        /// <param name="startStackSize">The amount of elements this stack can initially hold</param>
        public Stack(int startStackSize) {
            maxStackSize = startStackSize;
            stack = new T[maxStackSize];
            stackSize = top = 0;
        }

        /// <summary>
        /// Returns the top of the stack
        /// </summary>
        /// <returns>The item at the top of the stack</returns>
        public T Pop() {
            if (stackSize == 0)
                return default;

            top = stackSize -= 1;
            return stack[top + 1];
        }

        /// <summary>
        /// Pushes an item into the stack
        /// </summary>
        /// <param name="data">The data to push</param>
        public void Push(T data) {
            if (stackSize == maxStackSize)
                DoubleStack();

            top = stackSize += 1;
            stack[top] = data;
        }

        /// <summary>
        /// Shows what is on top of the stack without removing it
        /// </summary>
        /// <returns>The item on top of the stack</returns>
        public T Top() => stack[top];

        /// <summary>
        /// Doubles the stack
        /// </summary>
        private void DoubleStack() {
            T[] temp = new T[maxStackSize *= 2];

            for (int i = 0; i < stackSize; i++)
                temp[i] = stack[i];

            stack = temp;
        }
    }
}
