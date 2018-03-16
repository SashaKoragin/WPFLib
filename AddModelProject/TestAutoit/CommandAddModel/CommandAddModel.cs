using System.IO;
using AddModelProject.TestAutoit.AddModel;
using ViewModelLib.ModelTestAutoit.ModelFormirovanie.StackPanelModel.ShemeSnuOneForm;
using ViewModelLib.ModelTestAutoit.ModelFormirovanie.TextBoxModel;
using ViewModelLib.ModelTestAutoit.PublicModel.ReportXml;

namespace AddModelProject.TestAutoit.CommandAddModel
{
    /// <summary>
    /// Класс для команд кнопок работы с моделями данных Папка соответствует проекту
    /// </summary>
   public class CommandAddModel
    {
        /// <summary>
        /// Подгрузить файл xlsx
        /// </summary>
        /// <param name="files">массив данных файлов</param>
        /// <param name="textBoxModel">Наша модель TextBoxModel</param>
        /// <param name="modelSnuOne">Наша модель ModelSnuOneFormNameList</param>
        public static void AddTextBoxFile(FileInfo[] files,ref TextBoxModel textBoxModel,ref ModelSnuOneFormNameList modelSnuOne)
        {
            foreach (var file in files)
            {
                textBoxModel.Icon = PublicAdd.IconsFile.Extracticonfile(file.FullName);
                textBoxModel.Name = file.Name;
                textBoxModel.Path = file.FullName;
                new Logica.Parsexlsx.ParseXlsx().ParseXls(file.FullName,ref modelSnuOne);
            }
        }

        public void JurnalOnInn(ReportJurnal jurnal, string pathjurnal,string pathfile)
        {
            AddModelTestAutoit model = new AddModelTestAutoit();
            jurnal.XmlReportJurnal.Clear();
            jurnal.XmlFile.Clear();
            model.AddJurnals(jurnal, pathjurnal, pathfile);
        }

    }
}
