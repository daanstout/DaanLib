using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaanLib.StateMachine {
    public class StateMachine<T> : IStateMachine<T> {
        private T owner;
        private IState<T> state;

        public StateMachine(T owner) => this.owner = owner;

        public StateMachine(T owner, IState<T> state) : this(owner) => this.state = state;

        public void ChangeState(IState<T> newState) {
            state.Exit(owner);
            state = newState;
            state.Enter(owner);
        }

        public void SetState(IState<T> newState) {
            state = newState;
            state.Enter(owner);
        }

        public void Update() => state.Execute(owner);

        public void SetOwner(T newOwner) => owner = newOwner;
    }
}
