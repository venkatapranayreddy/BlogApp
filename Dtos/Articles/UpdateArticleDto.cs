using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApplication.Dtos.Articles
{
    public class UpdateArticleDto
    {
        [Required]
        [MaxLength(100, ErrorMessage = "Max Chars shouldn't more than 100")]
         public string Title { get; set; } = string.Empty;
        [Required]
        public string? Description { get; set; }  = string.Empty;
        [Required]
        [MaxLength(100, ErrorMessage = "Max Chars shouldn't more than 100")]
         public string? Category {get; set;}  = string.Empty;
    }
}