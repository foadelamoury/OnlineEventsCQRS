using OnlineEvents.Models;
using OnlineEvents.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace OnlineEvents.Features.Images.Commands

{
    public class CreateImageCommand : IRequest<Image>
    {
      
        public string ImagePath { get; set; }

        public int PhotoAlbumId { get; set; }

        public class CreateImageCommandHandler : IRequestHandler<CreateImageCommand, Image>
        {
            private readonly IImageService _imageService;

            public CreateImageCommandHandler(IImageService imageService)
            {
                _imageService = imageService;
            }

            public async Task<Image> Handle(CreateImageCommand command, CancellationToken cancellationToken)
            {

            var _image = new Image()
                {
                ImagePath = command.ImagePath,
                PhotoAlbumId = command.PhotoAlbumId


            };

                return await _imageService.CreateImage(_image);
            }
        }
    }

}
