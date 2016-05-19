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
    public class NewsRestService : INewsRestService
    {
        public List<NewsItem> Items { get; private set; }

        public NewsRestService()
        {
        }

        public async Task<List<NewsItem>> RefreshDataAsync()
        {
            Items = new List<NewsItem>();
            try
            {
                using (var request = new HttpRequestMessage(HttpMethod.Get, Constants.NewsUrl))
                {
                    string content = await (await App.HttpClientManager.Client.SendAsync(request)).Content.ReadAsStringAsync();
                    Items = JsonConvert.DeserializeObject<List<NewsItem>>(content);
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
