using System.Windows.Input;

namespace DBFtoSQL2008Enterprise.Aplication.Commands
{
    public class Comands
    {
        private ICommand _loadfile;
        /// <summary>
        /// Объявление команды get set для объявление новой команды нужен новый конструктор
        /// </summary>
        public ICommand LoadFile
        {
            get
            {
                if (_loadfile == null)
                {
                    _loadfile = new UseCommands<object>(LoadFileDbf, CanCommandExecute);
                }
                return _loadfile;
            }
        }

        /// <summary>
        /// Парамерт который показывает Выполняется ли команда
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        private bool CanCommandExecute(object parameter)
        {
            return true;
        }

        /// <summary>
        /// Команда передача Которая будет являтся параметром делегата в клссе Command параметра 
        /// </summary>
        /// <param name="parameter">Параметр который не задействован в xamle</param>
        public void LoadFileDbf(object parameter)
        {
            CommandsText commandtext = new CommandsText();
            commandtext.LoadFileDbfText(parameter);
        }
    }
}
