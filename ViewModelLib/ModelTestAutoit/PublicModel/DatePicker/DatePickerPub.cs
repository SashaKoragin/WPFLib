using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows.Data;
using Prism.Mvvm;

namespace ViewModelLib.ModelTestAutoit.PublicModel.DatePicker
{
    public class DatePickerPub : BindableBase, IDataErrorInfo
    {

        private DateTime _date = DateTime.Now;
        private bool IsValid { get; set; } = true;
        public string Error { get; set; }

        public DateTime Date
        {
            get { return _date; }
            set
            {
                _date = value;
               // RaisePropertyChanged();
            }
        }

        public string this[string columnName]
        {
            get { return ValidateErrs(columnName); }
        }


        /// <summary>
        /// Проверка Validation
        /// </summary>
        /// <returns></returns>
        public bool IsValidation()
        {
            IsValid = false;
            RaisePropertyChanged("Date");
            return IsValid;
        }
        /// <summary>
        /// Проверка Выбраннв ли схема
        /// </summary>
        /// <param name="columnName"></param>
        /// <returns></returns>
        private string ValidateErrs(string columnName)
        {
            Error = null;
            if (!IsValid)
                switch (columnName)
                {
                    case "Date":
                        if (Date != DateTime.MinValue)
                        {
                          if (Date > DateTime.Now)
                            { Error = "Дата не может быть больше текущей!!!"; break; }
                            { IsValid = true; break; }
                        }
                        { Error = "Не выбрана дата в календаре!!!"; break; }

                }
            return Error;
        }
    }
}
