namespace DaanLib.Datastructures {
    public interface IStack<T> {
        bool IsEmpty { get; }

        T Pop();
        void Push(T data);
        T Top();
    }
}