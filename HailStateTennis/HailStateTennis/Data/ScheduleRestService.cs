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
    public class ScheduleRestService : IScheduleRestService
	{
		public List<ScheduleItem> Items { get; private set; }

		public ScheduleRestService ()
		{
        }

        public async Task<List<ScheduleItem>> RefreshDataAsync ()
		{
			Items = new List<ScheduleItem> ();
            try
            {
                using (var request = new HttpRequestMessage(HttpMethod.Get, Constants.ScheduleUrl))
                {
//                    string content = await (await client.SendAsync(request)).Content.ReadAsStringAsync();
                    string content = await (await App.HttpClientManager.Client.SendAsync(request)).Content.ReadAsStringAsync();
                    Items = JsonConvert.DeserializeObject<List<ScheduleItem>>(content);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"				ERROR {0}", ex.Message);
            }

            // Below section is for retrieving viw a REST web service
            //var uri = new Uri(string.Format(Constants.RestUrl, string.Empty));
            //try
            //{
            //    //var response = await client.GetAsync(uri);
            //    HttpResponseMessage response = await client.GetAsync(Constants.RestUrl);
            //    if (response.IsSuccessStatusCode)
            //    {
            //        var content = await response.Content.ReadAsStringAsync();
            //        Items = JsonConvert.DeserializeObject<List<ScheduleItem>>(content);
            //    }
            //}
            //catch (Exception ex)
            //{
            //    Debug.WriteLine(@"				ERROR {0}", ex.Message);
            //}

            return Items;
		}

		//public async Task SaveTodoItemAsync (ScheduleItem item, bool isNewItem = false)
		//{
  //          if (staticData)
  //          {

  //          }
  //          else
  //          {
  //              // RestUrl = http://developer.xamarin.com:8081/api/todoitems{0}
  //              var uri = new Uri(string.Format(Constants.RestUrl, item.ID));

  //              try
  //              {
  //                  var json = JsonConvert.SerializeObject(item);
  //                  var content = new StringContent(json, Encoding.UTF8, "application/json");

  //                  HttpResponseMessage response = null;
  //                  if (isNewItem)
  //                  {
  //                      response = await client.PostAsync(uri, content);
  //                  }
  //                  else {
  //                      response = await client.PutAsync(uri, content);
  //                  }

  //                  if (response.IsSuccessStatusCode)
  //                  {
  //                      Debug.WriteLine(@"				TodoItem successfully saved.");
  //                  }

  //              }
  //              catch (Exception ex)
  //              {
  //                  Debug.WriteLine(@"				ERROR {0}", ex.Message);
  //              }
  //          }
		//}

//        public async Task DeleteTodoItemAsync(string id)
  //      public async Task DeleteTodoItemAsync (int id)
		//{
  //          if (staticData)
  //          {

  //          }
  //          else
  //          {
  //              // RestUrl = http://developer.xamarin.com:8081/api/todoitems{0}
  //              var uri = new Uri(string.Format(Constants.RestUrl, id));

  //              try
  //              {
  //                  var response = await client.DeleteAsync(uri);

  //                  if (response.IsSuccessStatusCode)
  //                  {
  //                      Debug.WriteLine(@"				TodoItem successfully deleted.");
  //                  }

  //              }
  //              catch (Exception ex)
  //              {
  //                  Debug.WriteLine(@"				ERROR {0}", ex.Message);
  //              }
  //          }
		//}
	}
}
