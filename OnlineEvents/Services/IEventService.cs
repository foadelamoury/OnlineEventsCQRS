using OnlineEvents.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineEvents.Services
{
    public interface IEventService
    {
        Task<IEnumerable<Event>> GetEventsList();
        Task<Event> GetEventById(int id);
        Task<Event> CreateEvent(Event _event);
        Task<int> UpdateEvent(Event _event);
        Task<int> DeleteEvent(Event _event);
    }
}
