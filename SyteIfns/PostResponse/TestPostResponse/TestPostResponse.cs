using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Mvc;
using RestSharp;

namespace SyteIfns.PostResponse.TestPostResponse
{
    public class TestPostResponse
    {

        [HttpGet]
        public string MyTest()
        {
            string adress = @"http://localhost:8181";
            try
            {
                var cl = new RestClient(adress);
                var request = new RestRequest("/ServiceRest/Test", Method.POST);
                request.Method = Method.POST;
                IRestResponse response = cl.ExecuteAsPost(request, "POST");
                var content = response.Content; // raw content as string
                return content;
            }
            catch (Exception e)
            {
                return e.ToString();
            }
        }
        [HttpGet]
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