using System;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Controls;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;
using WordReportsFull.ValidationControl;
using WordReportsFull.ValidationXML;
using static System.String;
using Word = Microsoft.Office.Interop.Word;

namespace WordReportsFull.ReportsWordDocumentsSQL
{
    public class ReportsWordDocumentsSql
    {

        public static Word.Document SelectDocument(Word.Application oWord, String inn, String god, ContentZn contentparam)
        {
            
            ValidationXml validate= new ValidationXml();
            Word.Document oDoc = oWord.Documents.Add(contentparam.FullName);
            XmlDocument xml = new XmlDocument();
            var i = 0;
            foreach (var sql in contentparam.SqlT)
            {

                try
                {
                    using (var con = new SqlConnection(Config.Config.Connection))
                    {
                        using (var cmd = new SqlCommand(sql.ToString(), con))
                        {
                            
                            cmd.CommandType = CommandType.Text;
                            cmd.Parameters.AddWithValue("@INN", inn);
                            cmd.Parameters.AddWithValue("@GOD", god);
                            con.Open();
                            using (XmlReader dr = cmd.ExecuteXmlReader())
                            {
                                string namexsd = validate.Xml(dr, contentparam);
                                if (namexsd == "")
                                {
                                    con.Close();
                                    return null;
                                }
                                oDoc = CreateReportWord.CreateWords.ReportWordsGenerate(oDoc, namexsd, dr);
                            }
                            con.Close();
                            i++;
                        }
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            }
            return oDoc;
        }

    }
}