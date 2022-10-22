using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineEvents.Models
{
    public class PhotoAlbum
    {
        public int Id { get; set; }
        [Required, MaxLength(50, ErrorMessage = "Title cannot exceed 50 characters"), MinLength(1, ErrorMessage = "Title cannot be less than 1 characters")]
        public string Title { get; set; }

        public ICollection<Image> Images { get; set; }

        public Event Event { get; set; }
    }
}
