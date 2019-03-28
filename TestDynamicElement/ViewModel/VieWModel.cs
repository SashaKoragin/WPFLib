using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TestDynamicElement.Model;

namespace TestDynamicElement.ViewModel
{
  public class VieWModel
    {
        public Model.Model Model { get; set; }

        public ICommand Update { get; }

        public ICommand Event { get; }

        public ModelElem Elem { get; }

        public VieWModel()
        {
            Model = new Model.Model();
            Elem = new ModelElem();
            Model.AddModel();
            Update = new DelegateCommand(() => { Model.AddElement(); });
            Event = new DelegateCommand<object>(parametr => { Model.Event(parametr);});
        }


    }
}
