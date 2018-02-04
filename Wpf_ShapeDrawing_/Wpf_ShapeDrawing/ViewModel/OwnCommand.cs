using System;
using System.Windows.Input;

namespace Wpf_ShapeDrawing
{
        public class RelayCommand : ICommand
        {
            private readonly Action<object> execute;
            private readonly Predicate<object> canExecute;


            public RelayCommand(Action<object> execute) : this(execute, null)
            {
            }

            public RelayCommand(Action<object> execute, Predicate<object> canExecute)
            {
                this.execute = execute;
                this.canExecute = canExecute;
            }

            public event EventHandler CanExecuteChanged
            {
                add { CommandManager.RequerySuggested += value; }
                remove { CommandManager.RequerySuggested -= value; }
            }

            public bool CanExecute(object parameter)
            {
                return this.canExecute == null || this.canExecute(parameter);
            }

            public void Execute(object parameters)
            {
                this.execute(parameters);
            }
        }

}
