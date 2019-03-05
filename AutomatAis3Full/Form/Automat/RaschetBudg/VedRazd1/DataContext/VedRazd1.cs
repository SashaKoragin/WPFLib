using System.Windows.Forms;
using System.Windows.Input;
using AutomatAis3Full.Config;
using AutomatAis3Full.GlavnayLogika.Mvvm;
using LibaryCommandPublic.TestAutoit.RaschBydj.Vedomost1;
using Prism.Commands;
using ViewModelLib.ModelTestAutoit.ModelFormirovanie.Vedomosti.Vedomost1;
using ViewModelLib.ModelTestAutoit.PublicModel.ButtonStartAutomat;

namespace AutomatAis3Full.Form.Automat.RaschetBudg.VedRazd1.DataContext
{
   public class VedRazd1
    {

        public ModelVedomost1 ModelVedomost1 { get; }
        public StatusButtonMethod Start { get; }
        public VedRazd1()
        {
            var ved1 = new  StartVedomost1();
            ModelVedomost1 = new ModelVedomost1();
            Start = new StatusButtonMethod();
            Start.Button.Command = new DelegateCommand(()=> { ved1.AutoClicsVed1(Start, ConfigFile.FileJurnalError, ConfigFile.FileJurnalOk); });
        }
    }
}
