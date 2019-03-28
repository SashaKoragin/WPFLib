using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace TestDynamicElement.ViewModel
{
  public class VieWModel
    {
        public Model.Model Model { get; set; }

        public ICommand Update { get; }

        public VieWModel()
        {
            Model = new Model.Model();
            Model.AddModel();
            Update = new DelegateCommand(() => { Model.AddElement(); });
        }


    }
}
