using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Mvvm;

namespace ViewModelLib.ModelTestAutoit.PublicModel.SelectBranch
{
   public class Branch : BindableBase, IDataErrorInfo
   {
       internal Branch _branch;
        /// <summary>
        /// Выбор ветви для обработки
        /// </summary>
        public ObservableCollection<Branch> BranchSelect { get; set; } = new ObservableCollection<Branch>();
        /// <summary>
        /// Выбранная ветка
        /// </summary>
        public Branch Select
        {
            get { return _branch; }
            set
            {
                _branch = value;
                RaisePropertyChanged();
            }
        }
        /// <summary>
        /// Имя ветки для отработки
        /// </summary>
        public string NameBranch { get; set; }
        /// <summary>
        /// Программный номер ветки
        /// </summary>
        public int NumBranch { get; set; }


        public string Error { get; set; }
        private bool IsValid { get; set; } = true;
        public string this[string columnName]
        {
            get { return ValidateErrs(columnName); }
        }
        public bool IsValidation()
        {
            IsValid = false;
            RaisePropertyChanged("Select");
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
                    case "Select":
                        if (Select != null)
                        { break; }
                        { Error = "Не выбранна ветка для отработки!!!"; break; }
                }
            return Error;
        }
    }
}
