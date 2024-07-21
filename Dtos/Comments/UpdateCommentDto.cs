using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApplication.Dtos.Comments
{
    public class UpdateCommentDto
    {
        [Required]
        [MinLength(5, ErrorMessage = "Content should at least 5chars")]
        [MaxLength(180, ErrorMessage = "Max Chars shouldn't more than 180")]
        public string Content { get; set; } = string.Empty;
    }
}