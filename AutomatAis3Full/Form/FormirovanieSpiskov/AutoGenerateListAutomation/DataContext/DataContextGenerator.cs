using AutomatAis3Full.Config;
using LibraryCommandPublic.TestAutoit.PublicCommand;
using Prism.Commands;
using ViewModelLib.ModelTestAutoit.AutoGenerateList.ModelGenerate;
using ViewModelLib.ModelTestAutoit.AutoGenerateList.ModelXlsxGenerate;
using ViewModelLib.ModelTestAutoit.ModelFormirovanie.ListViewModelXml;

namespace AutomatAis3Full.Form.FormirovanieSpiskov.AutoGenerateListAutomation.DataContext
{
   public class DataContextGenerator
    {

        public SchemesMethodNew Schemes { get; }

        public MethodModelXlsx ModelXlsx { get; }

        /// <summary>
        /// Удаление из модели
        /// </summary>
        public DelegateCommand RemoveXlsx { get; }
        /// <summary>
        /// Создание списка
        /// </summary>
        public DelegateCommand CreateListXml { get; }
        /// <summary>
        /// Файлы xml
        /// </summary>
        public ListViewModelXmlFileGenerateMethod XmlFile { get; }
        /// <summary>
        /// Команда переноса файла
        /// </summary>
        public DelegateCommand Transfer { get; }
        public DataContextGenerator()
        {
            var commandCreateListXml = new CommandAddListFull();
            Schemes = new SchemesMethodNew();
            ModelXlsx = new MethodModelXlsx();
            XmlFile = new ListViewModelXmlFileGenerateMethod(ConfigFile.FileSpisok);
            Transfer = new DelegateCommand(() => { XmlFile.MoveFile(ConfigFile.PathInn); });
            CreateListXml = new DelegateCommand(delegate { commandCreateListXml.CreateListModel(Schemes, ModelXlsx, XmlFile, ConfigFile.FileSpisok); });
            RemoveXlsx = new DelegateCommand(() => { ModelXlsx.DeleteXlsx(); });
        }

    }
}
