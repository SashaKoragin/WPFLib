using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModelLib.ModelTestAutoit.StackPanelModel.ShemeSnuOneForm;

namespace AddModelProject.TestAutoit.Logica.Parsexlsx
{
   public class ParseXlsx
    {
        public void ParseXls(string fullpath, ref ModelSnuOneFormNameList modelSnuOne)
        {
            modelSnuOne.ShemeColumn.Clear();
            modelSnuOne.ShemeFull.Clear();
            var worbook = new ClosedXML.Excel.XLWorkbook(fullpath);
            foreach (var workSneets in worbook.Worksheets)
            {
                foreach (var column in workSneets.ColumnsUsed(column => !column.IsEmpty()))
                {
                    modelSnuOne.ShemeColumn.Add(new ModelSnuOneFormNameList.NameColumn() {ColumnName = column.ColumnLetter()});
                }
             modelSnuOne.ShemeFull.Add(new ModelSnuOneFormNameList() {Listletter = workSneets.Name, ShemeColumn = modelSnuOne.ShemeColumn});
            }
        }

    }
}
