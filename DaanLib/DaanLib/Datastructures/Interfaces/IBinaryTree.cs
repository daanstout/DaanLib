using System;

namespace DaanLib.Datastructures {
    public interface IBinaryTree<T> where T : IComparable {
        int depth { get; }
        int size { get; }

        bool Contains(T item);
        T GetMax();
        T GetMin();
        void Insert(T element);
        void Remove(T item);
        void RemoveMax();
        void RemoveMin();
        string ToString();
    }
}