using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.IO;
using Newtonsoft.Json;

namespace HailStateTennis
{
    public class StandingManager
    {
        IStandingRestService restService;

        public StandingManager(IStandingRestService service)
        {
            restService = service;
        }

        public Task<List<Standing>> GetTasksAsync()
        {
            return restService.RefreshDataAsync();
        }
        public List<Standing> ReadLocalFile()
        {
            var assembly = typeof(StandingManager).GetTypeInfo().Assembly;
            Stream stream = assembly.GetManifestResourceStream(Constants.StaticStanding);
            string text = "";
            using (var reader = new System.IO.StreamReader(stream))
            {
                text = reader.ReadToEnd();
            }
            return JsonConvert.DeserializeObject<List<Standing>>(text);
        }

    }
}
