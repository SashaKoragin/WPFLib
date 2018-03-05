using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Documents;
using Lotuslib.Annotations;
using Prism.Mvvm;

namespace Lotuslib.LotusModel
{
    /// <summary>
    /// ModelImnsOtdel Весь класс составляет колекцию отделов и пользователей Наледуем от BindableBase
    /// IDataErrorInfo Фиксация ошибок на интерфейсе.
    /// </summary>
    public class ModelImnsOtdel : BindableBase, IDataErrorInfo
    {
        /// <summary>
        /// Создание новой колекции для отделов (Экземпляра класса)
        /// </summary>
        public ObservableCollection<ModelImnsOtdel> _shemeotdel = new ObservableCollection<ModelImnsOtdel>();

        /// <summary>
        /// Создание новой колекции для пользователей (Экземпляра класса)
        /// </summary>
        public ObservableCollection<ModelImnsUsers> _shemeousers = new ObservableCollection<ModelImnsUsers>();

        /// <summary>
        /// Присваеваем экземпляр класса отдела для нашей ViewModel
        /// </summary>
        public ObservableCollection<ModelImnsOtdel> ShemeOtdel
        {
            get { return _shemeotdel; }
        }

        /// <summary>
        /// Присваеваем экземпляр класса пользователей для нашей ViewModel
        /// </summary>
        public ObservableCollection<ModelImnsUsers> ShemeUsers
        {
            get { return _shemeousers; }
        }

        /// <summary>
        /// Параметр отдела string
        /// </summary>
        public string Otdeldepartament;

        /// <summary>
        /// Параметр выбора из нашей общей колеции для манипуляции bservableCollection&lt;ModelImnsOtdel&gt;
        /// </summary>
        public ModelImnsOtdel Selectotdel;


        /// <summary>
        /// Присваиваем выбор и передаем колекции элементов для манипуляци
        /// </summary>
        public ModelImnsOtdel SelectOtdel
        {
            get { return Selectotdel; }
            set { Selectotdel = value; }
        }
        /// <summary>
        /// Присваиваем параметр отдела string
        /// </summary>
        public string OtdelDepartament
        {
            get { return Otdeldepartament; }
            set { Otdeldepartament = value; }
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
            RaisePropertyChanged("SelectOtdel");
            return  _isValid;
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
                case "SelectOtdel":
                    if (SelectOtdel != null)
                    { _isValid = true; break;}
                    { Error= "Плохо не выбран отдел"; break;}
                    
            }
             return Error;
        }
        /// <summary>
        /// ModelImnsUsers Данный класс является подклассом отдела и символизирует пользователей
        /// </summary>
        public class ModelImnsUsers
        {
            /////// <summary>
            /////// Создание новой колекции для пользователей (Экземпляра класса)
            /////// </summary>
            ////public ObservableCollection<ModelImnsUsers> _shemeousers = new ObservableCollection<ModelImnsUsers>();
            /////// <summary>
            /////// Присваеваем экземпляр класса пользователей для нашей ViewModel
            /////// </summary>
            ////public ObservableCollection<ModelImnsUsers> ShemeUsers
            ////{
            ////    get { return _shemeousers; }
            ////}

            /// <summary>
            /// Параметр пользователя string
            /// </summary>
            public string Username;

            /// <summary>
            /// Присваиваем параметр пользователя string
            /// </summary>
            public string UserName
            {
                get { return Username; }
                set { Username = value; }
            }
        }
    }
}
