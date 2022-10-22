using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineEvents.Models
{
    public class Event
    {
       
        public int Id { get; set; }
        [Required, MaxLength(50, ErrorMessage = "Title cannot exceed 50 characters"), MinLength(1, ErrorMessage = "Title cannot be less than 1 character")]
        public string Title { get; set; }

        [Required, MaxLength(50, ErrorMessage = "Title cannot exceed 50 characters"), MinLength(1, ErrorMessage = "Title cannot be less than 1 character")]
        public string ArabicTitle { get; set; }
        [Required, MaxLength(300, ErrorMessage = "Content cannot exceed 300 characters")]
        public string Content { get; set; }
        [Required, MaxLength(50, ErrorMessage = "Content cannot exceed 300 characters")]
        public string Address { get; set; }
        [Required]

        public string CoverPhotoPath { get; set; }


        [Display(Name = "Start Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Required]
        public DateTime StartDate { get; set; }

        [Display(Name = "End Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Required]
        public DateTime EndDate { get; set; }


        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public int PhotoAlbumId { get; set; }
        public PhotoAlbum PhotoAlbum { get; set; }

        public int SourceId { get; set; }
        public Source Source { get; set; }
        #region you can borrow from this [inside this]
        //[Required]
        //[RegularExpression(@"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$",
        //ErrorMessage = "Invalid email format")]
        //[Display(Name = "Office Email")]
        //public string Email { get; set; }
        #endregion
    }
}
