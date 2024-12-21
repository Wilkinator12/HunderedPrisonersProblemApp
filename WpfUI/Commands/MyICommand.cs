using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WpfUI.Commands
{
    public class MyICommand : ICommand
    {
        private readonly Action _executeMethod;
        private readonly Func<bool>? _canExecuteMethod;

        public event EventHandler? CanExecuteChanged;


        public MyICommand(Action executeMethod)
        {
            _executeMethod = executeMethod;
        }

        public MyICommand(Action executeMethod, Func<bool> canExecuteMethod)
        {
            _executeMethod = executeMethod;
            _canExecuteMethod = canExecuteMethod;
        }


        public bool CanExecute(object? parameter) => _canExecuteMethod?.Invoke() ?? true;

        public void Execute(object? parameter) => _executeMethod();

        public void RaiseCanExecuteChanged() => CanExecuteChanged?.Invoke(this, EventArgs.Empty);
    }
}
