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
    class ConstructionRequest
    {
        #region PUT
        public static async System.Threading.Tasks.Task CreateUserWorkInformation(ConstructionObject constructionObject)
        {
            try
            {
                using (var client = new HttpClient())
                using (var request = new HttpRequestMessage(HttpMethod.Put, String.Format("https://localhost:44394/ConstructionObject/{0}", constructionObject.ID)))
                {
                    var json = JsonConvert.SerializeObject(constructionObject);
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
            }
            catch
            {
                //!!!!!!
            }
        }
        #endregion
        #region GET
        public static List<ConstructionObject> GetALLConstO(string Region = "none", string Sity = "none", string Type = "none")
        {
            if (Region == "") { Region = "none"; }
            if (Sity == "") { Sity = "none"; }
            if (Type == "") { Type = "none"; }

            try
            {
                var webRequest = (HttpWebRequest)WebRequest.Create("https://localhost:44394/ConstructionObject/" + Region + "/" + Sity + "/" + Type);
                var webResponse = (HttpWebResponse)webRequest.GetResponse();
                var reader = new StreamReader(webResponse.GetResponseStream());
                string temp = reader.ReadToEnd();
                return JsonConvert.DeserializeObject<List<ConstructionObject>>(temp);
            }
            catch
            {
                return null;
            }
        }

        public static List<ConstructionObject> GetALLConstOByStage(int Stage)
        {
            try
            {
                var webRequest = (HttpWebRequest)WebRequest.Create("https://localhost:44394/ConstructionObject/" + Stage);
                var webResponse = (HttpWebResponse)webRequest.GetResponse();
                var reader = new StreamReader(webResponse.GetResponseStream());
                string temp = reader.ReadToEnd();
                return JsonConvert.DeserializeObject<List<ConstructionObject>>(temp);
            }
            catch
            {
                return null;
            }
        }

        public static List<ConstructionObject> GetConstructionOBySearch(string Initials, string Street)
        {
            if (Initials == "") { Initials = "none"; }
            if (Street == "") { Street = "none"; }

            try
            {
                var webRequest = (HttpWebRequest)WebRequest.Create("https://localhost:44394/ConstructionObject/" + Initials + "/" + Street );
                var webResponse = (HttpWebResponse)webRequest.GetResponse();
                var reader = new StreamReader(webResponse.GetResponseStream());
                string temp = reader.ReadToEnd();
                return JsonConvert.DeserializeObject<List<ConstructionObject>>(temp);
            }
            catch
            {
                return null;
            }
        }
        #endregion

        #region DELETE
        public static async System.Threading.Tasks.Task<bool> DeleteConstructionO(int id)
        {
            try
            {
                using (var client = new HttpClient())
                using (var request = new HttpRequestMessage(HttpMethod.Delete, String.Format("https://localhost:44394/ConstructionObject/" + id)))
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
        public static async System.Threading.Tasks.Task<bool> UppdateConstructionO(ConstructionObject  constructionObject)
        {
            try
            {
                using (var client = new HttpClient())
                using (var request = new HttpRequestMessage(HttpMethod.Post, String.Format("https://localhost:44394/ConstructionObject")))
                {
                    var json = JsonConvert.SerializeObject(constructionObject);
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
    }
}
