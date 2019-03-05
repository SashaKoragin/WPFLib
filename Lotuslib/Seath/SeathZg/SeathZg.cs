using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Threading;
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
        public void SeathZgOtdel(string databasepath, ModelZg shemezg, string formula, Loading Load)
        {
            try
            {

                shemezg.ShemeDbZg.Clear();
                shemezg.UpdateOn();
                Task.Run(() =>
                {
                    //var db = ConectDb.ConectDb.Databaseconect(ConectionString.ConectionString.Pass,
                    //ConectionString.ConectionString.ServerLocal, databasepath, false);
                    var db = ConectDb.ConectDb.Databaseconect(ConectionString.ConectionString.Pass,
ConectionString.ConectionString.ServerLocal, "IFNS\\Комутатор_архивов\\Arhiv2018\\2017\\ZG_Arhiv_2017.nsf", false);
                    
                   // var col = db.Search(formula, null, 0);
                    var col = db.Search("Select @All", null, 0);
                    var count = col.Count;
                    var docum = col.GetFirstDocument();
                    var i = 1;
                    var workbook1 = new XLWorkbook();
                    var worksheet1 = workbook1.Worksheets.Add("Отчет Lotus");
                    while (docum != null)
                    {
                        Load.Text = "Обработано " + i + " из " + count;
                    //var docum1 = docum;
                        //Task.Run(async () =>
                        //{
                        //    await Task.Run(() =>
                        //    {
                                var a = docum.GetItemValue(LotusItem.DbZgItem.NamePerson)[0].ToString();
                                var a1 = docum.GetItemValue(LotusItem.DbZgItem.NumZg)[0].ToString();
                                var a2 = docum.GetItemValue(LotusItem.DbZgItem.StatusZg)[0].ToString();
                                var a3 = docum.GetItemValue(LotusItem.DbZgItem.DataregZg)[0].ToString();
                                var a4 = docum.GetItemValue(LotusItem.DbZgItem.InCardRespOutNum)[0].ToString();
                                var a5 = docum.GetItemValue(LotusItem.DbZgItem.IoInn)[0].ToString();
                                worksheet1.Cell($"A{i}").Value = a;
                                worksheet1.Cell($"B{i}").Value = a1;
                                worksheet1.Cell($"C{i}").Value = a2;
                                worksheet1.Cell($"D{i}").Value = a3;
                                worksheet1.Cell($"E{i}").Value = a4;
                                worksheet1.Cell($"F{i}").Value = a5;
                        i++;
                                //lock (shemezg._lock)
                                //shemezg.ShemeDbZg.Add(new ModelZg
                                //{
                                //    StatusZg = docum1.GetItemValue(LotusItem.DbZgItem.StatusZg)[0],
                                //    Num = docum1.GetItemValue(LotusItem.DbZgItem.NumZg)[0],
                                //    Datareg = docum1.GetItemValue(LotusItem.DbZgItem.DataregZg)[0],
                                //    DepartamentZg = docum1.GetItemValue(LotusItem.DbZgItem.DepartamentZg)[0],
                                //    Incardrespoutnum = docum1.GetItemValue(LotusItem.DbZgItem.InCardRespOutNum)[0],
                                //    Incardrespdi =Convert.ToString(docum1.GetItemValue(LotusItem.DbZgItem.InCardRespDi)[0]),
                                //    Extofiledate =Convert.ToString(docum1.GetItemValue(LotusItem.DbZgItem.ExToFileDate)[0]),
                                //    NameFio = docum1.GetItemValue(LotusItem.DbZgItem.NamePerson)[0]
                                //});
                        //    });
                        //});
                        docum = col.GetNextDocument(docum);
                    }
                    workbook1.SaveAs("C:\\Отчет.xlsx");
                    // ExportToExcel(shemezg);
                    shemezg.UpdateOff();
                    
                });

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        /// <summary>
        /// Тестовая функция выгрузки в Excel
        /// </summary>
        /// <param name="model"></param>
        public void ExportToExcel(ModelZg model)
        {
            var i = 1;
            var workbook1 = new XLWorkbook();
            var worksheet1 = workbook1.Worksheets.Add("Отчет Lotus");
            foreach (var zn in model.ShemeDbZg.ToList())
            {
                worksheet1.Cell($"A{i}").Value = zn.NameFio;
                worksheet1.Cell($"B{i}").Value = zn.Num;
                worksheet1.Cell($"C{i}").Value = zn.Status;
                worksheet1.Cell($"D{i}").Value = zn.Datareg;
                worksheet1.Cell($"E{i}").Value = zn.InCardRespOutNum;
                i++;
            }
            workbook1.SaveAs("C:\\Отчет.xlsx");
        }

    }
}
