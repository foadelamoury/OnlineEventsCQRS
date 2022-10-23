using OnlineEvents.Models;
using OnlineEvents.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace OnlineEvents.Features.Sources.Queries
{
    public class GetSourceByIdQuery : IRequest<Source>
    {
        public int Id { get; set; }

        public class GetSourceByIdQueryHandler : IRequestHandler<GetSourceByIdQuery, Source>
        {
            private readonly ISourceService _sourceService;

            public GetSourceByIdQueryHandler(ISourceService sourceService)
            {
                _sourceService = sourceService;
            }

            public async Task<Source> Handle(GetSourceByIdQuery query, CancellationToken cancellationToken)
            {
                return await _sourceService.GetSourceById(query.Id);
            }
        }
    }
}
