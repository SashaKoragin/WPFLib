using System.Windows.Input;
using AutomatAis3Full.Config;
using Prism.Commands;
using ViewModelLib.ModelTestAutoit.ModelFormirovanie.DonloadPrintDb;
using ViewModelLib.ModelTestAutoit.PublicModel.ButtonStartAutomat;
using ViewModelLib.ModelTestAutoit.PublicModel.ModelDatePickerAdd;

namespace AutomatAis3Full.Form.Automat.Okp2.TaxJournal.DataContext
{
   public class DataContextTaxJournal
    {
        public DownloadPrintDb DownloadPrintDb { get; set; }
        public ICommand PrintFile { get; }
        public DatePickerAdd DatePicker { get; } 

        public StatusButtonMethod StartButton { get; }

        public DataContextTaxJournal()
        {
            DatePicker = new DatePickerAdd();
            var command = new LibraryCommandPublic.TestAutoit.Okp2.TaxJournal();
            DownloadPrintDb = new DownloadPrintDb();
            StartButton = new StatusButtonMethod();
            StartButton.Button.Command = new DelegateCommand(() => { 
                command.StartTaxJournal(StartButton, ConfigFile.PathTemp, DatePicker); 
            }); 
          
            PrintFile = new DelegateCommand(() => { command.PrintFiles(DownloadPrintDb); });
        }
    }
}
