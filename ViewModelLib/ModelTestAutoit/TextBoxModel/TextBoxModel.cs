using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Mvvm;

namespace ViewModelLib.ModelTestAutoit.TextBoxModel
{
   public class TextBoxModel : BindableBase
    {

        /// <summary>
        /// Иконка файла
        /// </summary>
        private Icon _icon;
        /// <summary>
        /// Имя файла
        /// </summary>
        private string _name;
        /// <summary>
        /// Путь к файлу
        /// </summary>
        private string _path;

        public Icon Icon
        {
            get { return _icon; }
            set
            {
                _icon = value;
                RaisePropertyChanged();
            }
        }

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                RaisePropertyChanged();
            }
        }

        public string Path
        {
            get { return _path; }
            set
            {
                _path = value;
                RaisePropertyChanged();
            }
        }
    }
}
