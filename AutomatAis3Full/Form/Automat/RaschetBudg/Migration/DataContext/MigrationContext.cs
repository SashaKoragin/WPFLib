using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using AutomatAis3Full.Config;
using LibaryCommandPublic.TestAutoit.RaschBydj.Migration;
using Prism.Commands;
using ViewModelLib.ModelTestAutoit.ModelSnuOneAuto.DataXml;
using ViewModelLib.ModelTestAutoit.PublicModel.ButtonStartAutomat;

namespace AutomatAis3Full.Form.Automat.RaschetBudg.Migration.DataContext
{
   public class MigrationContext
    {
        public StatusButtonMethod Start { get; }
        public MigrationContext()
        {
            var migration = new MigrationCKlikCommand();
            Start = new StatusButtonMethod();
            Start.Button.Command = new DelegateCommand(() => { migration.AutoCklikMigration(Start, ConfigFile.FileInn, ConfigFile.FileJurnalError, ConfigFile.FileJurnalOk);  });
        }
    }
}
