using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Abonamenty.ViewModel
{
    public class SimpleRelayCommand : ICommand
    {
        private Action _action;

        public SimpleRelayCommand(Action action)
        {
            _action = action;
        }

        #region ICommand Members

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            if (parameter != null)
            {
                _action();
            }
            else
            {
                _action();
            }
        }

        #endregion
    }
}
