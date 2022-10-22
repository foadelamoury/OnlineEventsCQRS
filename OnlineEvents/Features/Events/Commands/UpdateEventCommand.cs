using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnlineEvents.Models;
using OnlineEvents.Services;
using MediatR;
using System.Threading;

namespace OnlineEvents.Features.Events.Commands
{
    public class UpdateEventCommand : IRequest<int>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ArabicTitle { get; set; }
        public string Content { get; set; }
        public string Address { get; set; }

        public class UpdateEventCommandHandler : IRequestHandler<UpdateEventCommand, int>
        {
            private readonly IEventService _eventService;

            public UpdateEventCommandHandler(IEventService eventService)
            {
                _eventService = eventService;
            }

            public async Task<int> Handle(UpdateEventCommand command, CancellationToken cancellationToken)
            {
                var _event = await _eventService.GetEventById(command.Id);
                if (_event == null)
                    return default;

                _event.Title = command.Title;
                _event.ArabicTitle = command.ArabicTitle;
                _event.Content = command.Content;
                _event.Address = command.Address;
              

                return await _eventService.UpdateEvent(_event);
            }
        }
    }
}
