using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using AutomatAis3Full.Config;
using LibraryCommandPublic.TestAutoit.Okp5.Identification;
using Prism.Commands;
using ViewModelLib.ModelTestAutoit.PublicModel.ButtonStartAutomat;
using ViewModelLib.ModelTestAutoit.PublicModel.ModelDatePickerAdd;

namespace AutomatAis3Full.Form.Automat.Okp5.Identification.DataContext
{
   public class FaceIdentificationDataContext
    {

        public StatusButtonMethod StartButton { get; }

        /// <summary>
        /// VM DataContext
        /// </summary>
        public FaceIdentificationDataContext()
        {
            var command = new IdentificationFace();
            StartButton = new StatusButtonMethod();
            StartButton.Button.Command = new DelegateCommand(() => { command.StartIdentification(StartButton); });
        }
    }
}
