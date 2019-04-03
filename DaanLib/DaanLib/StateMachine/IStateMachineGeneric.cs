namespace DaanLib.StateMachine {
    /// <summary>
    /// A generic state machine
    /// </summary>
    /// <typeparam name="T">The type of state object that uses the state machine</typeparam>
    public interface IStateMachine<T> {
        /// <summary>
        /// Changes the state of the state machine
        /// </summary>
        /// <param name="newState">The new state of the state machine</param>
        void ChangeState(IState<T> newState);
        /// <summary>
        /// Sets the owner of the state machine
        /// </summary>
        /// <param name="newOwner">The new owner of the state machine</param>
        void SetOwner(T newOwner);
        /// <summary>
        /// Sets the state of the state machine
        /// </summary>
        /// <param name="newState">The new state of the state machine</param>
        void SetState(IState<T> newState);
        /// <summary>
        /// Updates the state machine
        /// </summary>
        void Update();
    }
}