using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HailStateTennis
{
    public interface IRosterRestService
    {
        Task<List<Roster>> RefreshDataAsync();
    }
}
