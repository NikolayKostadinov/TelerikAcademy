using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace ImageViewerMVVM.Commands
{
    public delegate void executeDelegate();
    public delegate bool canExecuteDelegate();

    class RelayCommand : ICommand
    {
        executeDelegate execute;
        canExecuteDelegate canExecute;

        public RelayCommand(executeDelegate execute, canExecuteDelegate canExecute=null)
        {
            this.execute = execute;
            this.canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            if (canExecute == null)
            {
                return true;
            }
            return canExecute();
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            execute();
        }
    }
}