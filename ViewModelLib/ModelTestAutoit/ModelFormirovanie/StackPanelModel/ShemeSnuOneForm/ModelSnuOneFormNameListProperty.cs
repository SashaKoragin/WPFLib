using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Mvvm;

namespace ViewModelLib.ModelTestAutoit.ModelFormirovanie.StackPanelModel.ShemeSnuOneForm
{
    /// <summary>
    /// Модель генерации списков TestAutoit SnuOneForm
    /// Моя самая лучшая модель сложность (образец выбора из другой коллекции) 
    /// </summary>
   public class ModelSnuOneFormNameListProperty : BindableBase, IDataErrorInfo
    {
        /// <summary>
        /// Схема листов с колонками
        /// </summary>
        public ObservableCollection<ModelSnuOneFormNameListProperty> Shemefulllist = new ObservableCollection<ModelSnuOneFormNameListProperty>();

        /// <summary>
        /// Колонки Excel
        /// </summary>
        public ObservableCollection<NameColumn> Columns { get; set; }
        public ObservableCollection<ModelSnuOneFormNameListProperty> ShemeFull
        {
            get { return Shemefulllist; }
        }
        private ModelSnuOneFormNameListProperty _selectList;

        /// <summary>
        /// Выбор буквы сделано
        /// </summary>
        private NameColumn _selectcColumnLetter;

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
        public ModelSnuOneFormNameListProperty SelectList
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
                        if (SelectColumnLetter!=null)
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
            private string _columncellvaluename;
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

            public string ColumnCellValueName
            {
                get { return _columncellvaluename;}
                set
                {
                    _columncellvaluename = value;
                    RaisePropertyChanged();
                }
            }
        }
    }

    public class ModelSnuOneFormNameListMethod : ModelSnuOneFormNameListProperty
    {
        public void AddParseXsls(FileInfo file)
        {
            ShemeFull.Clear();
            var worbook = new ClosedXML.Excel.XLWorkbook(file.FullName);
            foreach (var workSneets in worbook.Worksheets)
            {
                var excelcolumn = new NameColumn();
                foreach (var column in workSneets.ColumnsUsed(column => !column.IsEmpty()))
                {
                    excelcolumn.ShemeLetter.Add(new NameColumn() { ColumnName = column.ColumnLetter(), ColumnCellValueName = column.ColumnLetter() + "-" + column.Cell(1).Value });
                }
                ShemeFull.Add(new ModelSnuOneFormNameListProperty() { Listletter = workSneets.Name, Columns = excelcolumn.ShemeLetter });
            }
        }
    }
}
