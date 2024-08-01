using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace BlogApplication.Models
{
    public class Roles :IdentityRole
    {
        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}