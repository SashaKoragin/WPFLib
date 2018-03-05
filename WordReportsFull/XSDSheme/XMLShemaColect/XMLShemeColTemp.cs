using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml.Schema;

namespace WordReportsFull.XSDSheme.XMLShemaColect
{
    class XMLShemeColTemp
    {
        //Привязка XSD к документу

        public static readonly XmlSchemaSet XmlNedoimsumm = XmlSummNedoim();
        public static readonly XmlSchemaSet XmlNdfl = XmlNdflFl();

        public static XmlSchemaSet  XmlSummNedoim()
        {
            try
            {
            XmlSchemaSet sc = new XmlSchemaSet();
            sc.Add(null, @"XSDSheme\SummNedoim\XML\Adress.xsd");
            sc.Add(null, @"XSDSheme\SummNedoim\XML\Name.xsd");
            sc.Add(null, @"XSDSheme\SummNedoim\XML\Summ.xsd");
            sc.Add(null, @"XSDSheme\SummNedoim\XML\GetDate.xsd");
            return sc;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return null;
            }
        }

        public static XmlSchemaSet XmlNdflFl()
        {
            try
            {
                XmlSchemaSet sc = new XmlSchemaSet();
                sc.Add(null, @"XSDSheme\NdflFl\XML\FlAdressName.xsd");
                sc.Add(null, @"XSDSheme\NdflFl\XML\Ndfl.xsd");
                return sc;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return null;
            }
        }

    }
}
