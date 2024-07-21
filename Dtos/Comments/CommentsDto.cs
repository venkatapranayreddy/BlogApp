using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApplication.Dtos.Comments
{
    public class CommentsDto
    {
          public int? Id { get; set; }
        public string Content { get; set; } = string.Empty;
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public int? ArticleId { get; set; }
        public string createdBy {get; set;} = string.Empty;
        

    }
}