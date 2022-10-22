using OnlineEvents.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineEvents.Services
{
    public interface IImageService
    {
        Task<Image> GetImageById(int id);
        Task<Image> CreateImage(Image photoAlbum);
        Task<int> DeleteImage(Image photoAlbum);
      

    }
}
