using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Xml;
using LibaryXMLAuto.ModelXmlSql.ConvertModel.DesirializationSql;
using LibaryXMLAutoModelXmlSql.Model.FaceError;

namespace SyteIfns.PostResponse.FileStream
{
    public class DonloadFileReport
    {
        public Stream DonloadTrebovanie()
        {
            try
            {
                WebRequest req;
                WebResponse resp;
                req = (HttpWebRequest)WebRequest.Create(AddresFile.AdressFile.AdressTrebovanie);
                req.Timeout = 10000;
                req.Method = "GET";
                req.ContentLength = 0;
                resp = (HttpWebResponse)req.GetResponse();
                return resp.GetResponseStream();
            }
            catch (Exception e)
            {
                return null;
            }

        }


    }
}