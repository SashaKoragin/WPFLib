﻿using AutomatAis3Full.Config;
using Prism.Commands;
using ViewModelLib.ModelTestAutoit.PublicModel.ButtonStartAutomat;

namespace AutomatAis3Full.Form.Automat.Uregulirovanie.Ticket05080902.Ticket0508090203.Ticket050809020306.DataContext
{
   public class DataContextSignatureHeadProperty
    {

        public StatusButtonMethod StartButton { get; }


        public DataContextSignatureHeadProperty()
        {
            StartButton = new StatusButtonMethod();
            var commandauto = new LibraryCommandPublic.TestAutoit.Uregulirovanie.MessageLk.AutoMessageLk();
            StartButton.Button.Command = new DelegateCommand(() => { commandauto.SignatureHeadProperty(StartButton, ConfigFile.FileJurnalError, ConfigFile.FileJurnalOk); });
        }
    }
}
