using OnlineEvents.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineEvents.Services
{
    public interface IPhotoAlbumService
    {
        Task<IEnumerable<PhotoAlbum>> GetPhotoAlbumsList();
        Task<PhotoAlbum> GetPhotoAlbumById(int id);
        Task<PhotoAlbum> CreatePhotoAlbum(PhotoAlbum photoAlbum);
        Task<int> UpdatePhotoAlbum(PhotoAlbum photoAlbum);
        Task<int> DeletePhotoAlbum(PhotoAlbum photoAlbum);
      

    }
}
