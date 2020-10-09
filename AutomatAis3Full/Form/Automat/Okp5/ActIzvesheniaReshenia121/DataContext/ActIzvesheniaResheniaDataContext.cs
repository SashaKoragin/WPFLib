using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutomatAis3Full.Config;
using LibraryCommandPublic.TestAutoit.Okp5.Identification;
using Prism.Commands;
using ViewModelLib.ModelTestAutoit.PublicModel.ButtonStartAutomat;
using ViewModelLib.ModelTestAutoit.PublicModel.ModelDatePickerAdd;

namespace AutomatAis3Full.Form.Automat.Okp5.ActIzvesheniaReshenia121.DataContext
{
   public class ActIzvesheniaResheniaDataContext
    {

        public StatusButtonMethod StartButton { get; }

        public DatePickerAdd DatePicker { get; }

        public ActIzvesheniaResheniaDataContext()
        {
            DatePicker = new DatePickerAdd();
            var command = new IdentificationFace();
            StartButton = new StatusButtonMethod();
            StartButton.Button.Command = new DelegateCommand(() => { command.StartRegisterDeclarations(StartButton, ConfigFile.PathPdfTemp, DatePicker); });
        }
    }
}
