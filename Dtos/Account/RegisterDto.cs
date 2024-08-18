using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApplication.Dtos.Account
{
    public class RegisterDto
    {
        [Required]
        public string? UserName { get; set; } = string.Empty;
        [Required]
        [EmailAddress]
        public string? Email { get; set; } = string.Empty;
        [Required]
        [Phone]
        public string? PhoneNumber { get; set; } = string.Empty;
        [Required] 
        [DataType(DataType.Password)]
        public string? Password { get; set; }  = string.Empty;
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [Compare("Password", ErrorMessage ="The password and confirm Password do not match.")]
        public string? ConfirmPassword { get; set; }
        [Required]
        public string Role { get; set; }
        
    }
}