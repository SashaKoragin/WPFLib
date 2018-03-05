using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using DBFtoSQL2008Enterprise.Aplication.Commands;
using DBFtoSQL2008Enterprise.Aplication.FormsWindows.Glavnoe;

namespace DBFtoSQL2008Enterprise.Aplication.Commands
{
   public class UseCommands<T> : ICommand
    {
        /// <summary>
        /// Делегат принимающий Void Метод 
        /// </summary>
        readonly Action<T> _execute;
        /// <summary>
        /// Делегат принимающий Bool Метод 
        /// </summary>
        readonly Predicate<T> _canExecute;

        /// <summary>
        /// Класс принимабщий параметры от другого класса 
        /// </summary>
        /// <param name="execute"></param>
        /// <param name="canExecute"></param>
        public UseCommands(Action<T> execute, Predicate<T> canExecute)
        {
            if (execute == null)
                throw new ArgumentNullException(nameof(execute));
            _execute = execute;
            _canExecute = canExecute;
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            return _canExecute?.Invoke((T)parameter) ?? true;
        }

        public void Execute(object parameter)
        {
             //Task.Run(() => _execute((T)parameter));
            _execute((T) parameter);
        }
    }
}
