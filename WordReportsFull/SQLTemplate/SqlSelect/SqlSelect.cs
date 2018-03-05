using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml.Schema;
using Microsoft.WindowsAPICodePack.Shell.Interop;

namespace WordReportsFull.SQLTemplate.SqlSelect
{
    public class SqlSelect
    {
        public static object[] SqlCom(string nameF)
        {
            switch (nameF)
            {
                case "SummNedoim.docx":
                    object[] summnedoimsql = SqlCommand.SqlCommands.SummNedoim;
                    return summnedoimsql;
                case "NDflFl.docx":
                    object[] ndflfl = SqlCommand.SqlCommands.Ndflfl;
                    return ndflfl;
                default:
                    return null;
            }
        }
    }

    public class XmlSelect
    {
        public static XmlSchemaSet SqlCom(string nameF)
        {
            try
            {
                switch (nameF)
                {
                    case "SummNedoim.docx":
                        XmlSchemaSet summnedoimxml = XSDSheme.XMLShemaColect.XMLShemeColTemp.XmlNedoimsumm;
                        return summnedoimxml;
                    case "NDflFl.docx":
                        XmlSchemaSet ndflxml = XSDSheme.XMLShemaColect.XMLShemeColTemp.XmlNdfl;
                        return ndflxml;
                    default:
                        return null;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return null;
            }

        }
    }
}

//    public class QbeSelect
//    {
//        public static object[] QbeSelection(string nameF)
//        {
//            try
//            {
//                switch (nameF)
//                {
//                    case "SummNedoim.docx":
//                        object[] summnedoimxml = Trige.SelectVisibl.SelectVisibl.SummNedoim;
//                        return summnedoimxml;
//                    case "NDflFl.docx":
//                        object[] ndflxml = Trige.SelectVisibl.SelectVisibl.NdflFl;
//                        return ndflxml;
//                    default:
//                        return null;
//                }
//            }
//            catch (Exception e)
//            {
//                MessageBox.Show(e.Message);
//                return null;
//            }
//        }
//    }
//}
