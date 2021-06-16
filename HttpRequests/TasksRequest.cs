using Construction.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace Construction.HttpRequests
{
    class TasksRequest
    {
        #region PUT
        public static async System.Threading.Tasks.Task CreateTasks(TaskArchitect  taskArchitect)
        {
            try
            {
                using (var client = new HttpClient())
                using (var request = new HttpRequestMessage(HttpMethod.Put, String.Format("https://localhost:44394/ArchitectTask/{0}", taskArchitect.ID)))
                {
                    var json = JsonConvert.SerializeObject(taskArchitect);
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
