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
    public class ScheduleItemManager
    {
        IScheduleRestService restService;

        public ScheduleItemManager(IScheduleRestService service)
        {
            restService = service;
        }

        public Task<List<ScheduleItem>> GetTasksAsync()
        {
            return restService.RefreshDataAsync();
        }

        public Task<List<ScheduleItem>> ReadLocalFile()
        {
            var assembly = typeof(ScheduleItemManager).GetTypeInfo().Assembly;
            Stream stream = assembly.GetManifestResourceStream(Constants.StaticSchedule);
            string text = "";
            using (var reader = new System.IO.StreamReader(stream))
            {
                //                text = await Task.Run(() => reader.ReadToEnd());
                text = reader.ReadToEnd();
            }
            return Task.FromResult<List<ScheduleItem>>(JsonConvert.DeserializeObject<List<ScheduleItem>>(text));
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
