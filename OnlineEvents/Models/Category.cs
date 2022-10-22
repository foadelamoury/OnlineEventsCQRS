using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineEvents.Models
{
    public class Category
    {

        public int Id { get; set; }
        [Required, MaxLength(30, ErrorMessage = "Title cannot exceed 30 characters"), MinLength(5, ErrorMessage = "Title cannot be less than 5 characters")]
        public string Name { get; set; }
        [Required, MaxLength(300, ErrorMessage = "Content cannot exceed 300 characters")]
        public string Description { get; set; }

        public ICollection<Event> Events { get; set; }


    }
}
