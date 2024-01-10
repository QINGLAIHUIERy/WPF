using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace _8_2memo
{
    public class SearchCommand:ICommand
    {
        private readonly Action<object> _execute;
        private readonly Func<object, bool> _executeFunc;

        public SearchCommand(Action<object> execute, Func<object, bool> executeFunc)
        {
            this._execute = execute;
            this._executeFunc = executeFunc;
        }

        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return this._executeFunc.Invoke(parameter);
        }

        public void Execute(object? parameter)
        {
            this._execute.Invoke(parameter);
        }
    }
}
