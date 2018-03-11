using System.Windows.Controls;
using AddModelProject.TestAutoit.AddModel;
using LibaryCommandPublic.TestAutoit;
using Prism.Commands;
using TestAutoit.Form.FormSpisok.FormirovanieXml;
using TestAutoit.Form.FormSpisok.WpfForm.Spisok;
using ViewModelLib.ViewModelPage.ListViewModel.ListViewFile;
using ViewModelLib.ModelTestAutoit.TextBoxModel;
using ViewModelLib.ModelTestAutoit.CheckBoxModel;
using ViewModelLib.ModelTestAutoit.ListViewModel;
using ViewModelLib.ModelTestAutoit.ShemeXsd;
using ViewModelLib.ModelTestAutoit.StackPanelModel.ShemeSnuOneForm;

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

        public TextBoxModel TextBoxFileModel { get; }
        public ListViewModel ListViewFileModel { get; }
        public CheckBoxModel CheckBoxModel { get; }
        public ModelSnuOneFormNameList ModelSnuOne { get; }
        public DelegateCommand SelectFile { get; }
        public DelegateCommand FormirovanieXml { get; }

        public UserControl Spisok { get; }
        public Sheme ShemeDocument { get; }

        public ListViewModelXmlFileGenerate XmlFile { get; }

        public DataContextDate()
        {
            var sheme = new AddModelTestAutoit();
            
            ShemeDocument = sheme.AddShemeUse(TestUserControl);
            Spisok = new ButtonFormirovanie();
           // XmlFile = new ListViewModelXmlFileGenerate();
            TextBoxFileModel = new TextBoxModel();
            ModelSnuOne = new ModelSnuOneFormNameList();
            CheckBoxModel = new CheckBoxModel();
            CommandTestAutoit command = new CommandTestAutoit();
            SelectFile = new DelegateCommand(delegate { command.SelectFileSlsx(TextBoxFileModel, ModelSnuOne); });
            FormirovanieXml = new DelegateCommand(delegate { command.FormirovanieXml(ModelSnuOne, TextBoxFileModel, ShemeDocument, CheckBoxModel); });
        }
    }

    //internal class DataPageSheme
    //{
    //    public TextBoxModel TextBoxFileModel { get; }
    //    public ListViewModel ListViewFileModel { get; }
    //    public CheckBoxModel CheckBoxModel { get; }
    //    public ModelSnuOneFormNameList ModelSnuOne { get; }
    //    public DelegateCommand SelectFile { get; }
    //    public DelegateCommand FormirovanieXml { get; }
    //    public DataPageSheme()
    //    {
    //        TextBoxFileModel = new TextBoxModel();
    //        ModelSnuOne = new ModelSnuOneFormNameList();
    //        CheckBoxModel = new CheckBoxModel();
    //        CommandTestAutoit command = new CommandTestAutoit();
    //        SelectFile = new DelegateCommand(delegate { command.SelectFileSlsx(TextBoxFileModel, ModelSnuOne); });
    //        FormirovanieXml = new DelegateCommand(delegate { command.FormirovanieXml(ModelSnuOne, TextBoxFileModel); });
    //    }
    //}
}
