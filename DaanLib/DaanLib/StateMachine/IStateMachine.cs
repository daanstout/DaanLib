namespace DaanLib.StateMachine {
    public interface IStateMachine {
        void ChangeState(IState newState);
        void SetOwner(object newOwner);
        void SetState(IState newState);
        void Update();
    }
}