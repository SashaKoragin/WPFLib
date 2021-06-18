using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Input;
using Prism.Mvvm;

namespace ViewModelLib.ModelTestAutoit.PublicModel.DataPickerItRule
{
     public class DataPickerRuleItModel : BindableBase, IDataErrorInfo
    {
        private bool IsValid { get; set; } = true;
        public string Error { get; set; }
        public string _countRow = "1000";
        /// <summary>
        /// Период от:
        /// </summary>
        public DateTime DateStart { get; set; } = DateTime.Now;

        /// <summary>
        /// Период до:
        /// </summary>
        public DateTime DateFinish { get; set; } = DateTime.Now;

        /// <summary>
        /// Количество записей
        /// </summary>
        public string CountRow
        {
            get { return _countRow; }
            set
            {
                _countRow = value;
                RaisePropertyChanged();
            }
        }

        public string this[string columnName] => ValidateErrs(columnName);

        /// <summary>
        /// Проверка Validation
        /// </summary>
        /// <returns></returns>
        public bool IsValidationFull()
        {
            IsValidationDateStart();
            IsValidationCountRow();
            return IsValid;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool IsValidationDateStart()
        {
            IsValid = false;
            RaisePropertyChanged("DateStart");
            return IsValid;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool IsValidationCountRow()
        {
            IsValid = false;
            RaisePropertyChanged("CountRow");
            return IsValid;
        }

        /// <summary>
        /// Проверка на ошибки схемы
        /// </summary>
        /// <param name="columnName">Наименование поля</param>
        /// <returns></returns>
        private string ValidateErrs(string columnName)
        {
            Error = null;
            if (!IsValid)
                switch (columnName)
                {
                    case "DateStart":
                        if (DateStart > DateFinish)
                        {
                            Error = "Период от: не может быть больше периода до:!!!";
                            break;
                        }
                    {
                        IsValid = true;
                        break;
                    }
                    case "CountRow":
                        Regex regex = new Regex("[^0-9]+");
                        if (!regex.IsMatch(CountRow))
                        {
                            IsValid = true;
                            break;
                        }
                    {
                        Error = "Не содержит последовательность чисел!!!";
                        break;
                    }
                }
            return Error;
        }
    }
}
