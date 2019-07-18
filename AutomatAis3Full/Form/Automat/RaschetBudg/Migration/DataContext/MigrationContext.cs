using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using AutomatAis3Full.Config;
using LibaryCommandPublic.TestAutoit.RaschBydj.Migration;
using Prism.Commands;
using Prism.Events;
using ViewModelLib.ModelTestAutoit.ModelSnuOneAuto.DataXml;
using ViewModelLib.ModelTestAutoit.PublicModel.ButtonStartAutomat;
using ViewModelLib.ModelTestAutoit.PublicModel.RaschetBuh;

namespace AutomatAis3Full.Form.Automat.RaschetBudg.Migration.DataContext
{
   public class MigrationContext
    {
        public StatusButtonMethod Start { get; }
        public SelectVibor Select { get; }
        public DelegateCommand Vibor { get; }
        public MigrationContext()
        {
            Select = new SelectVibor();
            Select.SelectMigrationVibor();
            var migration = new MigrationCKlikCommand();
            Start = new StatusButtonMethod {IsChekcs = true};
            Start.Button.Command = new DelegateCommand(() => { migration.AutoCklikMigration(Start, ConfigFile.ReportMigration);  });
            Vibor = new DelegateCommand(()=>migration.SendParametr(Select));
        }
    }
}
