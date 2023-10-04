using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Commands;
using ViewModelLib.ModelTestAutoit.PublicModel.ButtonStartAutomat;

namespace AutomatAis3Full.Form.Automat.Kao.InterrogationOfWitnesses.InterrogationOfWitnessesDataContext
{
    public class InterrogationOfWitnessesDataContext
    {
        /// <summary>
        /// Кнопка старт автомат
        /// </summary>
        public StatusButtonMethod StartButton { get; }

        /// <summary>
        /// Дата контекст
        /// </summary>
        public InterrogationOfWitnessesDataContext()
        {
            var command = new LibraryCommandPublic.TestAutoit.Kao.InterrogationOfWitnesses();
            StartButton = new StatusButtonMethod();
            StartButton.Button.Command = new DelegateCommand(() => { command.StartInterrogationOfWitnesses(StartButton); });
        }
    }
}
