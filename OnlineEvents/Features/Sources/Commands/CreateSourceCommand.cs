using OnlineEvents.Models;
using OnlineEvents.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace OnlineEvents.Features.Sources.Commands

{
    public class CreateSourceCommand : IRequest<Source>
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }

        public class CreateSourceCommandHandler : IRequestHandler<CreateSourceCommand, Source>
        {
            private readonly ISourceService _imageService;

            public CreateSourceCommandHandler(ISourceService imageService)
            {
                _imageService = imageService;
            }

            public async Task<Source> Handle(CreateSourceCommand command, CancellationToken cancellationToken)
            {

            var _source = new Source()
                {
                Id = command.Id,
                Name = command.Name,
                Description = command.Description


            };

                return await _imageService.CreateSource(_source);
            }
        }
    }

}
