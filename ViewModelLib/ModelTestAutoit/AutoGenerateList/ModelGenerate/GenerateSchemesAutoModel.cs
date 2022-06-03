using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Documents;
using LibaryXMLAuto.XsdModelAutoGenerate;
using Prism.Mvvm;
using PublicLogicaFull.DocumentLogica.FlowDocumentExample.Examle;
using PublicLogicaFull.DocumentLogica.FlowDocumentExample.ExamleFlowDocument;


namespace ViewModelLib.ModelTestAutoit.AutoGenerateList.ModelGenerate
{
   public class GenerateSchemesAutoModel : BindableBase, IDataErrorInfo
    {
        private string _schemesName;

        private string _nameSchemes;

        private string[] _descriptionMemo;

        private FlowDocument _document;

        private GenerateSchemesAutoModel _schemes;

        private Type _typeObject;

        /// <summary>
        /// Схема заложенных списков
        /// </summary>
        private ObservableCollection<GenerateSchemesAutoModel> SchemesFullList = new ObservableCollection<GenerateSchemesAutoModel>();

        /// <summary>
        /// Коллекция образцов
        /// </summary>
        public ObservableCollection<GenerateSchemesAutoModel> SchemesFullDocument
        { get { return SchemesFullList; } }


        /// <summary>
        /// Сама схема
        /// </summary>
        public string SchemesName
        {
            get { return _schemesName; }
            set
            {

                _schemesName = value;
                RaisePropertyChanged();
            }
        }

        /// <summary>
        /// Имя схемы для UI пользователя
        /// </summary>
        public string NameSchemes
        {
            get { return _nameSchemes; }
            set
            {
                _nameSchemes = value;
                RaisePropertyChanged();
            }
        }

        /// <summary>
        /// Описание полей участвующие в преобразовании
        /// </summary>
        public string[] DescriptionMemo
        {
            get { return _descriptionMemo; }
            set
            {
                _descriptionMemo = value;
                RaisePropertyChanged();
            }
        }

        /// <summary>
        /// Документ образца по сле преобразования
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

        /// <summary>
        /// Выбор схемы
        /// </summary>
        public GenerateSchemesAutoModel Schemes
        {
            get
            {
                return _schemes;
            }
            set
            {
                _schemes = value;
                RaisePropertyChanged();
            }
        }

        public Type TypeObject
        {
            get
            {
                return _typeObject;
            }
            set
            {
                _typeObject = value;
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
        public bool IsValidationScheme()
        {
            IsValid = false;
            RaisePropertyChanged("Schemes");
            return IsValid;
        }

        /// <summary>
        /// Проверка выбрана ли схема
        /// </summary>
        /// <param name="columnName"></param>
        /// <returns></returns>
        private string ValidateErrs(string columnName)
        {
            Error = null;
            if (!IsValid)
                switch (columnName)
                {
                    case "Schemes":
                        if (Schemes != null)
                        { IsValid = true; break; }
                    { Error = "Не выбрана схема списка!!!"; break; }
                }
            return Error;
        }

    }

   public class SchemesMethodNew : GenerateSchemesAutoModel
   {
        /// <summary>
        /// Конструктор класса
        /// </summary>
        public SchemesMethodNew()
        {
            GenerateSchemes();
        }

        /// <summary>
        /// Генерация схем и списков для моделей
        /// </summary>
        public void GenerateSchemes()
        {
            SchemesFullDocument.Add(new GenerateSchemesAutoModel() {Document = AddDocument.DocumentSnuOneForm(ExampleXaml.TaxArrears), SchemesName = "Схема списка для запуска БП: Взыскание задолженности", NameSchemes = "TaxArrears", DescriptionMemo = new []{"ИНН","КПП"}, TypeObject = typeof(TaxArrears)});
            SchemesFullDocument.Add(new GenerateSchemesAutoModel() {Document = AddDocument.DocumentSnuOneForm(ExampleXaml.RegAddressXml), SchemesName = "Схема списка для запуска БП: Изменения индекса", NameSchemes = "AddressModel", DescriptionMemo = new[] { "ФИД", "ИНН", "АДРЕС", "ИНДЕКС СТАРЫЙ", "ИНДЕКС НОВЫЙ" }, TypeObject = typeof(AddressModel) });
            SchemesFullDocument.Add(new GenerateSchemesAutoModel() { Document = AddDocument.DocumentSnuOneForm(ExampleXaml.JudicialAct), SchemesName = "Схема списка для запуска БП: Судебные акты", NameSchemes = "JudicialAct", DescriptionMemo = new[] {"ИНН", "Номер заявления"}, TypeObject = typeof(JudicialAct) });
        }
   }
}
