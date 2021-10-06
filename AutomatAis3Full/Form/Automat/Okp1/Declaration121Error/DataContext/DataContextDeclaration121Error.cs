using LibraryCommandPublic.TestAutoit.Okp5.Identification;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using AutomatAis3Full.Config;
using ViewModelLib.ModelTestAutoit.PublicModel.ButtonStartAutomat;

namespace AutomatAis3Full.Form.Automat.Okp1.Declaration121Error.DataContext
{
   public class DataContextDeclaration121Error
    {

        public StatusButtonMethod StartButton { get; }


        public DataContextDeclaration121Error()
        {

            var command = new IdentificationFace();
            StartButton = new StatusButtonMethod();
            StartButton.Button.Command = new DelegateCommand(() => { command.StartRegisterDeclarationsErrorOkp1(StartButton, ConfigFile.PathTemp); });
        }


    }
}
