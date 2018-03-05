using System.Collections.ObjectModel;
using System.ComponentModel;
using Lotuslib.Formula.Otdel;
using Prism.Mvvm;

namespace Lotuslib.StatusZG
{
   public class Status : BindableBase, IDataErrorInfo
    {
        public ObservableCollection<Status> Statuszgcollection = new ObservableCollection<Status>();
        public ObservableCollection<Status> StatusZgCollection
        {
            get { return Statuszgcollection; }
        }

        public Status Selectstatus;

        public Status SelectStatus
        {
            get { return Selectstatus; }
            set { Selectstatus = value; }
        }
        /// <summary>
        /// Название статуса
        /// </summary>
        private string name;
        /// <summary>
        /// Сам статус
        /// </summary>
        private string status;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string StatusZg
        {
            get { return status; }
            set { status = value; }
        }

        /// <summary>
        /// Попадание ошибки
        /// </summary>
        public string Error { get; set; }

        /// <summary>
        /// Проверка состояния объектов
        /// </summary>
        private bool _isValid { get; set; } = true;
        /// <summary>
        /// Метод проверки данных
        /// </summary>
        /// <returns>true and false</returns>
        public bool IsValidation()
        {
            _isValid = false;
            RaisePropertyChanged("SelectStatus");
            return _isValid;
        }
        /// <summary>
        /// Интерфейс по проверки ошибки
        /// </summary>
        /// <param name="columnName"></param>
        /// <returns></returns>
        public string this[string columnName]
        {
            get { return ValidateErrs(columnName); }
        }
        /// <summary>
        /// Собственно сама реализация проверки достоверности по IDataErrorInfo
        /// </summary>
        /// <param name="columnName">Проверяемая колонка</param>
        /// <returns></returns>
        private string ValidateErrs(string columnName)
        {
            Error = null;
            if(!_isValid)
            switch (columnName)
            {
                case "SelectStatus":
                    if (SelectStatus != null)
                    { _isValid = true; break; }
                    { Error = "Для данной выборки нужен статус!!!"; break; }
            }
            return Error;
        }
    }

}
