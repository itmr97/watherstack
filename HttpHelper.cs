using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using System.Web;


namespace watherstack
{
    internal class HttpHelper
    {
        public string json_conv(string url)
        {
            HttpWebRequest request = HttpWebRequest.CreateHttp(url);
            var respond=request.GetResponse();
            StreamReader reader= new StreamReader(respond.GetResponseStream());
            string json = reader.ReadToEnd();
            return json;
        }
    }
}
