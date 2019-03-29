using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Prism.Commands;

namespace TestDynamicElement.MoveXaml.ViewModel
{
   public class ViewModel
    {

        public Model.Logica Model { get; }

        public ICommand Command { get; }
        

        public ViewModel()
        {
            Model = new Model.Logica();
            Model.AddModel();
            Command = new DelegateCommand(() => { Model.Clones(); });
            

        }
    }
}
