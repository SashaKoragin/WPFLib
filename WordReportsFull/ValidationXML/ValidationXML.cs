using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using WordReportsFull.ValidationControl;
using WordReportsFull.XSDSheme.SummNedoim.XML;

namespace WordReportsFull.ValidationXML
{
    public class ValidationXml
    {

        private Boolean valid = true;
        public String Xml(XmlReader reader, ContentZn contentparam)
        {     
                valid = true;
                XmlReaderSettings settings = new XmlReaderSettings();
                settings.ValidationType = ValidationType.Schema;
                settings.Schemas = contentparam.XmlCol;
                settings.ConformanceLevel = ConformanceLevel.Auto;
                settings.ValidationFlags |= XmlSchemaValidationFlags.ProcessInlineSchema;
                settings.ValidationFlags |= XmlSchemaValidationFlags.ReportValidationWarnings;
                settings.ValidationEventHandler += ValidationCallBack;  //Задание на проверку данных
                XmlReader readererror = XmlReader.Create(reader, settings);
                readererror.Read();
                return valid == true ? readererror.LocalName : null;
        }


        private void ValidationCallBack(object sender, ValidationEventArgs args)  //Задание на проверку данных
        {
            if (args.Severity == XmlSeverityType.Warning)
            { 
                Console.WriteLine(@"\tWarning: Matching schema not found.  No validation occurred." + args.Message);
                MessageBox.Show(args.Message);
                valid = false;
            }
            else
                Console.WriteLine(@"\tValidation error: " + args.Message);
                MessageBox.Show(args.Message);
                valid = false;

        }
    }
}
