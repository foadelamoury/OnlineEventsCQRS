using Microsoft.EntityFrameworkCore;
using OnlineEvents.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineEvents.Services
{
    public class PhotoAlbumService : IPhotoAlbumService
    {
        private readonly Data.OnlineEventsDbContext _context;

        public PhotoAlbumService(Data.OnlineEventsDbContext context)
        {
            _context = context;

        }

        public async Task<PhotoAlbum> CreatePhotoAlbum(PhotoAlbum photoAlbum)
        {
            _context.PhotoAlbum.Add(photoAlbum);
            await _context.SaveChangesAsync();
            return photoAlbum;
        }

        public async Task<int> DeletePhotoAlbum(PhotoAlbum photoAlbum)
        {
            _context.PhotoAlbum.Remove(photoAlbum);
            return await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<PhotoAlbum>> GetPhotoAlbumsList()
        {
            return await _context.PhotoAlbum.ToListAsync();
        }

        public async Task<PhotoAlbum> GetPhotoAlbumById(int id)
        {

            _context.PhotoAlbum.Include(x => x.Images).ToList();
            
            return await _context.PhotoAlbum
               .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<int> UpdatePhotoAlbum(PhotoAlbum photoAlbum)
        {
            _context.PhotoAlbum.Update(photoAlbum);
            return await _context.SaveChangesAsync();
        }
      
    }
}
