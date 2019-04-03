using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaanLib.StateMachine {
    /// <summary>
    /// A generic state for the state machine
    /// </summary>
    /// <typeparam name="T">The class represented by the state machine</typeparam>
    public interface IState<T> {
        /// <summary>
        /// Activates when the state becomes the active state in a state machine
        /// </summary>
        /// <param name="obj">The object to act on</param>
        void Enter(T obj);
        /// <summary>
        /// Activates when the state machine updates
        /// </summary>
        /// <param name="obj">The object to act on</param>
        void Execute(T obj);
        /// <summary>
        /// Activates when the state ceases to be the active state in a state machine
        /// </summary>
        /// <param name="obj"></param>
        void Exit(T obj);
    }
}
