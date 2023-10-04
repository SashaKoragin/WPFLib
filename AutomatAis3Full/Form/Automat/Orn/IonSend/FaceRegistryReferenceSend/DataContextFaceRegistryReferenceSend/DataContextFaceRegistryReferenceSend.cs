using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryCommandPublic.TestAutoit.Orn.TaskOrn;
using Prism.Commands;
using ViewModelLib.ModelTestAutoit.PublicModel.ButtonStartAutomat;

namespace AutomatAis3Full.Form.Automat.Orn.IonSend.FaceRegistryReferenceSend.DataContextFaceRegistryReferenceSend
{
    public class DataContextFaceRegistryReferenceSend
    {
        public StatusButtonMethod StartButton { get; }

        public DataContextFaceRegistryReferenceSend()
        {
            var command = new TaskOrn();
            StartButton = new StatusButtonMethod();
            StartButton.Button.Command = new DelegateCommand(() => { command.FaceRegistryReferenceSend(StartButton); });
        }
    }
}
