using System;
using System.Net;
using System.Xml;
using LibaryXMLAuto.ModelXmlSql.ConvertModel.DesirializationSql;
using LibaryXMLAutoModelXmlSql.Model.FaceError;

namespace SyteIfns.PostResponse
{
    public class Response
    {
        internal Face FaceRestError()
        {
            WebRequest req;
            WebResponse resp;
            Face answer;
            var uri = Adress.Address.AddresError;
            req = (HttpWebRequest)WebRequest.Create(Adress.Address.AddresError);
            req.Timeout = 10000;
            req.Method = "POST";
            req.ContentLength = 0;
                resp = (HttpWebResponse) req.GetResponse();
                SqlDesirialization sqldesirial = new SqlDesirialization();
                using (XmlReader reader = new XmlTextReader(resp.GetResponseStream()))
                {
                    try
                    {
                        answer = (Face) sqldesirial.ReadXml(reader, typeof(Face));
                        return answer;
                    }
                    catch (Exception e)
                    {
                        return null;
                    }
                }
        }
        }
    }