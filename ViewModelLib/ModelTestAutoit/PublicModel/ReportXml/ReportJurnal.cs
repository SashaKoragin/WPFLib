using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;
using Prism.Mvvm;


namespace ViewModelLib.ModelTestAutoit.PublicModel.ReportXml
{
   public class ReportJurnal
    {
        public ObservableCollection<ReportJurnal> _xmlreportjurnal = new ObservableCollection<ReportJurnal>();

        public ObservableCollection<ReportJurnal> XmlReportJurnal
        {
            get { return _xmlreportjurnal; }
        }

        public ObservableCollection<ReportJurnal> _xmlfile = new ObservableCollection<ReportJurnal>();

        public ObservableCollection<ReportJurnal> XmlFile
        {
            get { return _xmlfile; }
        }

        private ReportJurnal _xmlJurnal;
        private Icon _icon;
        private string _name;
        private string _path;
        public ReportJurnal XmlJurnal
        {
            get { return _xmlJurnal; }
            set
            {
                _xmlJurnal = value;
            }
        }

        public Icon Icon
        {
            get { return _icon; }
            set { _icon = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string Path
        {
            get { return _path; }
            set { _path = value; }
        }
        public FlowDocument Document
        {
            get { return Zavisimosti.DocumentJurnal(Path); }
        }
    }

    public class Zavisimosti
    {
        /// <summary>
        /// Функция показа содержимого xml файла без главного элемента
        /// </summary>
        /// <param name="path">Путь к файлу</param>
        /// <returns></returns>
        public static FlowDocument DocumentJurnal(string path)
        {
            if (File.Exists(path) & Path.GetExtension(path) == ".xml")
            {
                var xmldoc = LibaryXMLAuto.ReadOrWrite.XmlReadOrWrite.Document(path);
                FlowDocument doc = new FlowDocument();
                doc.TextAlignment = TextAlignment.Left;
                doc.IsOptimalParagraphEnabled = true;
                doc.IsHyphenationEnabled = true;
                doc.FontStyle = FontStyles.Italic;
                doc.Background = System.Windows.Media.Brushes.Yellow;
                doc.Foreground = System.Windows.Media.Brushes.Blue;
                for (int i = 1; i < xmldoc.DocumentElement.ChildNodes.Count; i++)
                {
                    doc.Blocks.Add(new Paragraph(new Run(xmldoc.DocumentElement.ChildNodes.Item(i).OuterXml)));
                }
                return doc;
            }
            return null;
        }
    }
}
