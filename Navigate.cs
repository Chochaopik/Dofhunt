using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Dofsor {
    public class Navigate {

        public CookieContainer cookie = new CookieContainer();

        public string nav(string url, string data = "") {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            request.ContentType = "application/x-www-form-urlencoded; charset=UTF-8";
            request.Accept = "text/html, */*; q=0.01";
            request.Headers.Add("DNT", "1");
            request.Headers.Add("X-Requested-With", "XMLHttpRequest");
            request.Headers.Add("Upgrade-Insecure-Requests", "1");
            request.Headers.Add("Accept-Encoding", "gzip, deflate");
            request.CookieContainer = cookie;
            request.ServicePoint.Expect100Continue = false;
            request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;

            if (data != "") {
                request.Method = "POST";
                byte[] buffer = Encoding.ASCII.GetBytes(data);
                Stream postData = request.GetRequestStream();
                postData.Write(buffer, 0, buffer.Length);
                postData.Close();
            }

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            cookie.Add(response.Cookies);

            StreamReader answer = new StreamReader(response.GetResponseStream());

            string source = answer.ReadToEnd();

            response.Close();
            answer.Close();
            return source;
        }
    }
}
