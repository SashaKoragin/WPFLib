using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Mvc;
using System.Xml;
using RestSharp;
//using LibaryXMLAutoModelXmlSql.Model.FaceError;
using SyteIfns.Models.PostRestAplication.ModelFaceError;


namespace SyteIfns.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Home()
        {
            return View();
        }

        [HttpPost]
        public string FaceSelect()
        {
            WebRequest req;
            WebResponse resp;
            try
            {
                string data = "{\"N1New\":232323,\"N1Old\":43434343}";
                byte[] postBytes = Encoding.ASCII.GetBytes(data);
                req = (HttpWebRequest)WebRequest.Create(Adress.Address.AdressTest1);
                req.Method = "POST";
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
    }
}