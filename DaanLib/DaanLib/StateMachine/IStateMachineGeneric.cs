namespace DaanLib.StateMachine {
    public interface IStateMachine<T> {
        void ChangeState(IState<T> newState);
        void SetOwner(T newOwner);
        void SetState(IState<T> newState);
        void Update();
    }
}