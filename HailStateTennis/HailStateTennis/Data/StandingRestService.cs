using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;
using System.Net;

namespace HailStateTennis
{
    public class StandingRestService : IStandingRestService
    {
        public List<Standing> Items { get; private set; }

        public StandingRestService()
        {
        }

        public async Task<List<Standing>> RefreshDataAsync()
        {
            Items = new List<Standing>();
            try
            {
                using (var request = new HttpRequestMessage(HttpMethod.Get, Constants.StandingUrl))
                {
//                    string content = await (await client.SendAsync(request)).Content.ReadAsStringAsync();
                    string content = await (await App.HttpClientManager.Client.SendAsync(request)).Content.ReadAsStringAsync();
                    Items = JsonConvert.DeserializeObject<List<Standing>>(content);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"				ERROR {0}", ex.Message);
            }
            return Items;
        }
    }
}
