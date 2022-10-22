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
    public class GetAllPhotoAlbumsQuery : IRequest<IEnumerable<PhotoAlbum>>
    {
        public class GetAllPhotoAlbumsQueryHandler : IRequestHandler<GetAllPhotoAlbumsQuery, IEnumerable<PhotoAlbum>>
        {
            private readonly IPhotoAlbumService _photoAlbumService;

            public GetAllPhotoAlbumsQueryHandler(IPhotoAlbumService photoAlbumService)
            {
                _photoAlbumService = photoAlbumService;
            }

            public async Task<IEnumerable<PhotoAlbum>> Handle(GetAllPhotoAlbumsQuery query, CancellationToken cancellationToken)
            {
                return await _photoAlbumService.GetPhotoAlbumsList();
            }
        }
    }
}


