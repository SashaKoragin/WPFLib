using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml;
using System.Xml.Serialization;
using WordReport.ReportWord.Report;
using WordReport.Xsd;

namespace WordReport.Sobytie
{
    internal class Sob1
    {
        public MainWindow P2;

        internal Sob1(MainWindow owner)
        {
            P2 = owner;
        }

        public void Zapros()
        {
            if (!Validation.IsValid.IsSeathZn(P2.TextBox))
            {

            }
            else
            {
                string[] separators = { ",", ".", "!", "?", ";", ":", " " };
                String[] value = P2.TextBox.Text.Split(separators, StringSplitOptions.RemoveEmptyEntries);
                foreach (var val in value)
                {
                    string exceptionMsg = "";
                    var add = new Resursys.Obrabochik.SqlConect();
                    DataSet table = add.AdataTable(val, ref exceptionMsg);
                    if (Validation.IsEmpty.IsEmptys(table))
                    {
                        XmlSerializer formatter = new XmlSerializer(typeof(NewDataSet));
                        table.WriteXml(@"C:\1\www.xml");
                        using (FileStream fs = new FileStream(@"C:\1\www.xml", FileMode.Open))
                        {
                            NewDataSet newpeople = (NewDataSet)formatter.Deserialize(fs);
                            ReportsWotrd report = new ReportsWotrd();
                            report.Document(newpeople, val);
                        }
                    }
                    else
                    {
                        //P2.Resul.ItemsSource = null;
                        //MessageBox.Show(exceptionMsg);
                    }
                }
            }

        }

    }
}