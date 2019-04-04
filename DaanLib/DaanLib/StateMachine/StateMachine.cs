using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaanLib.StateMachine {
    /// <summary>
    /// A state machine that allows an object to use different owners
    /// </summary>
    public struct StateMachine : IStateMachine {
        /// <summary>
        /// The owner of this state machine
        /// </summary>
        private object owner;
        /// <summary>
        /// The current state of the state machine
        /// </summary>
        private IState state;

        /// <summary>
        /// Instantiates a new state machine
        /// </summary>
        /// <param name="owner">The owner of the state machine</param>
        public StateMachine(object owner) : this(owner, null) { }

        /// <summary>
        /// Instantiates a new state machine
        /// </summary>
        /// <param name="owner">The owner of the state machine</param>
        /// <param name="state">The initial state of the state machine</param>
        public StateMachine(object owner, IState state) {
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
        public void ChangeState(IState newState) {
            if (owner == null)
                throw new NullReferenceException("This state machine does not have an owner, please make sure the state machine has an owner");

            state.Exit(owner);
            state = newState;
            state.Enter(owner);
        }

        /// <summary>
        /// Changes the state of the state machine
        /// </summary>
        /// <param name="newState">The new state of the state machine</param>
        public void ChangeState(IState<object> newState) {
            if (owner == null)
                throw new NullReferenceException("This state machine does not have an owner, please make sure the state machine has an owner");

            state.Exit(owner);
            state = (IState)newState;
            state.Enter(owner);
        }

        /// <summary>
        /// Sets the state of the state machine
        /// </summary>
        /// <param name="newState">The new state of the state machine</param>
        public void SetState(IState newState) {
            if (owner == null)
                throw new NullReferenceException("This state machine does not have an owner, please make sure the state machine has an owner");

            state = newState;
            state.Enter(owner);
        }

        /// <summary>
        /// Sets the state of the state machine
        /// </summary>
        /// <param name="newState">The new state of the state machine</param>
        public void SetState(IState<object> newState) {
            if (owner == null)
                throw new NullReferenceException("This state machine does not have an owner, please make sure the state machine has an owner");

            state = (IState)newState;
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
        /// <param name="newOwner"></param>
        public void SetOwner(object newOwner) => owner = newOwner;
    }
}
