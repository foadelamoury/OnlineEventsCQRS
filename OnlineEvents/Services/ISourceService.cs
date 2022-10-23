using OnlineEvents.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineEvents.Services
{
    public interface ISourceService
    {
        Task<Source> GetSourceById(int id);
        Task<Source> CreateSource(Source source);

        Task<int> DeleteSource(Source source);
      

    }
}
