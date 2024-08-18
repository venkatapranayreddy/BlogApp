using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using BlogApplication.Dtos.Account;
using BlogApplication.Interfaces;
using BlogApplication.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlogApplication.Controllers
{
    [Route("api/account")]
    public class AccountController:ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly ITokenService _itokenService;
        private readonly IUserRepository _iuserRepository;
        private readonly SignInManager<AppUser> _signInManager;
        public AccountController(UserManager<AppUser> userManager, ITokenService itokenService, SignInManager<AppUser> signInManager,IUserRepository iuserRepository)
        {
            _userManager = userManager;
            _itokenService = itokenService;
            _signInManager = signInManager;
            _iuserRepository = iuserRepository;


        }

        [HttpPost("Login")]
        public async  Task<IActionResult> Login([FromBody] LoginDto loginDto)
        {

                 if(!ModelState.IsValid) return BadRequest(ModelState);

                 var user = await _userManager.Users.FirstOrDefaultAsync(x => x.UserName == loginDto.userName.ToLower());

                 if(user == null) return Unauthorized("UserName or Password is Wrong");

                 var password = await _signInManager.CheckPasswordSignInAsync(user, loginDto.Password, false);
                 if(!password.Succeeded) return Unauthorized("UserName or Password is Wrong");

            return Ok(
                new NewUserDto
                {
                    userName = user.UserName,
                    Email = user.Email,
                    token = _itokenService.createToken(user)
                }
            );


        }


        // [HttpPost("Register")] 
        // public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
        // {
           

        //     try
        //     {

        //          if(!ModelState.IsValid) return BadRequest(ModelState);
            
        //         var user = new AppUser
        //         {
        //             Email = registerDto.Email,
        //             UserName = registerDto.UserName,
        //             PhoneNumber = registerDto.PhoneNumber
        //         };

        //         var createdUser = await _userManager.CreateAsync(user, registerDto.Password);

        //         if (createdUser.Succeeded)
        //         {
        //             var roleResult = await _userManager.AddToRoleAsync(user, "User");
        //             if(roleResult.Succeeded)
        //             {
        //                 return Ok(
        //                     new NewUserDto
        //                     {
        //                         userName = user.UserName,
        //                         Email = user.Email,
        //                         token = _itokenService.createToken(user),
        //                     }
        //                 );
        //             }
        //             else {
        //                 return  StatusCode(500, roleResult.Errors);
        //             }
        //         }
        //         else {
        //                 return  StatusCode(500, createdUser.Errors);
        //             }
        //     }
        //     catch (Exception e){
        //         return StatusCode(500, e);
        //     }
            
        // }


        [HttpPost("Register")] 
         public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
             {
        try
        {
            if (!ModelState.IsValid) 
                return BadRequest(ModelState);

            var result = await _iuserRepository.RegisterAsync(registerDto);

            if (result.Success)
            {
                return Ok(result.UserDto);
            }
            else
            {
                return StatusCode(500, result.Errors);
            }
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
     }


      [HttpGet("{userName}")]
       [Authorize]
      public async Task<IActionResult> GetUserById(string userName)
    {
         if (userName == null)  return Unauthorized();
         var loggedInUserName = HttpContext.User?.Claims.FirstOrDefault(c => c.Type == ClaimTypes.GivenName)?.Value;


                     if (loggedInUserName == null)
                    {
                  var claims = HttpContext.User?.Claims;
                 
                    }

                 if (loggedInUserName != userName)
                     {
                    return Unauthorized("You are not authorized to update this user's details.");
                     }

        var user = await _userManager.FindByNameAsync(userName);

      
        var userInfo = new
        {
            user.UserName,
            user.Email,
            user.PhoneNumber
            
        };

        return Ok(userInfo);
    }

           [HttpPut("{userName}")]
           [Authorize]
           public async Task<IActionResult> UpdateUser(string userName, [FromBody] UpdateUserDto updateUserDto)
            {
                if(updateUserDto == null) return Unauthorized();
                     var loggedInUserName = HttpContext.User?.Claims.FirstOrDefault(c => c.Type == ClaimTypes.GivenName)?.Value;


                     if (loggedInUserName == null)
                    {
                  var claims = HttpContext.User?.Claims;
                 
                    }

                 if (loggedInUserName != userName)
                     {
                    return Unauthorized("You are not authorized to update this user's details.");
                     }

                 var user = await _userManager.FindByNameAsync(userName);
                 if (user == null)
                {
                     return NotFound($"User with username '{userName}' not found.");
                }

                if (!string.IsNullOrEmpty(updateUserDto.Email))
                    {
                    user.Email = updateUserDto.Email;
                 var emailResult = await _userManager.UpdateAsync(user);
                 if (!emailResult.Succeeded)
                    {
                     return BadRequest(emailResult.Errors);
                    }
                    }

                if(!string.IsNullOrEmpty(updateUserDto.PhoneNumber))
                {
                    user.PhoneNumber = updateUserDto.PhoneNumber;
                    var phoneResult = await _userManager.UpdateAsync(user);
                    if (!phoneResult.Succeeded) return BadRequest(phoneResult.Errors);
                }

                if(!string.IsNullOrEmpty(updateUserDto.NewPassword) && !string.IsNullOrEmpty(updateUserDto.CurrentPassword))
                {
                    var passwordResult = await _userManager.ChangePasswordAsync(user, updateUserDto.CurrentPassword, updateUserDto.NewPassword);
                    if (!passwordResult.Succeeded) return BadRequest(passwordResult.Errors);
                }
                 
                 return Ok("User information updated Sucessfully");
                
            }




        // [HttpGet]
        // [Authorize(Roles="Admin")]
        // public async Task<IActionResult> GetAllUser()
        // {
        //     var user = await _userManager.Users.ToListAsync();
        // return Ok(user);
        // }




    //  [HttpDelete("{userName}")]
    //  public async Task<IActionResult> DeleteUsers()
    //  {
    //     return Ok(Users);
    //  }
      












        
    }

   
    
}