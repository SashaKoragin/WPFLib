using System;
using System.Windows;
using System.Xml;
using System.Xml.Serialization;
using WordReportsFull.XSDSheme.SummNedoim.XML;
using Word = Microsoft.Office.Interop.Word;
using WordReportsFull.XSDSheme.NdflFl.XML;

namespace WordReportsFull.CreateReportWord
{
    public class CreateWords
    {
        public static Word.Document ReportWordsGenerate(Word.Document doc, string name, XmlReader read)
        {
            switch (name)
            {
                case "Adress":
                    XmlSerializer serializeradress = new XmlSerializer(typeof(Adress));
                    Adress adresorg = (Adress) serializeradress.Deserialize(read);
                    doc = GenerateWord.AdressOrg(doc, adresorg);
                    return doc;
                case "Name":
                    XmlSerializer serializernameorg = new XmlSerializer(typeof(NameOrg));
                    NameOrg nameorg = (NameOrg) serializernameorg.Deserialize(read);
                    doc = GenerateWord.NameOrg(doc, nameorg);
                    return doc;
                case "Summ":
                    XmlSerializer serializersummorg = new XmlSerializer(typeof(SummOrg));
                    SummOrg summorg = (SummOrg) serializersummorg.Deserialize(read);
                    doc = GenerateWord.SummOrg(doc, summorg);
                    return doc;
                case "GetDate":
                    XmlSerializer serializernameorgdatazapr = new XmlSerializer(typeof(Dates));
                    Dates datazapr = (Dates) serializernameorgdatazapr.Deserialize(read);
                    doc = GenerateWord.DataZapr(doc, datazapr);
                    return doc;
                case "FlAdressName":
                    XmlSerializer serializeradressnamefl = new XmlSerializer(typeof(AdressNameFl));
                    AdressNameFl adresfnamefl = (AdressNameFl) serializeradressnamefl.Deserialize(read);
                    doc = GenerateWord.AdressNameFl(doc, adresfnamefl);
                    return doc;
                case "Ndfl":
                    XmlSerializer serializerndfl = new XmlSerializer(typeof(NdflFl));
                    NdflFl declarfl = (NdflFl) serializerndfl.Deserialize(read);
                    doc = GenerateWord.DeclarNdfl(doc, declarfl);
                    return doc;
                default:
                    return null;
            }
        }
    }

    public class GenerateWord
    {
        public static Word.Document AdressOrg(Word.Document word, Adress adresorg)
        {
            word.Bookmarks["Adress"].Range.Text = adresorg.FN213.N320;
            return word;
        }

        public static Word.Document NameOrg(Word.Document word, NameOrg nameorg)
        {
            word.Bookmarks["Name"].Range.Text = nameorg.FN212.N18;
            return word;
        }

        public static Word.Document SummOrg(Word.Document word, SummOrg summorg)
        {
            var i = 1;
            var tables = word.Bookmarks["Summ"];
            var table = word.Tables.Add(tables.Range, summorg.FN52.Length, 5, 1, 2);
            foreach (var summ in summorg.FN52)
            {
                table.Rows[i].Cells[1].Range.Text = i.ToString();
                table.Rows[i].Cells[2].Range.Text = summ.FN1011.FN1002.D126;
                table.Rows[i].Cells[3].Range.Text = summ.D83;
                table.Rows[i].Cells[4].Range.Text = summ.FN1011.D39;
                table.Rows[i].Cells[5].Range.Text = summ.N313;
                table.Columns.AutoFit();
                i++;
            }
            return word;
        }

        public static Word.Document DataZapr(Word.Document word, Dates datazapr)
        {
            word.Bookmarks["GetDate"].Range.Text = datazapr.row.Date.ToString();
            return word;
        }

        public static Word.Document AdressNameFl(Word.Document word, AdressNameFl adressnamefl)
        {
            try
            {
                word.Bookmarks["Adressfl"].Range.Text = adressnamefl.Fn212.FN213.N320;
                word.Bookmarks["Namefl"].Range.Text = adressnamefl.Fn212.N18;
                word.Bookmarks["Nameot"].Range.Text = adressnamefl.Fn212.FN213.Uvaz;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            return word;
        }

        public static Word.Document DeclarNdfl(Word.Document word, NdflFl ndfl)
        {
            try
            {
                int i = 1;
                string naustr = @"Инспекцией {0} №{1} было принято решение о возврате налога на доходы физических лиц  в сумме {2} рублей{3}";
                string obzac = @"№{0} в сумме {1} рублей{2}";
                foreach (var declar in ndfl.Fn1534)
                {
                    word.Bookmarks["Deklarndfl"].Range.Paragraphs.Add();
                    word.Bookmarks["Deklarndfl"].Range.Text = declar.NDFL;
                    if (i == 1)
                    {
                        naustr = string.Format(naustr, declar.FN17091.DataIzd, declar.N590, declar.FN17091.D83_1, ndfl.Fn1534.Length > 1 ? ", {0}" : ".");
                    }
                    else
                    {
                        naustr = string.Format(naustr, string.Format(obzac, declar.N590, declar.FN17091.D83_1, ndfl.Fn1534.Length== i ? "." : ", {0}"));
                    }
                    i++;
                }
                word.Bookmarks["End"].Range.Paragraphs.Add();
                word.Bookmarks["End"].Range.Text = naustr;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            return word;
        }
    }
}
