using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApplication.Models
{
    public class Articles
    {
        public int Id { get; set;}
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; }  = string.Empty;
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public string? Category {get; set;}  = string.Empty;
        public string? FilePath {get; set; } 
         public string? AppUserId {get; set;}
        public AppUser? appUser {get; set;}
        public List<Comments> Comments { get; set; } = new List<Comments>();

        
    }
}