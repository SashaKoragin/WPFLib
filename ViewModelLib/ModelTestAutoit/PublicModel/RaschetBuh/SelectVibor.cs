using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        public SelectVibor()
        {
            SelectQbe.Add(new Select() {Num = 1, ColorNum = Brushes.Aquamarine, Text = "Имущественные налоги", Discription = "Обработка:\nИмущественные налоги по КБК:\n18210601010031000110/18210601010032100110\n18210604012021000110/18210604012022100110\n18210606041031000110/18210606041032100110" });
            SelectQbe.Add(new Select() { Num = 2, ColorNum = Brushes.Aqua, Text = "Иностранцы", Discription = "Обработка:\nИностранцы по КБК:\n18210102040011000110" });
            SelectQbe.Add(new Select() { Num = 3, ColorNum = Brushes.SkyBlue, Text = "Страховые взносы и УСН", Discription = "Обработка:\nСтраховые взносы по КБК:" +
                                                                                                                       "\n18210202010061010160/18210202010062110160" +
                                                                                                                       "\n18210202090071010160/18210202090072110160" +
                                                                                                                       "\n18210202101081013160/18210202101082013160" +
                                                                                                                       "\nОбработка:\nУСН:"+
                                                                                                                       "\n18210501021011000110/18210501021012100110"+
                                                                                                                       "\n18210501011011000110/18210501011012100110"+
                                                                                                                       "\n18210101011011000110/18210101011012100110"});
            SelectQbe.Add(new Select() {  Num = 4, ColorNum = Brushes.CadetBlue, Text = "НДФЛ",Discription = "Обработка:\nНДФЛ по КБК:" +
                                                                                                           "\n18210102010011000110/18210102010012100110"});
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
