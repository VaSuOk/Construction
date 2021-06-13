using Construction.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;

namespace Construction.HttpRequests
{
    class BrigadeRequest
    {
        #region DELETE
        public static async System.Threading.Tasks.Task<bool> DeleteBrigade(int id)
        {
            try
            {
                using (var client = new HttpClient())
                using (var request = new HttpRequestMessage(HttpMethod.Delete, String.Format("https://localhost:44394/Brigade/" + id)))
                {

                    using (var response = await client
                        .SendAsync(request, HttpCompletionOption.ResponseHeadersRead)
                        .ConfigureAwait(false))
                    {
                        response.EnsureSuccessStatusCode();
                    }
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion

        #region POST
        public static async System.Threading.Tasks.Task<bool> UppdateBrigade(Brigade brigade)
        { 
            try
            {
                using (var client = new HttpClient())
                using (var request = new HttpRequestMessage(HttpMethod.Post, String.Format("https://localhost:44394/Brigade")))
                {
                    var json = JsonConvert.SerializeObject(brigade);
                    using (var stringContent = new StringContent(json, Encoding.UTF8, "application/json"))
                    {
                        request.Content = stringContent;

                        using (var response = await client
                            .SendAsync(request, HttpCompletionOption.ResponseHeadersRead)
                            .ConfigureAwait(false))
                        {
                            response.EnsureSuccessStatusCode();
                        }
                    }
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion

        #region PUT
        public static async System.Threading.Tasks.Task<bool> CreateBrigade(Brigade brigade)
        {
            try
            {
                using (var client = new HttpClient())
                using (var request = new HttpRequestMessage(HttpMethod.Put, String.Format("https://localhost:44394/Brigade/{0}", brigade.ID)))
                {
                    var json = JsonConvert.SerializeObject(brigade);
                    using (var stringContent = new StringContent(json, Encoding.UTF8, "application/json"))
                    {
                        request.Content = stringContent;

                        using (var response = await client
                            .SendAsync(request, HttpCompletionOption.ResponseHeadersRead)
                            .ConfigureAwait(false))
                        {
                            response.EnsureSuccessStatusCode();
                        }
                    }
                }
                return true;
            }
            catch
            {
                return false;
                //!!!!!!
            }
        }
        #endregion
        #region GET
        public static List<Brigade> GetBrigade(string Region, string Stage, bool isWork)
        {
            if (Region == "") { Region = "none"; }
            if (Stage == "") { Stage = "none"; }
            
            try
            {
                var webRequest = (HttpWebRequest)WebRequest.Create("https://localhost:44394/Brigade/" + Region + "/" + Stage + "/" + isWork);
                var webResponse = (HttpWebResponse)webRequest.GetResponse();
                var reader = new StreamReader(webResponse.GetResponseStream());
                string temp = reader.ReadToEnd();
                return JsonConvert.DeserializeObject<List<Brigade>>(temp);
            }
            catch
            {
                return null;
            }
        }
#endregion
    }
}
