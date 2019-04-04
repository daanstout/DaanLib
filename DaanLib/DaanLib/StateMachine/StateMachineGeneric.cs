using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaanLib.StateMachine {
    /// <summary>
    /// A state machine that allows an object to use different owners
    /// </summary>
    /// <typeparam name="T">The type of object that uses this state machine</typeparam>
    public struct StateMachine<T> : IStateMachine<T> {
        /// <summary>
        /// The owner of this state machine
        /// </summary>
        private T owner;
        /// <summary>
        /// The current state of the state machine
        /// </summary>
        private IState<T> state;

        /// <summary>
        /// Instantiates a new state machine
        /// </summary>
        /// <param name="owner">The owner of the state machine</param>
        public StateMachine(T owner) : this(owner, null) { }

        /// <summary>
        /// Instantiates a new state machine
        /// </summary>
        /// <param name="owner">The owner of the state machine</param>
        /// <param name="state">The initial state of the state machine</param>
        public StateMachine(T owner, IState<T> state) {
            this.owner = owner;
            this.state = state;
            this.state?.Enter(this.owner);
            // if (state != null)
            //     this.state.Enter(this.owner);
        }

        /// <summary>
        /// Changes the state of the state machine
        /// </summary>
        /// <param name="newState">The new state of the state machine</param>
        public void ChangeState(IState<T> newState) {
            if (owner == null)
                throw new NullReferenceException("This state machine does not have an owner, please make sure the state machine has an owner");

            state.Exit(owner);
            state = newState;
            state.Enter(owner);
        }

        /// <summary>
        /// Sets the state of the state machine
        /// </summary>
        /// <param name="newState">The new state of the state machine</param>
        public void SetState(IState<T> newState) {
            if (owner == null)
                throw new NullReferenceException("This state machine does not have an owner, please make sure the state machine has an owner");

            state = newState;
            state.Enter(owner);
        }

        /// <summary>
        /// Updates the state machine
        /// </summary>
        public void Update() {
            if (owner == null)
                throw new NullReferenceException("This state machine does not have an owner, please make sure the state machine has an owner");

            state.Execute(owner);
        }

        /// <summary>
        /// Sets the owner of the state machine
        /// </summary>
        /// <param name="newOwner">The new owner of the state machine</param>
        public void SetOwner(T newOwner) => owner = newOwner;
    }
}
