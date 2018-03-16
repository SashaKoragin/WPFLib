using System.Windows.Controls;
using System.Windows.Input;
using AddModelProject.TestAutoit.AddModel;
using Prism.Commands;
using TestAutoit.Form.FormSpisok.FormirovanieXml;
using TestAutoit.Form.FormSpisok.WpfForm.Spisok;
using ViewModelLib.ViewModelPage.ListViewModel.ListViewFile;
using ViewModelLib.ModelTestAutoit.ModelFormirovanie.TextBoxModel;
using ViewModelLib.ModelTestAutoit.ModelFormirovanie.CheckBoxModel;
using ViewModelLib.ModelTestAutoit.ModelFormirovanie.ListViewModel;
using ViewModelLib.ModelTestAutoit.ModelFormirovanie.ShemeXsd;
using ViewModelLib.ModelTestAutoit.ModelFormirovanie.StackPanelModel.ShemeSnuOneForm;
using LibaryCommandPublic.TestAutoit.SnuOneAuto.PublicCommand;

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
        public ICommand Transfer { get; }

        public DataContextDate()
        {
            var xmlfile = new ListViewModelXmlFileGenerate();
            var sheme = new AddModelTestAutoit();
            ShemeDocument = sheme.AddShemeUse(TestUserControl);
            Spisok = new ButtonFormirovanie();
            XmlFile = sheme.AddXmlFile(xmlfile, Constantsfile.ConstantFile.FileSpisok);
            TextBoxFileModel = new TextBoxModel();
            ModelSnuOne = new ModelSnuOneFormNameList();
            CheckBoxModel = new CheckBoxModel();
            CommandFormirovanie command = new CommandFormirovanie();
            Transfer =new DelegateCommand(() =>
            {
                command.Nransferes(XmlFile.File.Path, Constantsfile.ConstantFile.FileInn);
                sheme.UpdateXmlFile(XmlFile, Constantsfile.ConstantFile.FileSpisok);
            }); 
            SelectFile = new DelegateCommand(delegate { command.SelectFileSlsx(TextBoxFileModel, ModelSnuOne); });
            FormirovanieXml = new DelegateCommand((delegate
            {
                command.FormirovanieXml(ModelSnuOne, TextBoxFileModel, ShemeDocument, CheckBoxModel, Constantsfile.ConstantFile.FileSpisok, XmlFile);
            }));
        }
        }
    }
