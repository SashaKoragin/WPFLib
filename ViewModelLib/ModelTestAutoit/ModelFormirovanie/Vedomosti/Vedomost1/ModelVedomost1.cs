using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Mvvm;

namespace ViewModelLib.ModelTestAutoit.ModelFormirovanie.Vedomosti.Vedomost1
{
   public class ModelVedomost1 : BindableBase, IDataErrorInfo
   {
       private DateTime _date = DateTime.Now;
       private int _summ;
       private string _statuspl;
       private string _kbk;
       private string _kbkparal;
        private bool _ischekced;

        /// <summary>
        /// Проставить выборку?
        /// </summary>
        public bool IsCheced
        {
            get { return _ischekced; }
            set
            {
                _ischekced = value;
            }
        }

        /// <summary>
        /// Дата
        /// </summary>
        public DateTime Date
       {
           get { return _date; }
           set
           {
               _date = value;
           }
       }
       /// <summary>
       /// Сумма
       /// </summary>
        public int Summ
        {
            get { return _summ; }
            set
            {
                _summ = value;
            }
        }
        /// <summary>
        /// Статус платежа
        /// </summary>
        public string StatusPl
        {
            get { return _statuspl; }
            set
            {
                _statuspl = value;
            }
        }
        /// <summary>
        /// КБК
        /// </summary>
        public string KbkRaspr
        {
            get { return _kbk; }
            set
            {
                _kbk = value;
            }
        }

        /// <summary>
        /// КБК Паралельно УФК
        /// </summary>
        public string Kbk
        {
            get { return _kbkparal; }
            set
            {
                _kbkparal = value;
               // RaisePropertyChanged();
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
            RaisePropertyChanged("Date");
            RaisePropertyChanged("Summ");
            RaisePropertyChanged("StatusPl");
            RaisePropertyChanged("KbkRaspr");
            RaisePropertyChanged("Kbk");
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
                    case "Date":
                        if (Date != DateTime.MinValue)
                        { break; }
                        { Error = "Не выбрана дата в календаре!!!"; break; }
                    case "Summ":
                        if (Summ != 0)
                        { break; }
                        { Error = "Сумма не может быть равна 0"; break; }
                    case "StatusPl":
                        if (!String.IsNullOrWhiteSpace(StatusPl))
                        { break; }
                        { Error = "Статус прлатежа не может быть пустой!!!"; break; }
                    case "KbkRaspr":
                        if (!String.IsNullOrWhiteSpace(KbkRaspr))
                        { break; }
                        { Error = "КБK паралельного УФК не может быть пустой!!!"; break; }
                    case "Kbk":
                        if (!String.IsNullOrWhiteSpace(Kbk))
                        { break; }
                        { Error = "КБK не может быть пустой!!!"; break; }
                }
            return Error;
        }
    }
}
