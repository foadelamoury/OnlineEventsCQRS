using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnlineEvents.Models;
using OnlineEvents.Services;
using MediatR;
using System.Threading;


namespace OnlineEvents.Features.PhotoAlbums.Commands
{
    public class UpdatePhotoAlbumCommand : IRequest<int>
    {
        public int Id { get; set; }
        public string Title { get; set; }
       

        public class UpdatePhotoAlbumCommandHandler : IRequestHandler<UpdatePhotoAlbumCommand, int>
        {
            private readonly IPhotoAlbumService _photoAlbumService;

            public UpdatePhotoAlbumCommandHandler(IPhotoAlbumService photoAlbumService)
            {
                _photoAlbumService = photoAlbumService;
            }

            public async Task<int> Handle(UpdatePhotoAlbumCommand command, CancellationToken cancellationToken)
            {
                var _photoAlbum = await _photoAlbumService.GetPhotoAlbumById(command.Id);
                if (_photoAlbum == null)
                    return default;

                _photoAlbum.Title = command.Title;
               
              

                return await _photoAlbumService.UpdatePhotoAlbum(_photoAlbum);
            }
        }
    }
}
