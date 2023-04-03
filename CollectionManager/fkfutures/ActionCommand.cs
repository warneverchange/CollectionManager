﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CollectionManager.fkfutures
{
    internal class ActionCommand: ICommand
    {
        public event EventHandler? CanExecuteChanged;
        private readonly Action _action;

        public ActionCommand(Action action)
        {
            _action = action;
        }

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            _action();
        }
    }
}
