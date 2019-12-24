using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutomatAis3Full.Config;
using LibaryCommandPublic.TestAutoit.Uregulirovanie.DebtRelief;
using Prism.Commands;
using ViewModelLib.ModelTestAutoit.PublicModel.ButtonStartAutomat;

namespace AutomatAis3Full.Form.Automat.Uregulirovanie.SenderSpravk.DataContext
{
   public class DataContextSenderSpravk
    {
        public StatusButtonMethod StartButton { get; }

        public DataContextSenderSpravk()
        {
            StartButton = new StatusButtonMethod();
            var commandauto = new DeptRelief();
            StartButton.Button.Command = new DelegateCommand(() => { commandauto.SenderSpravk(StartButton, ConfigFile.FileJurnalOk); });
        }
    }
}
