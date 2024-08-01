using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogApplication.Dtos.Account;
using BlogApplication.Models;
using BlogApplication.ReturnTypes;

namespace BlogApplication.Interfaces
{
    public interface IUserRepository
    {
        Task<RegisterResult> RegisterAsync(RegisterDto registerDto);

        Task<bool> IsAdminAsync(AppUser user);

        Task<AppUser> GetUserByIdAsync(string userId);

        Task<bool> CanEditUserAsync(AppUser user, string userId);
    }
}