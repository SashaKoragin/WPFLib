using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Mvvm;
using ViewModelLib.Annotations;

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
        }

        internal T _model { get; set; }
        /// <summary>
        /// Выбор ветви для обработки
        /// </summary>
        public ObservableCollection<T> ModelCollection { get; set; } = new ObservableCollection<T>();
        /// <summary>
        /// Выбранная ветка
        /// </summary>
        public T SelectModel
        {
            get { return _model; }
            set
            {
                _model = value;
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
                    { Error = "Нет выбранного параметра!!!"; break; }
                }
            return Error;
        }
    }

   public class UniversalCollection
   {
        public string NameParameter { get; set; }
        public int? Parameter { get; set; }
    }
}
