using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace BlogApplication.Models
{
    public class AppUser : IdentityUser
    {
        public DateTime DateTimme { get; set; } = DateTime.Now;


        // public List<Articles> Articles { get; set; } = new List<Articles>();
    }
}