using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Configuration;
using System.Text.RegularExpressions;
using Prism.Mvvm;

namespace AutomatAis3Full.Config
{
    public class ModelEditConfig : BindableBase, IDataErrorInfo
    {

        public string _ifns = String.Empty;
        /// <summary>
        /// Инспекция
        /// </summary>
        public string Ifns
        {
            get { return _ifns; }
            set
            {
                _ifns = value;
                RaisePropertyChanged();
            }
        }

        /// <summary>
        /// Заполнение строк массива
        /// </summary>
        public ModelEditConfig()
        {
            var exeptions = ConfigurationManager.AppSettings["ExeptionsIfns"].Split(',');
            if (exeptions[0] != "")
            {
                foreach (var strexeption in exeptions)
                {
                    ExceptionIfns.Add(strexeption);
                }
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
            RaisePropertyChanged("Ifns");
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
                    case "Ifns":
                        if (!String.IsNullOrWhiteSpace(Ifns))
                        {
                            Regex regex = new Regex("[^0-9]+");
                            if (!regex.IsMatch(Ifns)&&(Ifns.ToCharArray().Length==12 | Ifns.ToCharArray().Length == 10))
                            {
                                break;
                            }
                            Error = "Не соответтствует номеру ИНН"; break;
                        }
                        Error = "ИНН не может быть равно NULL"; break;
                }
            return Error;
        }


        /// <summary>
        /// Коллекция исключений
        /// </summary>
        public ObservableCollection<string> ExceptionIfns { get; set; } = new ObservableCollection<string>();

        /// <summary>
        /// Добавление исключения для Инспекции
        /// </summary>
        public void AddExeptionIfns()
        {
            if (IsValidation())
            {
                ExceptionIfns.Add(Ifns);
                UpdateConfig();
            }
        }

        /// <summary>
        /// Удаление Исключения из списка
        /// </summary>
        public void DeleteExeptionIfns(string param)
        {
            ExceptionIfns.Remove(param);
            UpdateConfig();
        }

        private void UpdateConfig()
        {
            var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings["ExeptionsIfns"].Value = String.Join(",", ExceptionIfns);
            config.Save(ConfigurationSaveMode.Modified);
        }
    }
}
