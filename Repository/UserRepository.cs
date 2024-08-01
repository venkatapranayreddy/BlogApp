using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogApplication.Dtos.Account;
using BlogApplication.Interfaces;
using BlogApplication.Models;
using BlogApplication.ReturnTypes;
using Microsoft.AspNetCore.Identity;

namespace BlogApplication.Repository
{
    public class UserRepository : IUserRepository
    {
         private readonly UserManager<AppUser> _userManager;
        private readonly ITokenService _tokenService;
         private readonly RoleManager<IdentityRole> _roleManager;

        public UserRepository(UserManager<AppUser> userManager, ITokenService tokenService, RoleManager<IdentityRole> roleManager)
            {
        _userManager = userManager;
        _tokenService = tokenService;
        _roleManager = roleManager;

         }

        public async Task<bool> CanEditUserAsync(AppUser user, string userId)
        {
            if (await IsAdminAsync(user))
        {
            return true;
        }

        
        return user.Id == userId;
        }

        public async Task<AppUser> GetUserByIdAsync(string userId)
        {
           return await _userManager.FindByIdAsync(userId);
        }

        public async Task<bool> IsAdminAsync(AppUser user)
        {
             return await _userManager.IsInRoleAsync(user, "Admin");
        }

        public async Task<RegisterResult> RegisterAsync(RegisterDto registerDto)
        {
             if (registerDto == null) 
            throw new ArgumentNullException(nameof(registerDto));

        var user = new AppUser
        {
            Email = registerDto.Email,
            UserName = registerDto.UserName,
            PhoneNumber = registerDto.PhoneNumber
        };
            var roleExists = await _roleManager.RoleExistsAsync(registerDto.Role);

            if (!roleExists)
            {
                return new RegisterResult
                {
                    Success = false,
                    UserDto = null,
                    Errors = new[] { new IdentityError { Description = $"Role {registerDto.Role} does not exist" } }
                };
                
            }

        var createdUser = await _userManager.CreateAsync(user, registerDto.Password);

        if (createdUser.Succeeded)
        {
              var roleResult = await _userManager.AddToRoleAsync(user, registerDto.Role);

            if (roleResult.Succeeded)
            {
                return new RegisterResult
                {
                    Success = true,
                    UserDto = new NewUserDto
                    {
                        userName = user.UserName,
                        Email = user.Email,
                        token = _tokenService.createToken(user)
                    },
                    Errors = null
                };
            }
            else
            {
                
                return new RegisterResult
                {
                    Success = false,
                    UserDto = null,
                    Errors = roleResult.Errors
                };
            }
        }
        else
        {
            return new RegisterResult
            {
                Success = false,
                UserDto = null,
                Errors = createdUser.Errors
            };
        }
    }
    }
}