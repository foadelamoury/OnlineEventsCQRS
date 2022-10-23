using OnlineEvents.Models;
using OnlineEvents.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace OnlineEvents.Features.Events.Commands

{
    public class CreateEventCommand : IRequest<Event>
    {
        public string Title { get; set; }
        public string ArabicTitle { get; set; }
        public string Content { get; set; }
        public string Address { get; set; }

        public DateTime StartDate { get; set; }

  
        public DateTime EndDate { get; set; }
        public string CoverPhotoPath { get; set; }


        public int CategoryId { get; set; }
        public int PhotoAlbumId { get; set; }

        public int SourceId { get; set; }

   


        public class CreateEventCommandHandler : IRequestHandler<CreateEventCommand, Event>
        {
            private readonly IEventService _eventService;

            public CreateEventCommandHandler(IEventService eventService)
            {
                _eventService = eventService;
            }

            public async Task<Event> Handle(CreateEventCommand command, CancellationToken cancellationToken)
            {

                var _event = new Event()
                {
                    Title = command.Title,
                    ArabicTitle = command.ArabicTitle,
                    Content = command.Content,
                    Address = command.Address,
                    StartDate = command.StartDate,
                    EndDate = command.EndDate,
                    CoverPhotoPath = command.CoverPhotoPath,
                    CategoryId = command.CategoryId,
                    PhotoAlbumId = 5,
                    SourceId = command.SourceId
                    


                };

                return await _eventService.CreateEvent(_event);
            }
        }
    }

}
