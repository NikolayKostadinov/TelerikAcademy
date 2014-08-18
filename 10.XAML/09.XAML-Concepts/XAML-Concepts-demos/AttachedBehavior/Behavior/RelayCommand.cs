using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AttachedBehavior.Behavior
{
    public delegate void ExecuteCommandDelegate(object obj);
    public delegate bool CanExecuteCommandDelegate(object obj);



    public class RelayCommand : ICommand
    {
        private ExecuteCommandDelegate execute;
        private CanExecuteCommandDelegate canExecute;


        public RelayCommand(ExecuteCommandDelegate execute)
            : this(execute, null)
        {
        }

        public RelayCommand(ExecuteCommandDelegate execute, CanExecuteCommandDelegate canExecute)
        {
            this.execute = execute;
            this.canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            if (this.canExecute == null)
            {
                return true;
            }
            return this.canExecute(parameter);
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            this.execute(parameter);
        }
    }
}
