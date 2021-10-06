using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutomatAis3Full.Config;
using LibraryCommandPublic.TestAutoit.Okp5.Identification;
using Prism.Commands;
using ViewModelLib.ModelTestAutoit.PublicModel.ButtonStartAutomat;

namespace AutomatAis3Full.Form.Automat.Registration.AcceptanceDocuments.DataContext
{
   public class DataContextAcceptanceDocuments
    {

        public StatusButtonMethod StartButton { get; }


        public DataContextAcceptanceDocuments()
        {

            var command = new LibraryCommandPublic.TestAutoit.Reg.AcceptanceDocuments.AcceptanceDocuments();
            StartButton = new StatusButtonMethod();
            StartButton.Button.Command = new DelegateCommand(() => { command.StartAcceptanceDocuments(StartButton); });
        }

    }
}
