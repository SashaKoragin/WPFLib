using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using AddModelProject.TestAutoit.AddModel;
using LibaryCommandPublic.TestAutoit;
using Prism.Commands;
using ViewModelLib.ViewModelPage.ListViewModel.ListViewFile;
using ViewModelLib.ModelTestAutoit.TextBoxModel;
using ViewModelLib.ModelTestAutoit.CheckBoxModel;
using ViewModelLib.ModelTestAutoit.StackPanelModel.ShemeSnuOneForm;

namespace TestAutoit.Form.FormSpisok.Datacontext
{
    /// <summary>
    /// Дата контекст с формой для формирования списков
    /// </summary>
   internal class DataContextDate
    {
        public TextBoxModel TextBoxFileModel { get; }
        public ListViewModel ListViewFileModel { get; }
        public CheckBoxModel CheckBoxModel { get; }
        public ModelSnuOneFormNameList ModelSnuOne { get; }
        public DelegateCommand SelectFile { get; }
        public DelegateCommand FormirovanieXml { get; }
        public DataContextDate()
        {

            TextBoxFileModel = new TextBoxModel();
            ModelSnuOne = new ModelSnuOneFormNameList();
            CheckBoxModel = new CheckBoxModel();
            CommandTestAutoit command = new CommandTestAutoit();
            SelectFile = new DelegateCommand(delegate {command.SelectFileSlsx(TextBoxFileModel, ModelSnuOne); });
            FormirovanieXml = new DelegateCommand(delegate {command.FormirovanieXml(ModelSnuOne, TextBoxFileModel);});
        }
    }
}
