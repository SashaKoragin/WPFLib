using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutomatAis3Full.Config;
using Prism.Commands;
using ViewModelLib.ModelTestAutoit.PublicModel.ButtonStartAutomat;

namespace AutomatAis3Full.Form.Automat.Okp2.TaxJournal.DataContext
{
   public class DataContextTaxJournal
    {

        public StatusButtonMethod StartButton { get; }

        public DataContextTaxJournal()
        {
            var command = new LibaryCommandPublic.TestAutoit.Okp2.TaxJournal();
            StartButton = new StatusButtonMethod();
            StartButton.Button.Command = new DelegateCommand(() => { command.StartTaxJournal(StartButton,ConfigFile.FileJurnalOk); });
        }
    }
}
