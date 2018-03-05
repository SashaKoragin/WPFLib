using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LibaryAIS3Windows.ButtonsClikcs;
using LibaryAIS3Windows.ExitLogica;
using LibaryXMLAuto.ConvettToXml;
using LibaryXMLAutoModelXmlAuto.ModelSnuOne;


namespace TestAutoit.Window
{
    public class TimeClass
    {
        /// <summary>
        /// Времменнный класс для конвертации в XML XLSX
        /// </summary>
        public void Timeclass()
        {
            XmlConvert convert = new XmlConvert();
            List<string> listinn = new List<string>();
            var path = @"C:\Желтые расчеты.xlsx";
            var worbook = new ClosedXML.Excel.XLWorkbook(path);
            var ws = worbook.Worksheets.Worksheet("желтые расчеты");
            var countcell = ws.Columns("F").Cells().Count(inn => !inn.IsEmpty());
            for (int i = 0; i < countcell; i++)
            {
                if (i >= 2)
                {
                    listinn.Add(ws.Cell("F" + i).Value.ToString());
                }
            }
            convert.Serializ(listinn);
        }

        /// <summary>
        /// Авто кликер для ветки 
        /// Налоговое администрирование\Физические лица\1.06. Формирование и печать CНУ\
        /// 1. Создание заявки на формирование СНУ для единичной печати
        /// </summary>
        public void AutoClicerSnuOneForm(Button button)
        {
            Task.Run(delegate
            {
                ButtonsKey.KeyButtons.StatusButtonRed(button);
                KclicerButton clickerButton = new KclicerButton();
                Exit exit = new Exit();
                LibaryAIS3Windows.Window.Windows ais3 = new LibaryAIS3Windows.Window.Windows();
                LibaryXMLAuto.ReadOrWrite.XmlReadOrWrite read = new LibaryXMLAuto.ReadOrWrite.XmlReadOrWrite();
                object obj = read.ReadXml(Constantsfile.ConstantFile.FileInn, typeof(SnuOneForm));
                SnuOneForm snumodel = (SnuOneForm) obj;
                if (ButtonsKey.KeyButtons.IsWork)
                {
                    if (ais3.WinexistsAis3() == 1)
                    {
                        foreach (var inn in snumodel.INN)
                        {
                            if (ButtonsKey.KeyButtons.IsWork)
                            {
                                clickerButton.Click1(Constantsfile.ConstantFile.FileJurnalError, Constantsfile.ConstantFile.FileJurnalOk,inn.INN1);
                                read.DeleteAtributXml(Constantsfile.ConstantFile.FileInn, LibaryXMLAuto.GenerateAtribyte.GeneratorAtribute.GenerateAtributeInn(inn.INN1));
                                ButtonsKey.KeyButtons.IsCount++;
                            }
                            else
                            {
                                break;
                            }
                        }
                        var status = exit.Exitfunc(ButtonsKey.KeyButtons.IsCount, snumodel.INN.Length,
                        ButtonsKey.KeyButtons.IsWork);
                        ButtonsKey.KeyButtons.IsCount = status.IsCount;
                        ButtonsKey.KeyButtons.IsWork = status.IsWork;
                        ButtonsKey.KeyButtons.StatusGrinandRed(button, status.Stat);
                    }
                    else
                    {
                        MessageBox.Show(LibaryAIS3Windows.Status.StatusAis.Status1);
                    }
                }
                else
                {
                    MessageBox.Show(LibaryAIS3Windows.Status.StatusAis.Status4);
                }
            });
        

    }
}
}
