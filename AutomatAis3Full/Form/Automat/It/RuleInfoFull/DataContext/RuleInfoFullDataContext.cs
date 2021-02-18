using AutomatAis3Full.Config;
using LibraryCommandPublic.TestAutoit.It.Rule;
using Prism.Commands;
using ViewModelLib.ModelTestAutoit.PublicModel.ButtonStartAutomat;

namespace AutomatAis3Full.Form.Automat.It.RuleInfoFull.DataContext
{
   public class RuleInfoFullDataContext
    {

        public StatusButtonMethod StartButton { get; }

        public RuleInfoFullDataContext()
        {
            var command = new ItRuleParse();
            StartButton = new StatusButtonMethod();
            StartButton.Button.Command = new DelegateCommand(() => { command.RuleInfoTemplate(StartButton, ConfigFile.InfoRuleTemplate); });
        }
    }
}
