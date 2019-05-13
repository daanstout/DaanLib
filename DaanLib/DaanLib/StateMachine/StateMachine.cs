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
    public struct StateMachine<T> : IStateMachine<T>, IEquatable<StateMachine<T>> {
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

        /// <summary>
        /// Checks for equality between two State Machines
        /// </summary>
        /// <param name="obj">The other State Machine</param>
        /// <returns>True if they are equal and false if they are not</returns>
        public override bool Equals(object obj) => obj is StateMachine<T> machine && Equals(machine);
        /// <summary>
        /// Checks for equality between two State Machines
        /// </summary>
        /// <param name="other">The other State Machine</param>
        /// <returns>True if they are equal and false if they are not</returns>s
        public bool Equals(StateMachine<T> other) => EqualityComparer<T>.Default.Equals(owner, other.owner);
        /// <summary>
        /// Generates a HashCode for the State Machine
        /// </summary>
        /// <returns>The Hashcode of this State Machine</returns>
        public override int GetHashCode() => -1066290700 + EqualityComparer<T>.Default.GetHashCode(owner);

        public static bool operator ==(StateMachine<T> left, StateMachine<T> right) => left.Equals(right);
        public static bool operator !=(StateMachine<T> left, StateMachine<T> right) => !(left == right);
    }

    /// <summary>
    /// A state machine that allows an object to use different owners
    /// </summary>
    public struct StateMachine : IStateMachine, IEquatable<StateMachine> {
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

        /// <summary>
        /// Checks for equality between two State Machines
        /// </summary>
        /// <param name="obj">The other State Machine</param>
        /// <returns>True if they are equal and false if they are not</returns>
        public override bool Equals(object obj) => obj is StateMachine machine && Equals(machine);
        /// <summary>
        /// Checks for equality between two State Machines
        /// </summary>
        /// <param name="other">The other State Machine</param>
        /// <returns>True if they are equal and false if they are not</returns>
        public bool Equals(StateMachine other) => EqualityComparer<object>.Default.Equals(owner, other.owner);
        /// <summary>
        /// Generates a HashCode for the State Machine
        /// </summary>
        /// <returns>The Hashcode of this State Machine</returns>
        public override int GetHashCode() => -1066290700 + EqualityComparer<object>.Default.GetHashCode(owner);

        public static bool operator ==(StateMachine left, StateMachine right) => left.Equals(right);
        public static bool operator !=(StateMachine left, StateMachine right) => !(left == right);
    }
}
