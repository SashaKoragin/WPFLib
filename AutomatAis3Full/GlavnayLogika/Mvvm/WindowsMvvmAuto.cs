using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Prism.Commands;
using ViewModelLib.ModelTestAutoit.FullWindowAutoIt;
using ViewModelLib.ModelTestAutoit.PublicModel.ButtonStartAutomat;
using System.Windows.Forms;
using ViewModelLib.ModelTestAutoit.PublicModel.PdfHelp;

namespace AutomatAis3Full.GlavnayLogika.Mvvm
{
   public class WindowsMvvmAuto
    {
        public ICommand OpenForms { get; }

        public ICommand OpenPdfHelp { get; }
        public FullWindowAutoItMethod FullWindow { get; }
        public WindowsMvvmAuto()
        {
            PdfHelp help = new PdfHelp();
            var fullLogica = new AddUserControlFull.AddLogicaFull();
            FullWindow = fullLogica.FullWindowAdd();
            OpenForms = new DelegateCommand<object>(parametr => { FullWindow.IsCheked(parametr); });
            OpenPdfHelp = new DelegateCommand((() => {help.OpenReport(Config.ConfigFile.Help); }));
        }
    }
}
