using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Controls;
using System.Windows.Documents;
using Prism.Mvvm;
using PublicLogicaFull.DocumentLogica.FlowDocumentExample.ExamleFlowDocument;
using PublicLogicaFull.DocumentLogica.FlowDocumentExample.Examle;

namespace ViewModelLib.ModelTestAutoit.ModelFormirovanie.ShemeXsd
{
    /// <summary>
    /// Класс модели образцов
    /// </summary>
   public class ShemeProperty : BindableBase, IDataErrorInfo
    {
        /// <summary>
        /// Схема листов с колонками
        /// </summary>
        public ObservableCollection<ShemeProperty> Shemefulllist = new ObservableCollection<ShemeProperty>();
        /// <summary>
        /// Колекция образцов
        /// </summary>
        public ObservableCollection<ShemeProperty> ShemeFullDocument
        { get { return Shemefulllist; } }

        private UserControl _control;
        private string _shemes;
        private string _nameshemes;
        private FlowDocument _document;
        private ShemeProperty _shema;

        public ShemeProperty Shema
        {
            get
            {
                return _shema;
            }
            set
            {
                _shema = value;
                RaisePropertyChanged();
            }
        }

        public UserControl UserContr
        {
            get { return _control; }
            set
            {
                _control = value;
                RaisePropertyChanged();
            }
        }
        /// <summary>
        /// Сама схема
        /// </summary>
        public string Shemes
        {
            get { return _shemes; }
            set
            {
                
                _shemes = value;
                RaisePropertyChanged();
            }
        }
        /// <summary>
        /// Имя схемы для UI пользователя
        /// </summary>
        public string Nameshemes
        {
            get { return _nameshemes; }
            set
            {
                _nameshemes = value;
                RaisePropertyChanged();
            }
        }

        /// <summary>
        /// Документ образца
        /// </summary>
        public FlowDocument Document
        {
            get { return _document; }
            set
            {
                _document = value;
                RaisePropertyChanged();
            }
        }

        public string Error { get; set; }
        private bool IsValid { get; set; } = true;
        public string this[string columnName]
        {
            get { return ValidateErrs(columnName); }
        }
        /// <summary>
        /// Проверка Validation
        /// </summary>
        /// <returns></returns>
        public bool IsValidation()
        {
            IsValid = false;
            RaisePropertyChanged("Shema");
            return IsValid;
        }
        /// <summary>
        /// Проверка Выбраннв ли схема
        /// </summary>
        /// <param name="columnName"></param>
        /// <returns></returns>
        private string ValidateErrs(string columnName)
        {
            Error = null;
            if (!IsValid)
                switch (columnName)
                {
                    case "Shema":
                        if (Shema != null)
                        { IsValid = true; break; }
                        { Error = "Не выбрана схема списка!!!"; break; }
                }
            return Error;
        }
    }
    /// <summary>
    /// Методы данной схемы
    /// </summary>
    public class ShemeMethod : ShemeProperty
    {
        /// <summary>
        /// Конструктор класса 
        /// </summary>
        /// <param name="usercontrolmass">Массив UserControl для добавления</param>
        public ShemeMethod(UserControl[] usercontrolmass)
        {
            AddShemeUse(usercontrolmass);
        }
        /// <summary>
        /// Модель схемы данных для генерации списков xml
        /// </summary>
        /// <param name="usercontrolmass">Массив UserControl для добавления</param>
        public void AddShemeUse(UserControl[] usercontrolmass)
        {
            Shemefulllist.Add(new ShemeProperty() { Document = AddDocument.DocumentSnuOneForm(ExampleXaml.SnuOneForm), Nameshemes = "Формирование СНУ", Shemes = "SnuOneForm", UserContr = usercontrolmass[0] });
            Shemefulllist.Add(new ShemeProperty() {Document = AddDocument.DocumentSnuOneForm(ExampleXaml.TreatmentFpd), Nameshemes = "Обработка ФПД", Shemes = "TreatmentFpd", UserContr = usercontrolmass[1]});
            Shemefulllist.Add(new ShemeProperty() { Document = AddDocument.DocumentSnuOneForm(ExampleXaml.CollectionInn), Nameshemes = "Формирование СНУ Массово", Shemes = "FullInnCount", UserContr = usercontrolmass[2] });
            Shemefulllist.Add(new ShemeProperty() { Document = AddDocument.DocumentSnuOneForm(ExampleXaml.ZemlyOrImyShestvoFid), Nameshemes = "ФИД факта владения земля имущество", Shemes = "FidZorI",UserContr = usercontrolmass[0]});
        }
    }
}
