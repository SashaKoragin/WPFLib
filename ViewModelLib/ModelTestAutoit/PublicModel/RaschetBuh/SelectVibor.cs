using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Media;
using Prism.Mvvm;

namespace ViewModelLib.ModelTestAutoit.PublicModel.RaschetBuh
{
   public class SelectVibor : BindableBase,IDataErrorInfo
    {
        private Select _sel;
        public Select Sel
        {
            get { return _sel; }
            set
            {
                _sel = value;
                RaisePropertyChanged();
            }
        }
        public ObservableCollection<Select> SelectQbe { get; set; } = new ObservableCollection<Select>();

        public void SelectMigrationVibor()
        {
            SelectQbe.Add(new Select() { Num = 1, ColorNum = Brushes.Aquamarine, Text = "Выборка НО принимающий данные", Discription = "" });
            SelectQbe.Add(new Select() { Num = 2, ColorNum = Brushes.Aquamarine, Text = "Выборка НО передающий данные", Discription = "" });
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
            RaisePropertyChanged("Sel");
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
                    case "Sel":
                        if (Sel != null)
                        { break; }
                        { Error = "Не выбранна  обработка!!!"; break; }
                }
            return Error;
        }

    }


    public class Select
    {
        public int Num { get; set; }

        public Brush ColorNum { get; set; }

        public string Text { get; set; }

        public string Discription { get; set; }
    }
}
