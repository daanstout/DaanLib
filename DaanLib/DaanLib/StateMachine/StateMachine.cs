using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaanLib.StateMachine {
    public struct StateMachine : IStateMachine, IStateMachine<object> {
        private object owner;
        private IState state;

        public StateMachine(object owner) : this(owner, null) { }

        public StateMachine(object owner, IState state) {
            this.owner = owner;
            this.state = state;
        }

        public void ChangeState(IState newState) {
            state.Exit(owner);
            state = newState;
            state.Enter(owner);
        }

        public void ChangeState(IState<object> newState) {
            state.Exit(owner);
            state = (IState)newState;
            state.Enter(owner);
        }

        public void SetState(IState newState) {
            state = newState;
            state.Enter(owner);
        }

        public void SetState(IState<object> newState) {
            state = (IState)newState;
            state.Enter(owner);
        }

        public void Update() => state.Execute(owner);

        public void SetOwner(object newOwner) => owner = newOwner;
    }
}
