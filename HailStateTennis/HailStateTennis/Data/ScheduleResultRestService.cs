using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using System.IO;
using System.Net;

namespace HailStateTennis
{
    public class ScheduleResultRestService : IScheduleResultRestService
    {
        public ScheduleResult Item { get; private set; }
        public ScheduleResultRestService()
        {
        }
        public async Task<ScheduleResult> RefreshDataAsync(int id)
        {
            Item = new ScheduleResult();
            try
            {
                using (var request = new HttpRequestMessage(HttpMethod.Get, String.Format(Constants.ResultUrl, id)))
                {
                    string content = await (await App.HttpClientManager.Client.SendAsync(request)).Content.ReadAsStringAsync();
                    Item = JsonConvert.DeserializeObject<ScheduleResult>(content);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"				ERROR {0}", ex.Message);
            }
            return Item;
        }
    }
}
