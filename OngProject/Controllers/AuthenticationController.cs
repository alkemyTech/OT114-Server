using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
using OngProject.Services;
using Microsoft.AspNetCore.Authorization;

namespace OngProject.Controllers
{
    /// <summary>
    /// Controller for User details, register and login
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class AuthenticationController : ControllerBase
    {
        //Registro
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IMailService _mailService;

        public AuthenticationController(
            UserManager<User> userManager, 
            SignInManager<User> signInManager,
            IMailService mailService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _mailService = mailService;
        }

        /// <summary>
        /// Gets a user details
        /// </summary>
        /// <returns>A user or an error</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET: api/me
        ///     {
        ///        "IdUser" : 1,
        ///        "FirstName" : "FFFF" ,
        ///        "LastName" : "FFFF",
        ///        "Email" : "FFFF@FFFF.COM",
        ///        "Password" : "FFFF",
        ///        "Photo" : "IMG1",
        ///        "DeletedAt" : "NULL",
        ///        "roleID" : 1,
        ///        "MyToken" : "FFFF",
        ///     }
        ///
        /// </remarks>
        /// <response code="200">OK. Returns a user.</response>
        /// <response code="400">BadRequest. Incorrect format.</response>
        /// <response code="401">Unauthorized. Unauthenticated user or wrong jwt token.</response>
        /// <response code="404">NotFound. Objects not found.</response>
        /// <response code="500">Internal server error. An error occurred while processing your request.</response>
        [HttpGet]
        [Route("/me")]
        [Authorize(Roles = "User")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<List<User>>> GetMe([FromBody] string username, string password)
        {
            //Chequear que el usuario exista y que la password provista sea correcta
            var result = await _signInManager.PasswordSignInAsync(username, password, false, false);
            if (result.Succeeded)
            {
                var currentUser = await _userManager.FindByNameAsync(username);
                if (currentUser.DeletedAt == null) //chequeo que esté activo
                {
                    return Ok(currentUser);//deberia devolver la entidad completa
                }

            }
            return BadRequest();
        }

        /// <summary>
        /// Creates a user
        /// </summary>
        /// <returns>A user token, or an error</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST: api/register
        ///     {
        ///        "name": "FFFF",
        ///        "password": "FFFF",
        ///        "email" : "FFFF@FFFF.com"
        ///     }
        ///
        /// </remarks>
        /// <response code="200">OK. Success, returns a token.</response>
        /// <response code="400">BadRequest. Object not created, incorrect format.</response>
        /// <response code="500">Internal server error. An error occurred while processing your request.</response>
        [HttpPost]
        [Route("register")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Register([FromBody]string name, string password, string email)
        {
     
            //Revisar si existe usuario
            var userExists = await _userManager.FindByNameAsync(name);

            //Si existe, devolver error
            if (userExists != null)
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }

            //Si no existe, registrar al usuario
            var user = new User
            {
                UserName = name,
                Email = email,
                Password = password
            };
            var result = await _userManager.CreateAsync(user, password);

            if (!result.Succeeded)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new
                {
                    status = "Error",
                    Message = $"User Creation Failed! Errors:{string.Join(", ", result.Errors.Select(x => x.Description))}"//agarra los errores y los separa con una coma
                });

            }
            return Ok(await GetToken(user)); 
        }

        /// <summary>
        /// Login a user
        /// </summary>
        /// <returns>A user token, or an error</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST: api/login
        ///     {
        ///        "name": "FFFF",
        ///        "password": "FFFF",
        ///     }
        ///
        /// </remarks>
        /// <response code="200">OK. Success, returns a token.</response>
        /// <response code="400">BadRequest. Incorrect format.</response>
        /// <response code="401">Unauthorized. Unauthenticated user or wrong jwt token.</response>
        /// <response code="500">Internal server error. An error occurred while processing your request.</response>
        [HttpPost]
        [Route("login")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Login([FromBody] string name, string password)
        {
            //Chequear que el usuario exista y que la password provista sea correcta
            var result = await _signInManager.PasswordSignInAsync(name, password, false, false);

            if (result.Succeeded)
            {
                var currentUser = await _userManager.FindByNameAsync(name);
                if (currentUser.DeletedAt == null) //chequeo que esté activo
                {
                    //Generar el token
                    //Devolver Roken creado

                    var datosToken = await GetToken(currentUser);
                    currentUser.MyToken = datosToken.Token;
                    return Ok(await GetToken(currentUser));

                }
            }

            return StatusCode(StatusCodes.Status401Unauthorized, new
            {
                status = "Error",
                Message = $"User {name} not authorized!"
            });

        }
        private async Task<LoginResponseViewModel> GetToken(User currentUser)
        {
            var userRoles = await _userManager.GetRolesAsync(currentUser);

            var authClaims = new List<Claim>()
            {
                new Claim (ClaimTypes.Name,currentUser.UserName),
                new Claim (JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            //agregamos anuestra lista de privilegios o claims todos los privilegios de nuestro usuario
            authClaims.AddRange(userRoles.Select(x => new Claim(ClaimTypes.Role, x)));

            //levantamos nuestro signin key
            var authSignInKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("KeySecretaSuperLargaDeAutorizacion")); //Encargado de proveernos info con la llave secreta para ingresar a la aplicación

            //creo el token
            var token = new JwtSecurityToken(
                issuer: "https://localhost:5001",
                audience: "https://localhost:5001",
                expires: DateTime.Now.AddHours(4),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSignInKey, SecurityAlgorithms.HmacSha256));

            return new LoginResponseViewModel
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                ValidTo = token.ValidTo
            };
        }

    }

    internal class LoginResponseViewModel //mini viewmodel 
    {
        public string Token { get; set; }
        public DateTime ValidTo { get; set; }
    }

   
}