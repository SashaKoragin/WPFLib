using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using WordReport.Xsd;
using Word = Microsoft.Office.Interop.Word;

namespace WordReport.ReportWord.Report
{
    class ReportsWotrd
    {
        public void Document(NewDataSet cls, String inn)
        {
            // Считывает шаблон и сохраняет измененный в новом
            try
            {
                
                Word.Application oWord = new Word.Application();
               Word.Document oDoc = GetDoc(@"C:\Debug\ReportWord\Templaters\Template.dotx", cls,oWord);
                oDoc.SaveAs(@"C:\1\"+inn +".docx");
                oDoc.Close();
                oWord.Quit();
          
            }
            catch (Exception e)
            {

            }
        }

        private Word.Document GetDoc(string path, NewDataSet cls,Word.Application app)
        {
            
            try
            {
                Word.Document oDoc = app.Documents.Add(path);
                SetTemplate(oDoc, cls);
                return oDoc;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return null;
            }
        }
        // Замена закладки SECONDNAME на данные введенные в textBox
        private void SetTemplate(Word.Document oDoc, NewDataSet cls)
        {
            var i = 1;
            var table =  oDoc.Bookmarks["Table"];
            var T = oDoc.Tables.Add(table.Range, cls.Table1.Count, 5, 1, 2);
            var o = T.Rows.Count;
            foreach (var w in cls.Table1)
            {
                   T.Rows[i].Cells[1].Range.Text = i.ToString();
                   T.Rows[i].Cells[2].Range.Text = w.D126;
                   T.Rows[i].Cells[3].Range.Text = w.D83;
                   T.Rows[i].Cells[4].Range.Text = w.D39;
                   T.Rows[i].Cells[5].Range.Text = w.N313;
                   T.Columns.AutoFit();
                   i++;
            }
            foreach (var w in cls.Table2)
            {
                oDoc.Bookmarks["Adres"].Range.Text = w.N320;
            }
            foreach (var w in cls.Table3)
            {
                oDoc.Bookmarks["Name"].Range.Text = w.N18;
            }
            oDoc.Bookmarks["GetDate"].Range.Text = DateTime.Now.ToString("dd MMMM yyyy");
        }
    }
}
