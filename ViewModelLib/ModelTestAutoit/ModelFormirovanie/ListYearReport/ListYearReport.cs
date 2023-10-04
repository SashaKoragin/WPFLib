using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Mvvm;

namespace ViewModelLib.ModelTestAutoit.ModelFormirovanie.ListYearReport
{
    public class ListYearReport : BindableBase, IDataErrorInfo
    {

        public ListYearReport()
        {
            Enumerable.Range(2020, DateTime.Today.Year - 2020).ToList().ForEach(y => CollectionYear.Add(y));
        }

        internal int _yearReport { get; set; }
        /// <summary>
        /// Параметр год -3 от текущего параметра
        /// </summary>
        public ObservableCollection<int> CollectionYear { get; set; } = new ObservableCollection<int>();
        /// <summary>
        /// Выбор года
        /// </summary>
        public int YearReport
        {
            get { return _yearReport; }
            set
            {
                _yearReport = value;
                RaisePropertyChanged();
            }
        }

        public string this[string columnName]
        {
            get { return ValidateErrs(columnName); }
        }

        public string Error { get; set; }

        private bool IsValid { get; set; } = true;

        public bool IsValidation()
        {
            IsValid = false;
            RaisePropertyChanged("YearReport");
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
                    case "YearReport":
                        if (YearReport != 0)
                        {
                            break;
                        }
                        else
                        {
                            Error = $"Не выбран отчетный год!";
                        }
                        break;
                }
            return Error;
        }

    }
}
