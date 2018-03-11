using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Mvvm;

namespace ViewModelLib.ModelTestAutoit.StackPanelModel.ShemeSnuOneForm
{
    /// <summary>
    /// Модель генерации списков TestAutoit SnuOneForm
    /// Моя самая лучшая модель сложность (образец выбора из другой коллекции) 
    /// </summary>
   public class ModelSnuOneFormNameList : BindableBase, IDataErrorInfo
    {
        /// <summary>
        /// Схема листов с колонками
        /// </summary>
        public ObservableCollection<ModelSnuOneFormNameList> Shemefulllist = new ObservableCollection<ModelSnuOneFormNameList>();

        /// <summary>
        /// Колонки Excel
        /// </summary>
        public ObservableCollection<NameColumn> Columns { get; set; }
        public ObservableCollection<ModelSnuOneFormNameList> ShemeFull
        {
            get { return Shemefulllist; }
        }
        private ModelSnuOneFormNameList _selectList;
        /// <summary>
        /// Выбор буквы сделано
        /// </summary>
        private NameColumn _selectcColumnLetter = new NameColumn();

        /// <summary>
        /// Выбираем букву
        /// </summary>
        public NameColumn SelectColumnLetter
        {
            get { return _selectcColumnLetter; }
            set
            {
                _selectcColumnLetter = value; 
                RaisePropertyChanged();
            }
        }

        /// <summary>
        /// Присваиваем выбор и передаем колекции элементов для манипуляции
        /// </summary>
        public ModelSnuOneFormNameList SelectList
        {
            get { return _selectList; }
            set
            {
                _selectList = value;
                RaisePropertyChanged();
            }
        }

        private string _list;
        /// <summary>
        /// Листы в XSLX файле
        /// </summary>
        public string Listletter
        {
            get { return _list; }
            set
            {
                _list = value;
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
            RaisePropertyChanged("SelectList");
            RaisePropertyChanged("SelectColumnLetter");
            if (String.IsNullOrEmpty(Error))
            {
                IsValid = true;
            }
            return IsValid;
        }

        private string ValidateErrs(string columnName)
        {
            Error = null;
            if (!IsValid)
                switch (columnName)
                {
                    case "SelectList":
                        if (SelectList != null)
                        { break; }
                        { Error = "Не выбран лист"; break; }
                    case "SelectColumnLetter":
                        if (SelectColumnLetter.ColumnName != null)
                        { break;}
                        {Error = "Не выбран столбец"; break;}
                }
            return Error;
        }

        /// <summary>
        /// Имена колонок заполненые
        /// </summary>
        public class NameColumn : BindableBase
        {
            /// <summary>
            /// Схема колонок
            /// </summary>
            public ObservableCollection<NameColumn> ShemeLetter = new ObservableCollection<NameColumn>();

            private string _columnname;
            /// <summary>
            /// Имена колонок A,B,C и т,д по алфавиту
            /// </summary>
            public string ColumnName
            {
                get { return _columnname; }
                set
                {
                    _columnname = value;
                    RaisePropertyChanged();
                }
            }
        }

    }
}
