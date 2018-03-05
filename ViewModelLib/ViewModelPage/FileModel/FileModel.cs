using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Mvvm;

namespace ViewModelLib.ViewModelPage.FileModel
{
   public class FileModel : BindableBase
    {
        public ObservableCollection<FileModel> ShemeFileModel { get; set; }

        public string Namefile;

        public string PathDb
        {
            get { return Namefile; }
            set { Namefile = value; }
        }
    }
}
