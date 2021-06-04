using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace Construction.HttpRequests
{
    class AdminRequest
    {
        #region GET
        public static int AdminLogin(string Login, string Password)
        {
            try
            {
                var webRequest = (HttpWebRequest)WebRequest.Create("https://localhost:44394/Admin/" + Login + "/" + Password);
                var webResponse = (HttpWebResponse)webRequest.GetResponse();
                var reader = new StreamReader(webResponse.GetResponseStream());
                string temp = reader.ReadToEnd();
                return JsonConvert.DeserializeObject<int>(temp);
            }
            catch
            {
                return -2;
            }

        }
        #endregion
    }
}
