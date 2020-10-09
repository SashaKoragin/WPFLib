using Prism.Commands;
using ViewModelLib.ModelTestAutoit.PublicModel.ButtonStartAutomat;

namespace AutomatAis3Full.Form.Automat.Okp1.Declaration121.DataContext
{
   public class DataContextDeclaration121
    {
        /// <summary>
        /// Кнопка старт автомат
        /// </summary>
        public StatusButtonMethod StartButton { get; }
        /// <summary>
        /// Дата контекст
        /// </summary>
        public DataContextDeclaration121()
        {
            var command = new LibraryCommandPublic.TestAutoit.Okp1.RegisterDeclarations();
            StartButton = new StatusButtonMethod();
            StartButton.Button.Command = new DelegateCommand(() => { command.SetStatusDeclarations(StartButton); });
        }
    }
}
