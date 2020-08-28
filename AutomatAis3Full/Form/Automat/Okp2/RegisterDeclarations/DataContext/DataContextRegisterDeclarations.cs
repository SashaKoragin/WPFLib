using AutomatAis3Full.Config;
using Prism.Commands;
using ViewModelLib.ModelTestAutoit.PublicModel.ButtonStartAutomat;
using ViewModelLib.ModelTestAutoit.PublicModel.ModelDatePickerAdd;

namespace AutomatAis3Full.Form.Automat.Okp2.RegisterDeclarations.DataContext
{
   public class DataContextRegisterDeclarations
    {

        public StatusButtonMethod StartButton { get; }

        public DatePickerAdd DatePicker { get; }
        /// <summary>
        /// VM DataContext
        /// </summary>
        public DataContextRegisterDeclarations()
        {
            DatePicker = new DatePickerAdd();
            var command = new LibraryCommandPublic.TestAutoit.Okp2.RegisterDeclarations();
            StartButton = new StatusButtonMethod();
            StartButton.Button.Command = new DelegateCommand(() => { command.StartRegisterDeclarations(StartButton, ConfigFile.PathPdfTemp, DatePicker); });
        }
    }
}
