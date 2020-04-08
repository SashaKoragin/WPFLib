using AutomatAis3Full.Config;
using LibaryCommandPublic.TestAutoit.RaschBydj.Vedomost1;
using Prism.Commands;
using ViewModelLib.ModelTestAutoit.PublicModel.ButtonStartAutomat;
using ViewModelLib.ModelTestAutoit.PublicModel.RaschetBuh;

namespace AutomatAis3Full.Form.Automat.RaschetBudg.VedRazd1.DataContext
{
   public class VedRazd1
    {
        public StatusButtonMethod Start { get; }

        public SelectVibor Select { get; }
        public VedRazd1()
        {
            Select = new SelectVibor();
            Select.SelectViborVedomosty();
            var ved1 = new  StartVedomost1();
            Start = new StatusButtonMethod();
            Start.Button.Command = new DelegateCommand(()=> { ved1.AutoClicsVed1(Start, Select, ConfigFile.FileJurnalError, ConfigFile.FileJurnalOk); });
        }
    }
}
