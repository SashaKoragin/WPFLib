using System;
using System.Collections.Generic;
using AisPoco.Ifns51.ToAis;
using Prism.Commands;
using ViewModelLib.ModelTestAutoit.PublicModel.ButtonStartAutomat;
using ViewModelLib.ModelTestAutoit.PublicModel.ModelDatePickerAdd;
using ViewModelLib.ModelTestAutoit.PublicModel.PublicModelCollectionSelect;

namespace AutomatAis3Full.Form.Automat.Uregulirovanie.PrintDocument.DataContextPrintDocument
{
    public class DataContextPrintDocument
    {
        public StatusButtonMethod StartButton { get; }

        public DatePickerAdd DatePicker { get; }
        /// <summary>
        /// Модель подписантов
        /// </summary>
        public PublicModelCollectionSelect<TemplateModel> ModelTemplate { get; }
        public DelegateCommand<object> SelectModelTemplate { get; }
        public DelegateCommand<object> DeleteModelTemplate { get; }

        public DataContextPrintDocument()
        {
            var senderList = new List<TemplateModel>();
            DatePicker = new DatePickerAdd();
            senderList.Add(new TemplateModel() { IdTemplate = 1, NameTemplate = "1160001", DateCreate = DateTime.Now });
            senderList.Add(new TemplateModel() { IdTemplate = 2, NameTemplate = "1165001", DateCreate = DateTime.Now });
            ModelTemplate = new PublicModelCollectionSelect<TemplateModel>(senderList);
            StartButton = new StatusButtonMethod();
            var commandAuto = new LibraryCommandPublic.TestAutoit.Uregulirovanie.MessageLk.AutoMessageLk();
            StartButton.Button.Command = new DelegateCommand(() => { commandAuto.PrintDocumentModel(StartButton, ModelTemplate, DatePicker); });
            SelectModelTemplate = new DelegateCommand<object>(param => { ModelTemplate.SelectModelTemplate(param); });
            DeleteModelTemplate = new DelegateCommand<object>(param => { ModelTemplate.DeleteModelTemplate(param); });
        }

    }
}
