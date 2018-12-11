using System.Windows.Controls;
using System.Windows.Input;
using AutomatAis3Full.Config;
using AutomatAis3Full.Form.FormirovanieSpiskov.Spiski.FormFormirovanie.PublicElement.SelectFile;
using AutomatAis3Full.Form.FormirovanieSpiskov.Spiski.FormFormirovanie.PublicElement.SelectList;
using AutomatAis3Full.Form.FormirovanieSpiskov.Spiski.FormirovanieXml.CountCollection;
using AutomatAis3Full.Form.FormirovanieSpiskov.Spiski.FormirovanieXml.DeleteTitle;
using AutomatAis3Full.Form.FormirovanieSpiskov.Spiski.FormirovanieXml.RowSelect;
using LibaryCommandPublic.TestAutoit.PublicCommand;
using Prism.Commands;
using ViewModelLib.ModelTestAutoit.ModelFormirovanie.CheckBoxModel;
using ViewModelLib.ModelTestAutoit.ModelFormirovanie.ListViewModelXml;
using ViewModelLib.ModelTestAutoit.ModelFormirovanie.ShemeXsd;
using ViewModelLib.ModelTestAutoit.ModelFormirovanie.StackPanelModel.ShemeSnuOneForm;
using ViewModelLib.ModelTestAutoit.ModelFormirovanie.TextBoxModel;

namespace AutomatAis3Full.Form.FormirovanieSpiskov.Spiski.DataContext
{
   public class DataContextSpisok
   {
       public UserControl[] TestUserControl =
       {
           new DeleteTitle(), new RowSelect(), new ColElement()
       };

        public TextBoxModelMethod TextBoxFileModel { get; }
        public CheckBoxModel CheckBoxModel { get; }
        public ModelSnuOneFormNameListMethod ModelSnuOne { get; }
        public DelegateCommand SelectFile { get; }
        public DelegateCommand FormirovanieXml { get; }
        public ShemeMethod ShemeDocument { get; }
        public ListViewModelXmlFileGenerateMethod XmlFile { get; }
        public ICommand Transfer { get; }
        public UserControl SelectFileControl { get; }
        public UserControl SelectListControl { get; }
        public DataContextSpisok()
        {
            SelectFileControl = new SelectFile();
            SelectListControl = new SelectList();
            ShemeDocument = new ShemeMethod(TestUserControl);
            XmlFile = new ListViewModelXmlFileGenerateMethod(ConfigFile.FileSpisok);
            TextBoxFileModel = new TextBoxModelMethod();
            ModelSnuOne = new ModelSnuOneFormNameListMethod();
            CheckBoxModel = new CheckBoxModel();
            CommandFormirovanie command = new CommandFormirovanie();
            Transfer = new DelegateCommand(() => { XmlFile.MoveFile(ConfigFile.PathInn); });
            SelectFile = new DelegateCommand(delegate { command.SelectFileSlsx(TextBoxFileModel, ModelSnuOne); });
            FormirovanieXml = new DelegateCommand((delegate
            {
                command.FormirovanieXml(ModelSnuOne, TextBoxFileModel, ShemeDocument, CheckBoxModel, ConfigFile.FileSpisok, XmlFile);
            }));
        }
    }
}
