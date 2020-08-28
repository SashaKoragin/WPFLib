using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryCommandPublic.TestAutoit.Orn.TaskOrn;
using Prism.Commands;
using ViewModelLib.ModelTestAutoit.PublicModel.ButtonStartAutomat;

namespace AutomatAis3Full.Form.Automat.Orn.ConfirmationNbo.DataContext
{
   public class DataContextConfirmationNbo
    {
        public StatusButtonMethod StartButton { get; }
        public DataContextConfirmationNbo()
        {
            TaskOrn task = new TaskOrn();
            StartButton = new StatusButtonMethod();
            StartButton.Button.Command = new DelegateCommand(() => { task.ConfirmationSendNbo(StartButton); });
        }
    }
}
