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
    public class RosterManager
    {
        IRosterRestService restService;

        public RosterManager(IRosterRestService service)
        {
            restService = service;
        }

        public Task<List<Roster>> GetTasksAsync()
        {
            return restService.RefreshDataAsync();
        }

        public List<Roster> ReadLocalFile()
        {
            var assembly = typeof(RosterManager).GetTypeInfo().Assembly;
            Stream stream = assembly.GetManifestResourceStream(Constants.StaticRoster);
            string text = "";
            using (var reader = new System.IO.StreamReader(stream))
            {
                text = reader.ReadToEnd();
            }
            return JsonConvert.DeserializeObject<List<Roster>>(text);
        }
    }
}
