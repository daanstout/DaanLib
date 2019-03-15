﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaanLib.StateMachine {
    public interface IState<T> {
        void Enter(T obj);
        void Execute(T obj);
        void Exit(T obj);
    }
}
