using System.Windows.Input;

namespace WpfUI.Commands
{
    public class MyAsyncICommand : ICommand
    {
        private readonly Func<Task> _executeMethodAsync;
        private readonly Func<bool>? _canExecuteMethodAsync;


        public event EventHandler? CanExecuteChanged;


        public MyAsyncICommand(Func<Task> executeMethodAsync)
        {
            _executeMethodAsync = executeMethodAsync;
        }

        public MyAsyncICommand(Func<Task> executeMethodAsync, Func<bool> canExecuteMethodAsync)
        {
            _executeMethodAsync = executeMethodAsync;
            _canExecuteMethodAsync = canExecuteMethodAsync;
        }


        public bool CanExecute(object? parameter) => _canExecuteMethodAsync?.Invoke() ?? true;

        public async void Execute(object? parameter) => await _executeMethodAsync();

        public void RaiseCanExecuteChanged() => CanExecuteChanged?.Invoke(this, EventArgs.Empty);
    }
}
