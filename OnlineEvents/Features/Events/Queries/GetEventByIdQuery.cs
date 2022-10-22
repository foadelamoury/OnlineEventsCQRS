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
    public class GetEventByIdQuery : IRequest<Event>
    {
        public int Id { get; set; }

        public class GetEventByIdQueryHandler : IRequestHandler<GetEventByIdQuery, Event>
        {
            private readonly IEventService _eventService;

            public GetEventByIdQueryHandler(IEventService eventService)
            {
                _eventService = eventService;
            }

            public async Task<Event> Handle(GetEventByIdQuery query, CancellationToken cancellationToken)
            {
                return await _eventService.GetEventById(query.Id);
            }
        }
    }
}
