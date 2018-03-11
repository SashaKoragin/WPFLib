using System.Collections.ObjectModel;
using ViewModelLib.ModelTestAutoit.StackPanelModel.ShemeSnuOneForm;

namespace AddModelProject.TestAutoit.Logica.Parsexlsx
{
   /// <summary>
   /// Парсим XLSX
   /// </summary>
   public class ParseXlsx
    {
        /// <summary>
        /// Метод вытаскивает Листы и столбцы для дальнейшего использования
        /// </summary>
        /// <param name="fullpath">Полный путь к файлу</param>
        /// <param name="modelSnuOne">Модель данных</param>
        public void ParseXls(string fullpath, ref ModelSnuOneFormNameList modelSnuOne)
        {
            modelSnuOne.ShemeFull.Clear();
            var worbook = new ClosedXML.Excel.XLWorkbook(fullpath);
            foreach (var workSneets in worbook.Worksheets)
            {
                var model = new ModelSnuOneFormNameList.NameColumn();
                foreach (var column in workSneets.ColumnsUsed(column => !column.IsEmpty()))
                {
                    model.ShemeLetter.Add(new ModelSnuOneFormNameList.NameColumn() { ColumnName = column.ColumnLetter() });
                }
             modelSnuOne.ShemeFull.Add(new ModelSnuOneFormNameList() {Listletter = workSneets.Name, Columns = model.ShemeLetter });
            }
        }

    }
}
