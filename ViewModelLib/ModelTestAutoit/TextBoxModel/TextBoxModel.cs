using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Mvvm;

namespace ViewModelLib.ModelTestAutoit.TextBoxModel
{
   public class TextBoxModel : BindableBase,IDataErrorInfo
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

        public string Error { get; set; }
        private bool IsValid { get; set; } = true;
        public string this[string columnName]
        {
            get { return ValidateErrs(columnName); }
        }
        public bool IsValidation()
        {
            IsValid = false;
            RaisePropertyChanged("Path");
            return IsValid;
        }

        private string ValidateErrs(string columnName)
        {
            Error = null;
            if (!IsValid)
                switch (columnName)
                {
                    case "Path":
                        if (File.Exists(Path))
                        { IsValid = true; break; }
                        { Error = "Не выбран файл XLSX"; break; }
                }
            return Error;
        }

    }
}
