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
        public ModelEditConfig EditConfig { get; }
        public ICommand AddException { get; }
        public ICommand DeleteException { get; }
        public MigrationContext()
        {
            EditConfig = new ModelEditConfig();
            AddException = new DelegateCommand((() => { EditConfig.AddExeptionIfns(); }));
            DeleteException = new DelegateCommand<string>(param=> { EditConfig.DeleteExeptionIfns(param); });
            Select = new SelectVibor();
            Select.SelectMigrationVibor();
            var migration = new MigrationClickCommand();
            Start = new StatusButtonMethod {IsChekcs = true};
            Start.Button.Command = new DelegateCommand(() => { migration.AutoClickMigration(Start, Select, ConfigFile.ReportMigration, ConfigFile.Ifns, EditConfig.ExceptionIfns);  });
        }
    }
}
