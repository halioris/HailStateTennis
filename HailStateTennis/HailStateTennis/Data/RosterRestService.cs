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
using System.Reflection;

namespace HailStateTennis
{
    public class RosterRestService : IRosterRestService
    {
        public List<Roster> Items { get; private set; }

        public RosterRestService()
        {
        }

        public async Task<List<Roster>> RefreshDataAsync()
        {
            Items = new List<Roster>();
            try
            {
                using (var request = new HttpRequestMessage(HttpMethod.Get, Constants.ScheduleUrl))
                {
                    string content = await (await App.HttpClientManager.Client.SendAsync(request)).Content.ReadAsStringAsync();
                    Items = JsonConvert.DeserializeObject<List<Roster>>(content);
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
