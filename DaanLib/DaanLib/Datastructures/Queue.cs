using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaanLib.Datastructures {
    public sealed class Queue<T> : IQueue<T> {
        private T[] queue;
        private int front;
        private int back;
        private int queueMaxSize;
        private int queueSize;

        public bool IsEmpty => queueSize == 0;

        public Queue() : this(5) { }

        public Queue(int queueStartSize) {
            queue = new T[queueStartSize];
            queueMaxSize = queueStartSize;
            front = back = queueSize = 0;
        }

        public void Enqueue(T item) {
            if (queueSize == queueMaxSize)
                DoubleQueue();

            queue[back] = item;
            back++;
            queueSize++;
            back %= queueMaxSize;
        }

        public T Dequeue() {
            if (queueSize == 0)
                return default(T);

            T item = queue[front];
            queueSize--;
            front++;
            front %= queueMaxSize;

            return item;
        }

        public void MakeEmpty() {
            front = back = queueSize = 0;
        }

        private void DoubleQueue() {
            T[] temp = new T[queueMaxSize *= 2];

            for (int i = 0; i < queueSize; i++)
                temp[i] = queue[(i + back) % queueSize];

            back = queueSize;
            front = 0;
            queue = temp;
        }
    }
}
