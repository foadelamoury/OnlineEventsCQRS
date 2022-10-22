using OnlineEvents.Models;
using OnlineEvents.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace OnlineEvents.Features.Events.Queries
{
    public class GetAllEventsQuery : IRequest<IEnumerable<Event>>
    {
        public class GetAllEventsQueryHandler : IRequestHandler<GetAllEventsQuery, IEnumerable<Event>>
        {
            private readonly IEventService _eventService;

            public GetAllEventsQueryHandler(IEventService eventService)
            {
                _eventService = eventService;
            }

            public async Task<IEnumerable<Event>> Handle(GetAllEventsQuery query, CancellationToken cancellationToken)
            {
                return await _eventService.GetEventsList();
            }
        }
    }
}
