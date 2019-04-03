using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaanLib.StateMachine {
    /// <summary>
    /// A state for objects
    /// </summary>
    public interface IState : IState<object> { }
}
