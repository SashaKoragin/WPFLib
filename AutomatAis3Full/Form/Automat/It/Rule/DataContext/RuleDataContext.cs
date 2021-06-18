using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutomatAis3Full.Config;
using AutomatAis3Full.Form.Automat.It.Rule.UserControl;
using LibraryCommandPublic.TestAutoit.It.Rule;
using LibraryCommandPublic.TestAutoit.Okp3.UsnSend;
using Prism.Commands;
using ViewModelLib.ModelTestAutoit.PublicModel.ButtonStartAutomat;
using ViewModelLib.ModelTestAutoit.PublicModel.DataPickerItRule;

namespace AutomatAis3Full.Form.Automat.It.Rule.DataContext
{
   public class RuleDataContext
    {
        public DataPickerRuleItModel DataPickerSettings { get; }
        public StatusButtonMethod StartButton { get; }

        public RuleDataContext()
        {
            StartButton = new StatusButtonMethod();
            DataPickerSettings = new DataPickerRuleItModel();
            var command = new ItRuleParse();
            StartButton.Button.Command = new DelegateCommand(() => { command.RuleUsers(StartButton, DataPickerSettings, ConfigFile.UserRule); });
        }
    }
}
