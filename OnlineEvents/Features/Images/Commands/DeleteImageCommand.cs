using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnlineEvents.Models;
using OnlineEvents.Services;
using System.Threading;

namespace OnlineEvents.Features.Images.Commands
{
    public class DeleteImageCommand : IRequest<int>
    {
        public int Id { get; set; }

        public class DeleteImageCommandHandler : IRequestHandler<DeleteImageCommand, int>
        {
            private readonly IImageService _photoAlbumService;

            public DeleteImageCommandHandler(IImageService photoAlbumService)
            {
                _photoAlbumService = photoAlbumService;
            }

            public async Task<int> Handle(DeleteImageCommand command, CancellationToken cancellationToken)
            {
                var _photoAlbum = await _photoAlbumService.GetImageById(command.Id);
                if (_photoAlbum == null)
                    return default;

                return await _photoAlbumService.DeleteImage(_photoAlbum);
            }
        }
    }
}
