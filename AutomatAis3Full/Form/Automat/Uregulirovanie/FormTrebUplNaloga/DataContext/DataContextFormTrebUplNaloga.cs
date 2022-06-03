using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutomatAis3Full.Config;
using Prism.Commands;
using ViewModelLib.ModelTestAutoit.PublicModel.ButtonStartAutomat;

namespace AutomatAis3Full.Form.Automat.Uregulirovanie.FormTrebUplNaloga.DataContext
{
   public class DataContextFormTrebUplNaloga
    {
        public StatusButtonMethod StartButton { get; }

        public DataContextFormTrebUplNaloga()
        {
            StartButton = new StatusButtonMethod();
            var commandauto = new LibraryCommandPublic.TestAutoit.Uregulirovanie.MessageLk.AutoMessageLk();
            StartButton.Button.Command = new DelegateCommand(() => { commandauto.FormRequirementUplTax(StartButton); });
        }
    }
}
