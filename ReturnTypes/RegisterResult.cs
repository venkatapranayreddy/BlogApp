using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogApplication.Dtos.Account;
using Microsoft.AspNetCore.Identity;

namespace BlogApplication.ReturnTypes
{
    public class RegisterResult
    {
    public bool Success { get; set; }
    public NewUserDto UserDto { get; set; }
    public IEnumerable<IdentityError> Errors { get; set; }
    }
}