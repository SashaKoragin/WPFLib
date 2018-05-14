using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace SyteIfns.PostResponse
{
    public class PostRestAdd
    {
        public string FaceSelect(int? nold,int? nnew)
        {
            if (nnew != null||nnew != null)
            {
                WebRequest req;
                WebResponse resp;
                try
                {
                    string data = "{\"N1New\":" + nnew + ",\"N1Old\":" + nold + "}";
                    byte[] postBytes = Encoding.ASCII.GetBytes(data);
                    req = (HttpWebRequest)WebRequest.Create(Adress.Address.AddresFaceAdd);
                    req.Method = "POST";
                    req.Timeout = 10000;
                    req.ContentType = "application/json";
                    req.ContentLength = postBytes.Length;
                    using (var w = new StreamWriter(req.GetRequestStream()))
                    {
                        w.Write(data);
                        w.Flush();
                    }
                    resp = (HttpWebResponse)req.GetResponse();
                    string s;
                    using (var r = new StreamReader(resp.GetResponseStream()))
                    {
                        s = r.ReadToEnd();
                    }
                    return s;
                }
                catch (Exception e)
                {
                    return e.ToString();
                }
            }
            return "Не все входящие данные определены!!!";
        }
    }
}