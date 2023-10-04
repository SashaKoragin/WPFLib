using AutomatAis3Full.Config;
using LibraryCommandPublic.TestAutoit.Orn.TaskOrn;
using Prism.Commands;
using ViewModelLib.ModelTestAutoit.PublicModel.ButtonStartAutomat;
using ViewModelLib.ModelTestAutoit.PublicModel.ModelDatePickerAdd;

namespace AutomatAis3Full.Form.Automat.Orn.Ion.FaceRegistryReference.DataContextFaceRegistryReference
{
    public class DataContextFaceRegistryReference
    {

        public StatusButtonMethod StartButton { get; }

        public DataContextFaceRegistryReference()
        {
            var command = new TaskOrn();
            StartButton = new StatusButtonMethod();
            StartButton.Button.Command = new DelegateCommand(() => { command.FaceRegistryReference(StartButton); });
        }
    }
}
