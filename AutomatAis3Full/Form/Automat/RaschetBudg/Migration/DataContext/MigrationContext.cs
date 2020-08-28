using System.Windows.Input;
using AutomatAis3Full.Config;
using LibraryCommandPublic.TestAutoit.RaschBydj.Migration;
using Prism.Commands;
using ViewModelLib.ModelTestAutoit.PublicModel.ButtonStartAutomat;
using ViewModelLib.ModelTestAutoit.PublicModel.RaschetBuh;

namespace AutomatAis3Full.Form.Automat.RaschetBudg.Migration.DataContext
{
   public class MigrationContext
    {
        public StatusButtonMethod Start { get; }
        public SelectVibor Select { get; }
        public DelegateCommand Vibor { get; }

        public ModelEditConfig EditConfig { get; }

        public ICommand AddExeption { get; }
        public ICommand DeleteExeption { get; }
        public MigrationContext()
        {
            EditConfig = new ModelEditConfig();
            AddExeption = new DelegateCommand((() => { EditConfig.AddExeptionIfns(); }));
            DeleteExeption = new DelegateCommand<string>(param=> { EditConfig.DeleteExeptionIfns(param); });
            Select = new SelectVibor();
            Select.SelectMigrationVibor();
            var migration = new MigrationCKlikCommand();
            Start = new StatusButtonMethod {IsChekcs = true};
            Start.Button.Command = new DelegateCommand(() => { migration.AutoCklikMigration(Start, ConfigFile.ReportMigration,EditConfig.ExeptionsIfns);  });
            Vibor = new DelegateCommand(()=>migration.SendParametr(Select,ConfigFile.Ifns));

        }
    }
}
