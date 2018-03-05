using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Threading;
using Prism.Mvvm;

namespace Lotuslib.Formula.Otdel
{
   public class OtdelFormul : BindableBase, IDataErrorInfo
   {
        public ObservableCollection<OtdelFormul> Shemeformulotdel = new ObservableCollection<OtdelFormul>();
       public ObservableCollection<OtdelFormul> ShemeOtdelFormul
       {
           get { return Shemeformulotdel; }
       }

       public OtdelFormul Selectfformul;

        public OtdelFormul SelectfFormul
        {
            get { return Selectfformul; }
            set { Selectfformul = value; }
        }
        /// <summary>
        /// Индекс формулы
        /// </summary>
        private int index;

        /// <summary>
        /// Название формулы
        /// </summary>
        private string name;

        /// <summary>
        /// Описание формулы
        /// </summary>
        private string discription;
        /// <summary>
        /// Сама формула
        /// </summary>
        private string formula;

        public int Index
        {
            get { return index; }
            set { index = value; }
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string Discription
        {
            get { return discription; }
            set { discription = value; }
        }
        public string Formula
        {
            get { return formula; }
            set { formula = value; }
        }


        /// <summary>
        /// Попадание ошибки
        /// </summary>
        public string Error { get; set; }

        /// <summary>
        /// Проверка состояния объектов
        /// </summary>
        private bool _isValid { get; set; } = true;
        /// <summary>
        /// Метод проверки данных
        /// </summary>
        /// <returns>true and false</returns>
        public bool IsValidation()
        {
            _isValid = false;
            RaisePropertyChanged("SelectfFormul"); //Либо вызовет ошибку на интерфейсе либо уберет он нужен для интерфейса
            return _isValid;
        }

        /// <summary>
        /// Интерфейс по проверки ошибки
        /// </summary>
        /// <param name="columnName"></param>
        /// <returns></returns>
        public string this[string columnName]
        {
            get { return ValidateErrs(columnName); }
        }
        /// <summary>
        /// Собственно сама реализация проверки достоверности по IDataErrorInfo
        /// </summary>
        /// <param name="columnName">Проверяемая колонка</param>
        /// <returns></returns>
        private string ValidateErrs(string columnName)
        {
            Error = null;
            if (!_isValid)
                switch (columnName)
                {
                    case "SelectfFormul":
                        if (SelectfFormul != null)
                        { _isValid = true; break; }
                        { Error = "Не выбрана выборка для ЗГ!!!"; break; }
                }
            return Error;
        }

    }
}
