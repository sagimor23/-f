using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SmartBook.Models
{
    public class Comment
    {
        [Display(Name = "Review ID")]
        public int CommentId { get; set; }

        [Required]
        [Display(Name = "User Name")]
        public string UserName { get; set; }

        [Required]
        [Display(Name = "Comment")]
        [StringLength(400, ErrorMessage = "Comment cannot be more than 400 characters.")]
        public string CommentText { get; set; }

        [Required]
        [Display(Name = "Review Date")]
        [DataType(DataType.DateTime, ErrorMessage = "This field must be a valid DateTime")]
        public DateTime CommentDate { get; set; }

    }
}