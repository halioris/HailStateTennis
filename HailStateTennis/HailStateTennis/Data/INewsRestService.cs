using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HailStateTennis
{
    public interface INewsRestService
    {
        Task<List<NewsItem>> RefreshDataAsync();

    }
}
