using OnlineEvents.Data;
using OnlineEvents.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using Microsoft.AspNetCore.Http;

namespace OnlineEvents.Services
{
    public class EventService : IEventService
    {
        private readonly Data.OnlineEventsDbContext _context;


        public EventService(Data.OnlineEventsDbContext context)
        {
            _context = context;

        }

        public async Task<IEnumerable<Event>> GetEventsList()
        {
            _context.OnlineEvents.Include(x => x.Category).ToList();
            return await _context.OnlineEvents.ToListAsync();
        }

        public async Task<Event> GetEventById(int id)
        {
            _context.OnlineEvents.Include(x => x.Category).ToList();
            _context.OnlineEvents.Include(x => x.Source).ToList();
            _context.OnlineEvents.Include(x => x.PhotoAlbum).ToList();
            return await _context.OnlineEvents
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Event> CreateEvent(Event _event)
        {
            _context.OnlineEvents.Include(x => x.Category).ToList();
            _context.OnlineEvents.Add(_event);
            await _context.SaveChangesAsync();
            return _event;
        }

        public async Task<int> UpdateEvent(Event _event)
        {
            _context.OnlineEvents.Update(_event);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> DeleteEvent(Event _event)
        {
            _context.OnlineEvents.Remove(_event);
            return await _context.SaveChangesAsync();
        }

      
    }
}
