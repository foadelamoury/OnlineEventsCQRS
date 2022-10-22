using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineEvents.Models
{
    public class Source
    {
        public int Id { get; set; }
        [Required, MaxLength(50, ErrorMessage = "Title cannot exceed 50 characters"), MinLength(1, ErrorMessage = "Title cannot be less than 1 character")]
        public string Name { get; set; }
        [Required, MaxLength(300, ErrorMessage = "Content cannot exceed 300 characters")]
        public string Description { get; set; }
    }
}
