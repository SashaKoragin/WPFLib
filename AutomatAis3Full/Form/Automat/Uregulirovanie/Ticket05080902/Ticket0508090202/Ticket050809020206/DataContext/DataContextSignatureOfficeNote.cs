using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutomatAis3Full.Config;
using Prism.Commands;
using ViewModelLib.ModelTestAutoit.PublicModel.ButtonStartAutomat;

namespace AutomatAis3Full.Form.Automat.Uregulirovanie.Ticket05080902.Ticket0508090202.Ticket050809020206.DataContext
{
   public class DataContextSignatureOfficeNote
    {
        public StatusButtonMethod StartButton { get; }

        public DataContextSignatureOfficeNote()
        {
            StartButton = new StatusButtonMethod();
            var commandAuto = new LibraryCommandPublic.TestAutoit.Uregulirovanie.MessageLk.AutoMessageLk();
            StartButton.Button.Command = new DelegateCommand(() => { commandAuto.AutoSignatureOfficeNote(StartButton); });
        }

    }
}
