using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using TestDynamicElement.Model;

namespace TestDynamicElement.ViewModel
{
  public class VieWModel
    {
        public Model.Model Model { get; set; }

        public ICommand Update { get; }

        public ICommand Event { get; }
        public ICommand Event2 { get; }

        public ModelElem Elem { get; }

        public ICommand MoveFullXaml { get; }

        public VieWModel()
        {
            Model = new Model.Model();
            Elem = new ModelElem();
            Model.AddModel();
            Update = new DelegateCommand(() => { Model.AddElement(); });
            Event = new DelegateCommand<object>(parametr => { Model.Event(parametr);});
            Event2 = new DelegateCommand<object>(parametr => { Model.Event2(parametr); });
            MoveFullXaml = new DelegateCommand(() => Elem.MoveFullXaml());
            Elem.AddColection();
        }

        private void Button_OnLostFocus_(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Потеряли");
        }

    }
}
