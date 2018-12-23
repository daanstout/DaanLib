using System.Collections;
using System.Collections.Generic;

namespace DaanLib.Datastructures {
    public interface ILinkedList<T> : ICollection<T>, IEnumerable<T>, IEnumerable {
        T this[int index] { get; set; }

        bool IsEmpty { get; }

        void AddFirst(T data);
        void CopyTo(T[] array);
        void CopyTo(T[] array, int startIndex, int count);
        void CopyTo(T[] array, int startIndex, int arrayIndex, int count);
        T GetFirst();
        T GetLast();
        void Insert(int index, T data);
        void Print();
        bool Remove(int index);
        void RemoveFirst();
        void RemoveLast();
    }
}