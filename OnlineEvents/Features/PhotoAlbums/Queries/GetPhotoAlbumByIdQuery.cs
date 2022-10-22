using OnlineEvents.Models;
using OnlineEvents.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace OnlineEvents.Features.PhotoAlbums.Queries
{
    public class GetPhotoAlbumByIdQuery : IRequest<PhotoAlbum>
    {
        public int Id { get; set; }

        public class GetPhotoAlbumByIdQueryHandler : IRequestHandler<GetPhotoAlbumByIdQuery, PhotoAlbum>
        {
            private readonly IPhotoAlbumService _photoAlbumService;

            public GetPhotoAlbumByIdQueryHandler(IPhotoAlbumService photoAlbumService)
            {
                _photoAlbumService = photoAlbumService;
            }

            public async Task<PhotoAlbum> Handle(GetPhotoAlbumByIdQuery query, CancellationToken cancellationToken)
            {
                return await _photoAlbumService.GetPhotoAlbumById(query.Id);
            }
        }
    }
}
