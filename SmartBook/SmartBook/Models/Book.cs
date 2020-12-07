using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SmartBook.Models
{
    public class Book
    {

        [Display(Name = "Book ID")]
        public int BookId { get; set; }

        [Display(Name = "Book Name")]
        [Required]
        [StringLength(100, ErrorMessage = "Book name must be under 100 characters.")]
        public string BookName { get; set; }

        [Required]
        [Display(Name = "Year of publish")]
        [Range(1920, 2020, ErrorMessage = "Book year of publish must be between 1920-2020.")]
        public int YearOfPublish { get; set; }

        [Required]
        [StringLength(2000, ErrorMessage = "Book summary must be under 2000 characters.")]
        public string Summary { get; set; }

        [Required]
        public int PictureId { get; set; }

        [Required]
        public string WriterName { get; set; }

        [Display(Name = "Number of pages")]
        [Required]
        public int Number_Of_Pages { get; set; }


        [Display(Name = "Book url")]
        [Required]
        public string BookUrl { get; set; }

        public virtual Picture Picture { get; set; }
        public virtual ICollection<Review> Review { get; set; }
       
    }
}