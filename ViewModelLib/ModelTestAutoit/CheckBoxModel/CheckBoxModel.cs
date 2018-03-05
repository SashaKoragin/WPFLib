using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Mvvm;

namespace ViewModelLib.ModelTestAutoit.CheckBoxModel
{
   public class CheckBoxModel : BindableBase
   {
       private bool _ischekced = false;

       public bool IsCheced
       {
           get { return _ischekced; }
           set
           {
               _ischekced = value;
                RaisePropertyChanged();
            }
       }

       public void IsChek()
       {
           if (IsCheced)
           {
               IsCheced = false;
            }
           else
           {
               IsCheced = true;
           }
       }
   }
}
