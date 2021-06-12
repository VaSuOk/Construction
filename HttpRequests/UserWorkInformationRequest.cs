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
    class UserWorkInformationRequest
    {
        #region GET
        public static List<UserWorkInformation> GetAllUserWI()
        {
            try
            {
                var webRequest = (HttpWebRequest)WebRequest.Create("https://localhost:44394/UserWorkInformation/");
                var webResponse = (HttpWebResponse)webRequest.GetResponse();
                var reader = new StreamReader(webResponse.GetResponseStream());
                string temp = reader.ReadToEnd();
                return JsonConvert.DeserializeObject<List<UserWorkInformation>>(temp);
            }
            catch
            {
                return null;
            }
        }
        public static UserWorkInformation GetUserWIByID(int ID)
        {
            try
            {
                var webRequest = (HttpWebRequest)WebRequest.Create("https://localhost:44394/UserWorkInformation/"+ID);
                var webResponse = (HttpWebResponse)webRequest.GetResponse();
                var reader = new StreamReader(webResponse.GetResponseStream());
                string temp = reader.ReadToEnd();
                return JsonConvert.DeserializeObject<UserWorkInformation>(temp);
            }
            catch
            {
                return null;
            }
        }

        public static List<UserWorkInformation> GetUserByStageAndPosition( string Region, string Stage, string Position)
        {
            if(Region == "") { Region = "none"; }
            if(Stage == "") { Stage = "none"; }
            if(Position == "") { Position = "none"; }
            try
            {
                var webRequest = (HttpWebRequest)WebRequest.Create("https://localhost:44394/UserWorkInformation/" + Region + "/" + Stage + "/" + Position);
                var webResponse = (HttpWebResponse)webRequest.GetResponse();
                var reader = new StreamReader(webResponse.GetResponseStream());
                string temp = reader.ReadToEnd();
                return JsonConvert.DeserializeObject<List<UserWorkInformation>>(temp);
            }
            catch
            {
                return null;
            }
        }
        #endregion

        #region POST
        public static async System.Threading.Tasks.Task PostUpdateUWI(UserWorkInformation userWorkInformation)
        {
            //int test = 0;
            try
            {
                using (var client = new HttpClient())
                using (var request = new HttpRequestMessage(HttpMethod.Post, String.Format("https://localhost:44394/UserWorkInformation")))
                {
                    var json = JsonConvert.SerializeObject(userWorkInformation);
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
                throw;
            }
        }
        #endregion

        #region PUT
        public static async System.Threading.Tasks.Task CreateUserWorkInformation(UserWorkInformation userWorkInformation)
        {
            try
            {
                using (var client = new HttpClient())
                using (var request = new HttpRequestMessage(HttpMethod.Put, String.Format("https://localhost:44394/UserWorkInformation/{0}", userWorkInformation.ID)))
                {
                    var json = JsonConvert.SerializeObject(userWorkInformation);
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

        #region DELETE

        public static async System.Threading.Tasks.Task DeleteUserWI(int id)
        {
            using (var client = new HttpClient())
            using (var request = new HttpRequestMessage(HttpMethod.Delete, String.Format("https://localhost:44394/UserWorkInformation/"+ id)))
            {

                using (var response = await client
                    .SendAsync(request, HttpCompletionOption.ResponseHeadersRead)
                    .ConfigureAwait(false))
                {
                    response.EnsureSuccessStatusCode();
                }
            }

        }
        #endregion
    }
}
