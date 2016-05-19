using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HailStateTennis
{
	public interface IScheduleRestService
	{
		Task<List<ScheduleItem>> RefreshDataAsync ();

//		Task SaveTodoItemAsync (ScheduleItem item, bool isNewItem);

//		Task DeleteTodoItemAsync (string id);
//        Task DeleteTodoItemAsync(int id);
    }
}
