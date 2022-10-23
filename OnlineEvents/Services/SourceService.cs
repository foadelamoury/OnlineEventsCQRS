using Microsoft.EntityFrameworkCore;
using OnlineEvents.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineEvents.Services
{
    public class SourceService : ISourceService
    {
        private readonly Data.OnlineEventsDbContext _context;

        public SourceService(Data.OnlineEventsDbContext context)
        {
            _context = context;

        }

        public async Task<Source> CreateSource(Source source)
        {
            
            _context.Sources.Add(source);
            await _context.SaveChangesAsync();
            return source;
        }

        public async Task<int> DeleteSource(Source source)
        {
            _context.Sources.Remove(source);
            return await _context.SaveChangesAsync();
        }

    
        public async Task<Source> GetSourceById(int id)
        {

            return await _context.Sources
               .FirstOrDefaultAsync(x => x.Id == id);
        }

      
      
    }
}
