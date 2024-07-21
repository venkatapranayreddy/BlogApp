using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogApplication.Dtos.Comments;

namespace BlogApplication.Dtos.Articles
{
    public class ArticlesDto
    {
        public int Id { get; set;}
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }  = string.Empty;
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public string? CreatedBy { get; set; } = string.Empty;
        public string? Category {get; set;}  = string.Empty;
        public string? FilePath {get; set; } 
        public List<CommentsDto> Comments { get; set; } = new List<CommentsDto>();
        
    }
}