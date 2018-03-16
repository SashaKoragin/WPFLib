using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Mvvm;

namespace ViewModelLib.ModelTestAutoit.ModelSnuOneAuto.DataXml
{
   public class XmlUse : BindableBase
   {
       private string _name;
        private Icon _icon;
        private int _count;

       public string Name
       {
           get { return _name; }
           set
           {
               _name = value; 
               RaisePropertyChanged("Name");
           }
       }

       public int Count
       {
           get { return _count; }
           set
           {
               _count = value;
               RaisePropertyChanged("Count");
           }
       }

       public Icon Icon
       {
           get { return _icon; }
           set
           {
               _icon = value; 
               RaisePropertyChanged();
           }
       }
        
   }
}
