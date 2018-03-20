using System.Windows.Controls;
using System.Windows.Input;
using Prism.Commands;
using TestAutoit.Form.FormSpisok.FormirovanieXml;
using ViewModelLib.ModelTestAutoit.ModelFormirovanie.TextBoxModel;
using ViewModelLib.ModelTestAutoit.ModelFormirovanie.CheckBoxModel;
using ViewModelLib.ModelTestAutoit.ModelFormirovanie.ShemeXsd;
using ViewModelLib.ModelTestAutoit.ModelFormirovanie.StackPanelModel.ShemeSnuOneForm;
using LibaryCommandPublic.TestAutoit.SnuOneAuto.PublicCommand;
using TestAutoit.Config;
using ViewModelLib.ModelTestAutoit.ModelFormirovanie.ListViewModelXml;

namespace TestAutoit.Form.FormSpisok.Datacontext
{
    /// <summary>
    /// Дата контекст с формой для формирования списков
    /// </summary>
   internal class DataContextDate
    {
        public UserControl[] TestUserControl =
        {
            new SnuOneForm(), new TestExample(), 
        };

        public TextBoxModelMethod TextBoxFileModel { get; }
        public CheckBoxModel CheckBoxModel { get; }
        public ModelSnuOneFormNameListMethod ModelSnuOne { get; }
        public DelegateCommand SelectFile { get; }
        public DelegateCommand FormirovanieXml { get; }
        public ShemeMethod ShemeDocument { get; }
        public ListViewModelXmlFileGenerateMethod XmlFile { get; }
        public ICommand Transfer { get; }

        public DataContextDate()
        {
            ShemeDocument = new ShemeMethod(TestUserControl);
            XmlFile = new ListViewModelXmlFileGenerateMethod(ConfigFile.FileSpisok);
            TextBoxFileModel = new TextBoxModelMethod();
            ModelSnuOne = new ModelSnuOneFormNameListMethod();
            CheckBoxModel = new CheckBoxModel();
            CommandFormirovanie command = new CommandFormirovanie();
            Transfer =new DelegateCommand(() =>{XmlFile.MoveFile(ConfigFile.FileInn);}); 
            SelectFile = new DelegateCommand(delegate { command.SelectFileSlsx(TextBoxFileModel, ModelSnuOne); });
            FormirovanieXml = new DelegateCommand((delegate
            {
                command.FormirovanieXml(ModelSnuOne, TextBoxFileModel, ShemeDocument, CheckBoxModel, ConfigFile.FileSpisok, XmlFile);
            }));
        }
        }
    }
