using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HailStateTennis
{
    public interface IStandingRestService
    {
        Task<List<Standing>> RefreshDataAsync();
    }
}