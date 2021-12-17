using LibraryCommandPublic.TestAutoit.RaschBydj.Krsb;
using Prism.Commands;
using ViewModelLib.ModelTestAutoit.PublicModel.ButtonStartAutomat;

namespace AutomatAis3Full.Form.Automat.RaschetBudg.Krsb.DataContext
{
   public class KrsbContext
    {

        public StatusButtonMethod Start { get; }

        /// <summary>
        /// Команда закрытия КРСБ 
        /// </summary>
        public KrsbContext()
        {
            var krsb = new StartKrsb();
            Start = new StatusButtonMethod();
            Start.Button.Command = new DelegateCommand(() => { krsb.ClosedKrsb(Start); });
        }
    }
}
