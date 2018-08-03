using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using WordReportsFull.ReportsWordDocumentsSQL;
using WordReportsFull.WpfForm.Mains;
using WordReportsFull.WpfForm.Mains.FormYreg;
using Word = Microsoft.Office.Interop.Word;

namespace WordReportsFull.EventsFull
{
   public class ReportsStart
    {

        public Uregulirovanie MainWindow;
        public ReportsStart(Uregulirovanie owner)  //Конструктор для формы xaml
        {
            MainWindow = owner;
        }




        public void Report()
        {
            SeathControl seath = new SeathControl();
            var inn = seath.Seathinn(MainWindow.ListFile);
            var god = seath.Seathgod(MainWindow.ListFile);
            if (!ValidationControl.IsValidControl.IsSeathZn(inn) || !ValidationControl.IsValidControl.IsSelectcom1(MainWindow.ComboBox)|| !ValidationControl.IsValidControl.IsSeathZn(god))
            {
                MessageBox.Show("Не прошел");
            }
            else
            {
                try
                {
                    
                    var contentparam = (ValidationControl.ContentZn)MainWindow.Dispatcher.Invoke(() => MainWindow.ComboBox.SelectedValue);
                    Word.Application oWord = new Word.Application();
                    Word.Document oDoc = ReportsWordDocumentsSql.SelectDocument(oWord, inn.Text,god.Text, contentparam);
                    if (oDoc != null)
                    {
                        oDoc.SaveAs(@"C:\1\" + inn.Text + ".docx");
                        oDoc.Close();
                    }
                    oWord.Quit();
                    //Сообщение об ошибке что NULL
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }

            }
        }

    }
}
