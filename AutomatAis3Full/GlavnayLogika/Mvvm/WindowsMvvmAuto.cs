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

namespace AutomatAis3Full.GlavnayLogika.Mvvm
{
   public class WindowsMvvmAuto
    {
        public ICommand OpenForms { get; }
        public FullWindowAutoItMethod FullWindow { get; }
        public WindowsMvvmAuto()
        {
            var fullLogica = new AddUserControlFull.AddLogicaFull();
            FullWindow = fullLogica.FullWindowAdd();
            OpenForms = new DelegateCommand<object>(parametr => { FullWindow.IsCheked(parametr); });
        }
    }

}
