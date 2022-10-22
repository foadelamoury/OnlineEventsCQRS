using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnlineEvents.Models;
using OnlineEvents.Services;
using System.Threading;

namespace OnlineEvents.Features.PhotoAlbums.Commands
{
    public class DeletePhotoAlbumCommand : IRequest<int>
    {
        public int Id { get; set; }

        public class DeletePhotoAlbumCommandHandler : IRequestHandler<DeletePhotoAlbumCommand, int>
        {
            private readonly IPhotoAlbumService _photoAlbumService;

            public DeletePhotoAlbumCommandHandler(IPhotoAlbumService photoAlbumService)
            {
                _photoAlbumService = photoAlbumService;
            }

            public async Task<int> Handle(DeletePhotoAlbumCommand command, CancellationToken cancellationToken)
            {
                var _photoAlbum = await _photoAlbumService.GetPhotoAlbumById(command.Id);
                if (_photoAlbum == null)
                    return default;

                return await _photoAlbumService.DeletePhotoAlbum(_photoAlbum);
            }
        }
    }
}
