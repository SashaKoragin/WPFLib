using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using AutomatAis3Full.Config;
using LibaryCommandPublic.TestAutoit.Okp3.UsnSend;
using Prism.Commands;
using ViewModelLib.ModelTestAutoit.PublicModel.ButtonStartAutomat;

namespace AutomatAis3Full.Form.Automat.Okp3.UsnSend.DataContext
{
    class DataContextUsnSend
    {

        public StatusButtonMethod StartButton { get; }

        public DataContextUsnSend()
        {
            var command = new CommandUsn();
            StartButton = new StatusButtonMethod();
            StartButton.Button.Command = new DelegateCommand(() => { command.UsnStart(StartButton, ConfigFile.FileJurnalError, ConfigFile.FileJurnalOk); });
        }
    }
}
