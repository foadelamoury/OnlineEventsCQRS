using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnlineEvents.Models;
using OnlineEvents.Services;
using System.Threading;

namespace OnlineEvents.Features.Events.Commands
{
    public class DeleteEventCommand : IRequest<int>
    {
        public int Id { get; set; }

        public class DeleteEventCommandHandler : IRequestHandler<DeleteEventCommand, int>
        {
            private readonly IEventService _eventService;

            public DeleteEventCommandHandler(IEventService eventService)
            {
                _eventService = eventService;
            }

            public async Task<int> Handle(DeleteEventCommand command, CancellationToken cancellationToken)
            {
                var _event = await _eventService.GetEventById(command.Id);
                if (_event == null)
                    return default;

                return await _eventService.DeleteEvent(_event);
            }
        }
    }
}
