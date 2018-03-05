using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Mvvm;

namespace ViewModelLib.ModelTestAutoit.StackPanelModel.ShemeSnuOneForm
{
    /// <summary>
    /// Модель генерации списков TestAutoit SnuOneForm
    /// </summary>
   public class ModelSnuOneFormNameList : BindableBase
    {
        /// <summary>
        /// Схема листов с колонками
        /// </summary>
        public ObservableCollection<ModelSnuOneFormNameList> _shemefulllist = new ObservableCollection<ModelSnuOneFormNameList>();
        /// <summary>
        /// Схема колонок
        /// </summary>
        public ObservableCollection<NameColumn> _shemeLetter = new ObservableCollection<NameColumn>();

        public ObservableCollection<ModelSnuOneFormNameList> ShemeFull
        {
            get { return _shemefulllist; }
        }

        public ObservableCollection<NameColumn> ShemeColumn
        {
            get { return _shemeLetter; }
            set { _shemeLetter = value; }
        }

        private ModelSnuOneFormNameList _selectList;


        /// <summary>
        /// Присваиваем выбор и передаем колекции элементов для манипуляции
        /// </summary>
        public ModelSnuOneFormNameList SelectList
        {
            get { return _selectList; }
            set { _selectList = value; }
        }

        private string _list;
        /// <summary>
        /// Листы в XSLX файле
        /// </summary>
        public string Listletter
        {
            get { return _list; }
            set { _list = value; }
        }
        /// <summary>
        /// Имена колонок заполненые
        /// </summary>
        public class NameColumn
        {

            private string _columnname;
            /// <summary>
            /// Имена колонок A,B,C и т,д по алфавиту
            /// </summary>
            public string ColumnName
            {
                get { return _columnname; }
                set { _columnname = value; }
            }
        }
    }
}
