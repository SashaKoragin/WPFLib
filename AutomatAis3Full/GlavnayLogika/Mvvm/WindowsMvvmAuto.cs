using System;
using System.Windows.Controls;
using System.Windows.Input;
using AutomatAis3Full.Config;
using Prism.Commands;
using ViewModelLib.ModelTestAutoit.FullWindowAutoIt;
using ViewModelLib.ModelTestAutoit.PublicModel.PdfHelp;

namespace AutomatAis3Full.GlavnayLogika.Mvvm
{
   public class WindowsMvvmAuto 
    {
        public ICommand OpenForms { get; }

        public ICommand OpenPdfHelp { get; }
        public FullWindowAutoItMethod FullWindow { get; }

        public string User { get; }

        public string Web { get; }

        public WindowsMvvmAuto()
        {
            PdfHelp help = new PdfHelp();
            var fullLogica = new AddUserControlFull.AddLogicaFull();
            FullWindow = fullLogica.FullWindowAdd();
            OpenForms = new DelegateCommand<object>(parameter => { FullWindow.IsCheked(parameter); });
            OpenPdfHelp = new DelegateCommand((() => {help.OpenReport(ConfigFile.Help); }));
            User = $"Добро пожаловать {Environment.UserName}";
            Web = ConfigFile.WebSite;
        }

    }
}
