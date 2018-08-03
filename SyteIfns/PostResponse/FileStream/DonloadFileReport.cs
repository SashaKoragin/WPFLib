using System;
using System.IO;
using System.Net;

namespace SyteIfns.PostResponse.FileStream
{
    public class DonloadFileReport
    {
        public Stream DonloadFile(string adress)
        {
            try
            {
                WebRequest req;
                WebResponse resp;
                req = (HttpWebRequest)WebRequest.Create(adress);
                req.Timeout = 60000;
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