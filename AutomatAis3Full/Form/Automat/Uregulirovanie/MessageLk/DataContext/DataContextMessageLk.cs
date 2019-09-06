using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutomatAis3Full.Config;
using Prism.Commands;
using ViewModelLib.ModelTestAutoit.PublicModel.ButtonStartAutomat;

namespace AutomatAis3Full.Form.Automat.Uregulirovanie.MessageLk.DataContext
{
   public class DataContextMessageLk
    {

        public StatusButtonMethod StartButton { get; }

        public DataContextMessageLk()
        {
            StartButton = new StatusButtonMethod();
            var commandauto = new LibaryCommandPublic.TestAutoit.Uregulirovanie.MessageLk.AutoMessageLk();
            StartButton.Button.Command = new DelegateCommand(() => { commandauto.MessageLk(StartButton, ConfigFile.FileJurnalError, ConfigFile.FileJurnalOk); });
        }
    }
}
