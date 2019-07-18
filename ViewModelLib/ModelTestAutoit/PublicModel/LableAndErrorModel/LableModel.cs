using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using Prism.Mvvm;

namespace ViewModelLib.ModelTestAutoit.PublicModel.LableAndErrorModel
{
   public class LableModel  : BindableBase
   {
       private Brush _color;
        private string _messageReport;
        public string MessageReport
        {
            get { return _messageReport; }
            set
            {
                _messageReport = value;
                 RaisePropertyChanged();
            }
        }

        public Brush Color
        {
            get { return _color; }
            set
            {
                _color = value;
                RaisePropertyChanged();
            }
        }
    }
}
