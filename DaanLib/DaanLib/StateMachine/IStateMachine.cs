namespace DaanLib.StateMachine {
    /// <summary>
    /// A state machine that uses objects as source
    /// </summary>
    public interface IStateMachine : IStateMachine<object> {
        /// <summary>
        /// Changes the state of the state machine
        /// </summary>
        /// <param name="newState">The new state of the state machine</param>
        void ChangeState(IState newState);
        /// <summary>
        /// Sets the state of the state machine
        /// </summary>
        /// <param name="newState">The new state of the state machine</param>
        void SetState(IState newState);
    }
}