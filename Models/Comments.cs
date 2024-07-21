using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApplication.Models
{
    public class Comments
    {
        public int? Id { get; set; }
        public string Content { get; set; } = string.Empty;
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public int? ArticleId { get; set; }
        public Articles?  Article { get; set; }
        public string? AppUserId {get; set;}
        public AppUser? appUser {get; set;}

        
    }
}