using Prism.Commands;
using ViewModelLib.ModelTestAutoit.PublicModel.ButtonStartAutomat;

namespace AutomatAis3Full.Form.Automat.Uregulirovanie.Uvedomlenie0509.StatementDecisionApplication.DataContext
{
   public class DataContextStatementDecisionApplication
    {

        public StatusButtonMethod StartButton { get; }
        /// <summary>
        /// Автомат
        /// Общие задания\Урегулирование задолженности\05.09 Формирование решения об отказе по заявлению\Подписание руководителем НО
        /// </summary>
        public DataContextStatementDecisionApplication()
        {
            StartButton = new StatusButtonMethod();
            var commandAuto = new LibraryCommandPublic.TestAutoit.Uregulirovanie.MessageLk.AutoMessageLk();
            StartButton.Button.Command = new DelegateCommand(() => { commandAuto.StatementDecisionApplication(StartButton); });
        }


    }
}
