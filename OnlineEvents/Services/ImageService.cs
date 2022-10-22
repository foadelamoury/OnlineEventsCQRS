using Microsoft.EntityFrameworkCore;
using OnlineEvents.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineEvents.Services
{
    public class ImageService : IImageService
    {
        private readonly Data.OnlineEventsDbContext _context;

        public ImageService(Data.OnlineEventsDbContext context)
        {
            _context = context;

        }

        public async Task<Image> CreateImage(Image image)
        {
            
            _context.Image.Add(image);
            await _context.SaveChangesAsync();
            return image;
        }

        public async Task<int> DeleteImage(Image image)
        {
            _context.Image.Remove(image);
            return await _context.SaveChangesAsync();
        }

    
        public async Task<Image> GetImageById(int id)
        {

            return await _context.Image
               .FirstOrDefaultAsync(x => x.Id == id);
        }

      
      
    }
}
