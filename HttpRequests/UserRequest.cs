using Construction.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using Сonstruction.Model;

namespace Construction.HttpRequests
{
    class UserRequest
    {
        #region GET
        public static int LoginUser(string Login, string Password)
        {
            try
            {
                var webRequest = (HttpWebRequest)WebRequest.Create("https://localhost:44394/Users/" + Login + "/" + Password);
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
        public static User GetUserByID(int ID)
        {
            try
            {
                var webRequest = (HttpWebRequest)WebRequest.Create("https://localhost:44394/Users/" + ID);
                var webResponse = (HttpWebResponse)webRequest.GetResponse();
                var reader = new StreamReader(webResponse.GetResponseStream());
                string temp = reader.ReadToEnd();
                return JsonConvert.DeserializeObject<User>(temp);
            }
            catch
            {
                return null;
            }
        }
        
        #endregion

        #region POST
        public static async System.Threading.Tasks.Task PostInsertUserAsync(UserWorkInformation userWorkInformation)
        {
            //int test = 0;
            try
            {
                using (var client = new HttpClient())
                using (var request = new HttpRequestMessage(HttpMethod.Post, String.Format("https://localhost:44394/Users")))
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
    }

}
