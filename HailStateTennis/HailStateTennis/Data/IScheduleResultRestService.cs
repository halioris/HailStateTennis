using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HailStateTennis
{
    public interface IScheduleResultRestService
    {
        Task<ScheduleResult> RefreshDataAsync(int id);
    }
}
