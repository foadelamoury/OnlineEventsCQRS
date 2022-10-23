using OnlineEvents.Models;
using OnlineEvents.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace OnlineEvents.Features.PhotoAlbums.Commands

{
    public class CreatePhotoAlbumCommand : IRequest<PhotoAlbum>
    {

        public string Title { get; set; }
        public int Id { get; set; }

        public class CreatePhotoAlbumCommandHandler : IRequestHandler<CreatePhotoAlbumCommand, PhotoAlbum>
        {
            private readonly IPhotoAlbumService _photoAlbumService;

            public CreatePhotoAlbumCommandHandler(IPhotoAlbumService photoAlbumService)
            {
                _photoAlbumService = photoAlbumService;
            }

            public async Task<PhotoAlbum> Handle(CreatePhotoAlbumCommand command, CancellationToken cancellationToken)
            {

                var _photo = new PhotoAlbum()
                {
                    Title = command.Title,
                    Id = command.Id
            };

                return await _photoAlbumService.CreatePhotoAlbum(_photo);
            }
        }
    }

}
