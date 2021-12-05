using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OngProject.ViewModels;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using OngProject.Services.Interfaces;
using Microsoft.AspNetCore.Cors;
using OngProject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace OngProject.Controllers
{
    [ApiController]
    [Route(template: "api/[controller]")]
    public class AuthenticationController : ControllerBase
    {
        
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public AuthenticationController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;

        }

        [HttpPost]
        [Route("auth/login")]
        public async Task<IActionResult> Login(User user)
        {
            var result = await _signInManager.PasswordSignInAsync(user.Username, user.Password, false, false);

            if (result.Succeeded)
            {
                var currentUser = await _userManager.FindByEmailAsync(user.Email);
                if (currentUser.IsActive)
                {
                    
                    return Ok(currentUser);

                }
            }

            return Ok(false);
        }


    }

}