using AutomatAis3Full.Config;
using LibraryCommandPublic.TestAutoit.It.Rule;
using Prism.Commands;
using ViewModelLib.ModelTestAutoit.PublicModel.ButtonStartAutomat;

namespace AutomatAis3Full.Form.Automat.It.UserTemplateAndRule.DataContext
{
   public class UserTemplateAndRuleDataContext
    {
        /// <summary>
        /// Шаблон кнопки
        /// </summary>
        public StatusButtonMethod StartButton { get; }

        /// <summary>
        /// DataContext
        /// </summary>
        public UserTemplateAndRuleDataContext()
        {
            var command = new ItRuleParse();
            StartButton = new StatusButtonMethod();
            StartButton.Button.Command = new DelegateCommand(() => { command.UserTemplateRule(StartButton, ConfigFile.InfoUserTemplateRule); });
        }
    }
}
