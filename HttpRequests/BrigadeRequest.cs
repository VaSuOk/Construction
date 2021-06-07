using Construction.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace Construction.HttpRequests
{
    class BrigadeRequest
    {
        #region PUT
        public static async System.Threading.Tasks.Task CreateBrigade(Brigade brigade)
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
            }
            catch
            {
                //!!!!!!
            }
        }
        #endregion
    }
}
