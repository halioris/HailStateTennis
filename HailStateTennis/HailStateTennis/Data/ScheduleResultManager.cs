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
    public class ScheduleResultManager
    {
        IScheduleResultRestService restService;

        public ScheduleResultManager(IScheduleResultRestService service)
        {
            restService = service;
        }

        public Task<ScheduleResult> GetTasksAsync(int id)
        {
            return restService.RefreshDataAsync(id);
        }

        public ScheduleResult ReadLocalFile(int id)
        {
            var assembly = typeof(ScheduleResultManager).GetTypeInfo().Assembly;
            string file = String.Format(Constants.StaticResult, id);
            Stream stream = assembly.GetManifestResourceStream(file);
            if (stream == null)
                return null;
            else
            {
                string text = "";
                using (var reader = new System.IO.StreamReader(stream))
                {
                    text = reader.ReadToEnd();
                }
                return JsonConvert.DeserializeObject<ScheduleResult>(text);
            }
        }

        //public Task SaveTaskAsync(ScheduleItem item, bool isNewItem = false)
        //{
        //    return restService.SaveTodoItemAsync(item, isNewItem);
        //}

        //public Task DeleteTaskAsync(ScheduleItem item)
        //{
        //    return restService.DeleteTodoItemAsync(item.ID);
        //}
    }
}
