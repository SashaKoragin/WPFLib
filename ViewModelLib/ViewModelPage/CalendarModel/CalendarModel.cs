using System;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Controls;
using System.Windows.Input;
using Prism.Commands;
using Prism.Mvvm;
using ViewModelLib.Annotations;

namespace ViewModelLib.ViewModelPage.CalendarModel
{
   public class CalendarModel : BindableBase, IDataErrorInfo
    {
       public DateTime Stardatetime = DateTime.Today;
       public DateTime Enddatatime = DateTime.Today;
       public SelectedDatesCollection _collection { get; set;}

        ICommand _selectionCommand;

       

        public ICommand SelectionCommand
        {
            get
            {
                if (_selectionCommand == null)
                {
                    _selectionCommand = new DelegateCommand<object>(a =>
                    {
                        _collection = a as SelectedDatesCollection;
                        if (_collection != null)
                        {
                            EndDateTime = _collection.Max(x => x.Date);
                            StartDateTime = _collection.Min(y => y.Date);
                        }
                    });
                }
                return _selectionCommand;
            }
        }

        public DateTime StartDateTime
       {
            get { return Stardatetime; }
            set
            {
                Stardatetime = value;
                RaisePropertyChanged();
            }
       }

        public DateTime EndDateTime
        {
            get { return Enddatatime; }
            set
            {
                Enddatatime = value;
                RaisePropertyChanged();
            }
        }
        /// <summary>
        /// Попадание ошибки
        /// </summary>
        public string Error { get; set; }
        /// <summary>
        /// Проверка состояния объектов
        /// </summary>
        private bool _isValid;
        /// <summary>
        /// Метод проверки данных
        /// </summary>
        /// <returns>true and false</returns>
        public bool IsValidation()
        {
            // _isValid = false;
            RaisePropertyChanged("StartDateTime");
            RaisePropertyChanged("EndDateTime");
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
            _isValid = false;
            Error = null;
            switch (columnName)
            {
                case "StartDateTime":
                    if (StartDateTime <= DateTime.Today)
                    { _isValid = true; break; }
                    { Error = "Дата не может превышать сегодняшнюю дату!!!"; break; }
                case "EndDateTime":
                    if (EndDateTime <= DateTime.Today)
                    { _isValid = true; break; }
                    { Error = "Дата не может превышать сегодняшнюю дату!!!"; break; }
            }
            return Error;
        }
    }
}
