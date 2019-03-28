using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using TestDynamicElement.Bonus;
using TestDynamicElement.Bonus.ViewModel;

namespace TestDynamicElement.Model
{
   public class ModelElem
   {

       public ModelElem()
       {
           xaml[0] = new Xaml1(ViewModel);
           xaml[1] = new Xaml2(ViewModel);
        }

        public ElemViewModel ViewModel = new ElemViewModel();



        public UserControl[] xaml = new UserControl[2];


        public UserControl[] Xaml  {
            get { return xaml;}
            set { xaml = value; }
        }
   }
}
