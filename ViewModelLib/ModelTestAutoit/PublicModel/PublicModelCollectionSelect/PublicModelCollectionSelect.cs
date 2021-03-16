using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using Prism.Mvvm;

namespace ViewModelLib.ModelTestAutoit.PublicModel.PublicModelCollectionSelect
{
   public class PublicModelCollectionSelect<T> : BindableBase, IDataErrorInfo
    {
        public PublicModelCollectionSelect(T[] models)
        {
            foreach (var model in models)
            {
                ModelCollection.Add(model);
            }
        }

        public PublicModelCollectionSelect(List<T> models)
        {
            models.ForEach(x=>ModelCollection.Add(x));
            Enumerable.Range(2020, DateTime.Today.Year-2019).ToList().ForEach(y => CollectionYear.Add(y));
        }

        internal T _selectModel { get; set; }
        /// <summary>
        /// Выбор ветви для обработки
        /// </summary>
        public ObservableCollection<T> ModelCollection { get; set; } = new ObservableCollection<T>();


        public ObservableCollection<int> SelectModelCollection
        {
            get;
            set;
        } = new ObservableCollection<int>();

        /// <summary>
        /// Выбранная ветка
        /// </summary>
        public T SelectModel
        {
            get { return _selectModel; }
            set
            {
                _selectModel = value;
                RaisePropertyChanged();
            }
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
            RaisePropertyChanged("SelectModel");
            if (!String.IsNullOrEmpty(Error))
            {
                return IsValid;
            }
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
                    case "SelectModel":
                        if (SelectModel != null)
                        { break; }
                    { Error = "Не выбрано не одного шаблона!!!"; break; }
                    case "YearReport":
                        var templateParameter = new[] {1}; //Шаблоны зависящие от выбора года - 3
                        if (SelectModelCollection.FirstOrDefault(parameter => templateParameter.Contains(parameter)) != 0)
                        {
                            if (YearReport != 0)
                            {
                                break;
                            }

                            {
                                Error = $"Для шаблонов c УН:  {string.Join("", templateParameter)} требуется выбор отчетного года!";
                            }
                        }
                        break;

                }
            return Error;
        }

        /// <summary>
        /// Выбираем Модель
        /// </summary>
        /// <param name="param">Объект выбора</param>
        public void SelectModelTemplate(object param)
        {
            SelectModelCollection.Add((int)param);
        }
        /// <summary>
        /// Удаляем Модель
        /// </summary>
        /// <param name="param">Объект выбора</param>
        public void DeleteModelTemplate(object param)
        {
            SelectModelCollection.Remove(SelectModelCollection.Single(parameter => parameter.Equals((int)param)));
        }

    }

   public class UniversalCollection
   {
        public string NameParameter { get; set; }
        public int? Parameter { get; set; }
    }
}
