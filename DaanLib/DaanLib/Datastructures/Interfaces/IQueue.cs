namespace DaanLib.Datastructures {
    public interface IQueue<T> {
        bool IsEmpty { get; }

        T Dequeue();
        void Enqueue(T item);
        void MakeEmpty();
    }
}