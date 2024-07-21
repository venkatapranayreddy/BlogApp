using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogApplication.Dtos.Account;
using BlogApplication.Interfaces;
using BlogApplication.Models;
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

        private readonly SignInManager<AppUser> _signInManager;
        public AccountController(UserManager<AppUser> userManager, ITokenService itokenService, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _itokenService = itokenService;
            _signInManager = signInManager;

        }

        [HttpPost("Login")]
        public async  Task<IActionResult> Login([FromBody] LoginDto loginDto)
        {

                 if(!ModelState.IsValid) return BadRequest(ModelState);

                 var user = await _userManager.Users.FirstOrDefaultAsync(x => x.UserName == loginDto.userName.ToLower());

                 if(user == null) return Unauthorized("UserName or Password is Wrong");

                 var password = await _signInManager.CheckPasswordSignInAsync(user, loginDto.Password,false);
                 if(password == null) return Unauthorized("UserName or Password is Wrong");

            return Ok(
                new NewUserDto
                {
                    userName = user.UserName,
                    Email = user.Email,
                    token = _itokenService.createToken(user)
                }
            );


        }










        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
        {
           

            try
            {

                 if(!ModelState.IsValid) return BadRequest(ModelState);
            
                var user = new AppUser
                {
                    Email = registerDto.Email,
                    UserName = registerDto.UserName,
                    PhoneNumber = registerDto.PhoneNumber
                };

                var createdUser = await _userManager.CreateAsync(user, registerDto.Password);

                if (createdUser.Succeeded)
                {
                    var roleResult = await _userManager.AddToRoleAsync(user, "User");
                    if(roleResult.Succeeded)
                    {
                        return Ok(
                            new NewUserDto
                            {
                                userName = user.UserName,
                                Email = user.Email,
                                token = _itokenService.createToken(user),
                            }
                        );
                    }
                    else {
                        return  StatusCode(500, roleResult.Errors);
                    }
                }
                else {
                        return  StatusCode(500, createdUser.Errors);
                    }
            }
            catch (Exception e){
                return StatusCode(500, e);
            }
            
        }

         














        
    }
}