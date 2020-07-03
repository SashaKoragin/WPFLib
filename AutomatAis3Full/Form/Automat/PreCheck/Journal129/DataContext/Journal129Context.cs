using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibaryCommandPublic.TestAutoit.PreCheck.ReportingMemo;
using Prism.Commands;
using ViewModelLib.ModelTestAutoit.PublicModel.ButtonStartAutomat;

namespace AutomatAis3Full.Form.Automat.PreCheck.Journal129.DataContext
{
   public class Journal129Context
    {
        public StatusButtonMethod Start { get; }
        public Journal129Context()
        {
            var reportMemoStart = new ReportingMemoStart();
            Start = new StatusButtonMethod
            {
                Button = { Command = new DelegateCommand(() => { reportMemoStart.StatusJournal129(Start); }) }
            };
        }
    }
}
