using System;
using System.Threading.Tasks;
using System.Windows;
using ClosedXML.Excel;
using Lotuslib.LotusModel;
using ViewModelLib.ViewModelPage.LoadingString;

namespace Lotuslib.Seath.SeathZg
{
   public class SeathZg
    {
        /// <summary>
        /// Очень сложный метод т.к ObservableCollection нельзя обновить из другого потока потомучто он привязан к UI потоку.
        /// Поэтому пришлось создавать метод UpdateOn() который отвяжет его от потока UI
        /// После этого мы можем манипулировать ObservableCollection
        /// Такая функция появилась только в Net 4.5
        /// </summary>
        /// <param name="databasepath">Путь кбазе в Lotus</param>
        /// <param name="shemezg">Наша модель отражения элементов для манипуляции </param>
        /// <param name="formula">Заранее сгенерированая формула поиска ЗГ</param>
        public async void SeathZgOtdel(string databasepath, ModelZg shemezg, string formula, Loading Load)
        {
            try
            {

                shemezg.ShemeDbZg.Clear();
                shemezg.UpdateOn();
               await Task.Run(() =>
                {
                    var db = ConectDb.ConectDb.Databaseconect(ConectionString.ConectionString.Pass, ConectionString.ConectionString.ServerLocal, databasepath, false);
                    Load.Text = "Приступили к поиску ждите";
                    var col = db.Search(formula, null, 0);
                    var count = col.Count;
                    var docum = col.GetFirstDocument();
                    var i = 1;
                    var workbook1 = new XLWorkbook();
                    var worksheet1 = workbook1.Worksheets.Add("Отчет Lotus");
                    while (docum != null)
                    {
                           Load.Text = "Обработано " + i + " из " + count;
                           var NamePerson = docum.GetItemValue(LotusItem.DbZgItem.NamePerson)[0].ToString();
                           var NumZg = docum.GetItemValue(LotusItem.DbZgItem.NumZg)[0].ToString();
                           var StatusZg = docum.GetItemValue(LotusItem.DbZgItem.StatusZg)[0].ToString();
                           var DataregZg = docum.GetItemValue(LotusItem.DbZgItem.DataregZg)[0].ToString();
                           var InCardRespOutNum = docum.GetItemValue(LotusItem.DbZgItem.InCardRespOutNum)[0].ToString();
                           var IoInn = docum.GetItemValue(LotusItem.DbZgItem.IoInn)[0].ToString();
                           var DepartamentZg = docum.GetItemValue(LotusItem.DbZgItem.DepartamentZg)[0].ToString();
                           var Incardrespoutnum = docum.GetItemValue(LotusItem.DbZgItem.InCardRespOutNum)[0].ToString();
                           var Incardrespdi = docum.GetItemValue(LotusItem.DbZgItem.InCardRespDi)[0].ToString();
                           var Extofiledate = docum.GetItemValue(LotusItem.DbZgItem.ExToFileDate)[0].ToString();

                           worksheet1.Cell($"A{i}").Value = NamePerson;
                           worksheet1.Cell($"B{i}").Value = NumZg;
                           worksheet1.Cell($"C{i}").Value = StatusZg;
                           worksheet1.Cell($"D{i}").Value = DataregZg;
                           worksheet1.Cell($"E{i}").Value = InCardRespOutNum;
                           worksheet1.Cell($"F{i}").Value = IoInn;
                           lock (shemezg._lock)
                           {
                               shemezg.ShemeDbZg.Add(new ModelZg()
                               {
                                   Incardrespoutnum = Incardrespoutnum,
                                   DepartamentZg = DepartamentZg,
                                   StatusZg = StatusZg,
                                   DataregZg = DataregZg,
                                   NumZg = NumZg,
                                   Namefio = NamePerson,
                                   Incardrespdi = Incardrespdi,
                                   Extofiledate = Extofiledate

                               });
                           }
                           i++;
                           docum = col.GetNextDocument(docum);
                    }
                    workbook1.SaveAs("D:\\Отчет.xlsx");
                    shemezg.UpdateOff();
                    
                });

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
    }
}
