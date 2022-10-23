using OnlineEvents.Models;
using OnlineEvents.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace OnlineEvents.Features.Images.Queries
{
    public class GetSourceByIdQuery : IRequest<Image>
    {
        public int Id { get; set; }

        public class GetImageByIdQueryHandler : IRequestHandler<GetSourceByIdQuery, Image>
        {
            private readonly IImageService _imageService;

            public GetImageByIdQueryHandler(IImageService imageService)
            {
                _imageService = imageService;
            }

            public async Task<Image> Handle(GetSourceByIdQuery query, CancellationToken cancellationToken)
            {
                return await _imageService.GetImageById(query.Id);
            }
        }
    }
}
