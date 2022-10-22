using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineEvents.Models
{
    public class Image
    {
        public int Id { get; set; }
        [Required]
        public string ImagePath { get; set; }

        public int PhotoAlbumId { get; set; }
        public PhotoAlbum PhotoAlbum { get; set; }

    }
}
