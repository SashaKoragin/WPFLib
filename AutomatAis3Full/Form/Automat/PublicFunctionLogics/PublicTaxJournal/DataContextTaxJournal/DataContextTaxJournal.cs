using System;
using System.Collections.Generic;
using AisPoco.Ifns51.ToAis;
using AutomatAis3Full.Config;
using Prism.Commands;
using ViewModelLib.ModelTestAutoit.PublicModel.ButtonStartAutomat;
using ViewModelLib.ModelTestAutoit.PublicModel.ModelDatePickerAdd;
using ViewModelLib.ModelTestAutoit.PublicModel.PublicModelCollectionSelect;

namespace AutomatAis3Full.Form.Automat.PublicFunctionLogics.PublicTaxJournal.DataContextTaxJournal
{
    public class DataContextTaxJournal
    {
        public DatePickerAdd DatePicker { get; }

        public StatusButtonMethod StartButton { get; }
        /// <summary>
        /// Модель шалонов номеров подстановки
        /// </summary>
        public PublicModelCollectionSelect<TemplateModel> ModelTemplate { get; }
        public DelegateCommand<object> SelectModelTemplate { get; }
        public DelegateCommand<object> DeleteModelTemplate { get; }

        public DataContextTaxJournal()
        {
            var senderList = new List<TemplateModel>();
            senderList.Add(new TemplateModel() { IdTemplate = 1, NameTemplate = "Отсутствует", DateCreate = DateTime.Now });
            senderList.Add(new TemplateModel() { IdTemplate = 2, NameTemplate = "ОКП2-{numberDocument}/12-18", DateCreate = DateTime.Now });
            senderList.Add(new TemplateModel() { IdTemplate = 3, NameTemplate = "КВВ-{numberDocument}/15-13", DateCreate = DateTime.Now });
         
            ModelTemplate = new PublicModelCollectionSelect<TemplateModel>(senderList);
            DatePicker = new DatePickerAdd();
            var command = new LibraryCommandPublic.TestAutoit.PublicCommand.CommandTaxJournal129();
            StartButton = new StatusButtonMethod();
            StartButton.Button.Command = new DelegateCommand(() => { command.StartTaxJournal(StartButton, ConfigFile.PathTemp, DatePicker, ModelTemplate); });
            SelectModelTemplate = new DelegateCommand<object>(param => { ModelTemplate.SelectModelTemplate(param); });
            DeleteModelTemplate = new DelegateCommand<object>(param => { ModelTemplate.DeleteModelTemplate(param); });
        }
    }
}
