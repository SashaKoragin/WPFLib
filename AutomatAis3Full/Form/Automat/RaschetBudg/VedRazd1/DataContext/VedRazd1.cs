using LibraryCommandPublic.TestAutoit.RaschBydj.Vedomost1;
using Prism.Commands;
using ViewModelLib.ModelTestAutoit.PublicModel.ButtonStartAutomat;

namespace AutomatAis3Full.Form.Automat.RaschetBudg.VedRazd1.DataContext
{
   public class VedRazd1
    {
        public StatusButtonMethod Start { get; }

        public VedRazd1()
        {
            var ved1 = new  StartVedomost1();
            Start = new StatusButtonMethod();
            Start.Button.Command = new DelegateCommand(()=> { ved1.AutoClicsVed1(Start); });
        }
    }
}
