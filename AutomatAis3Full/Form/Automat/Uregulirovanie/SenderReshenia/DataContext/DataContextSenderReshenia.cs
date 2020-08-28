using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutomatAis3Full.Config;
using LibraryCommandPublic.TestAutoit.Uregulirovanie.DebtRelief;
using Prism.Commands;
using ViewModelLib.ModelTestAutoit.PublicModel.ButtonStartAutomat;

namespace AutomatAis3Full.Form.Automat.Uregulirovanie.SenderReshenia.DataContext
{
   public class DataContextSenderReshenia
    {

        public StatusButtonMethod StartButton { get; }

        public DataContextSenderReshenia()
        {
            StartButton = new StatusButtonMethod();
            var commandauto = new DeptRelief();
            StartButton.Button.Command = new DelegateCommand(() => { commandauto.SendeReshenia(StartButton, ConfigFile.FileJurnalOk); });
        }
    }
}
