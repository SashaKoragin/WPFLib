using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Prism.Commands;
using TestDynamicElement.Bonus.Model;

namespace TestDynamicElement.Bonus.ViewModel
{
   public class ElemViewModel
    {

        public ICommand MoveText { get; }
        public  Model.ModelElem ElemModel  {get;}

        public ElemViewModel()
        {
            ElemModel = new ModelElem();
            MoveText = new DelegateCommand(() => { ElemModel.MoveText(); });
        }
    }
}
