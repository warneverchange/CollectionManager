using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CollectionManager.fkfutures
{
    internal class ActionCommandWithParam<T> : ICommand
    {
        public event EventHandler? CanExecuteChanged;
        private readonly Action<T> _action;

        public ActionCommandWithParam(Action<T> action)
        {
            _action = action;
        }


        public bool CanExecute(object? parameter)
        {
            if (parameter is not null)
            {
                bool result = true;
                try
                {
                    T _ = (T)parameter;
                }
                catch (Exception _)
                {
                    result = false;
                }
                return result;
            }
            else
            {
                return false;
            }

        }

        public void Execute(object? parameter)
        {
            if (CanExecute(parameter))
            {
                _action((T)(parameter ?? throw new NullReferenceException()));
            }
        }
    }
}
