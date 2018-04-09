using System;
using System.ComponentModel;
using Prism.Mvvm;

namespace ViewModelLib.ModelTestAutoit.ModelFormirovanie.CheckBoxModel
{
    /// <summary>
    /// Галка использовать заголовок или нет!!!
    /// А также с какой строки начинать
    /// И ограничение значений для коллекции элементов полле ввода
    /// </summary>
   public class CheckBoxModel : BindableBase, IDataErrorInfo
    {
        /// <summary>
        /// Строки в Excel Файле
        /// </summary>
        private int[] _numrow = {1,2,3,4,5};
        /// <summary>
        /// С какой строки начинать 
        /// </summary>
        public int[] NumRow
        {
            get {return _numrow; }
            set
            {
                _numrow = value;
                RaisePropertyChanged();
            }
        }
        /// <summary>
        /// Выбранная строка
        /// </summary>
        public int SelectIntRow { get; set; }

        private bool _ischekced = false;
        private int _colelementcollection;

        /// <summary>
        /// Убрать заголовок в Excel
        /// </summary>
       public bool IsCheced
       {
           get { return _ischekced; }
           set
           {
               _ischekced = value;
                RaisePropertyChanged();
            }
       }

        public int Colelementcollection
        {
            get { return _colelementcollection; }
            set
            {
                _colelementcollection = value;
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
            RaisePropertyChanged("SelectIntRow");
            RaisePropertyChanged("Colelementcollection");
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
                    case "SelectIntRow":
                        if (SelectIntRow!=0)
                        {  break; }
                        { Error = "Не выбрана строка с которай конвертируем список"; break; }
                    case "Colelementcollection":
                        if (Colelementcollection != 0)
                        {  break;}
                        { Error = "Колличество элементов не может быть равно 0"; break;}
                }
            return Error;
        }

        public void IsChek()
       {
           if (IsCheced)
           {
               IsCheced = false;
           }
           else
           {
               IsCheced = true;
           }
       }
   }
}
