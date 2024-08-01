using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApplication.Dtos.Account
{
    public class UpdateUserDto
    {
        [Required]
        [EmailAddress]
        public string? Email { get; set; } = string.Empty;
        public string? PhoneNumber { get; set; } = string.Empty;
        [Required] 
        public string NewPassword { get; set; }
        [Required] 
        public string CurrentPassword { get; set; } 
    }
}