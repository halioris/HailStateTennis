using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Reflection;
using System.IO;

namespace HailStateTennis
{
    public class NewsManager
    {
        INewsRestService restService;

        public NewsManager(INewsRestService service)
        {
            restService = service;
        }

        public Task<List<NewsItem>> GetTasksAsync()
        {
            return restService.RefreshDataAsync();
        }

        public List<NewsItem> ReadLocalFile()
        {
            var assembly = typeof(NewsManager).GetTypeInfo().Assembly;
            Stream stream = assembly.GetManifestResourceStream(Constants.StaticNews);
            if (stream == null)
                return null;
            else
            {
                string text = "";
                using (var reader = new System.IO.StreamReader(stream))
                {
                    text = reader.ReadToEnd();
                }
                return JsonConvert.DeserializeObject<List<NewsItem>>(text);
            }
        }
    }
}
