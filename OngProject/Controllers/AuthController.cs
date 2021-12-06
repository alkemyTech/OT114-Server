using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OngProject.Models;
using OngProject.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OngProject.Controllers
{
    [ApiController]
    public class AuthController: ControllerBase
    {
        private readonly UserManager<Usuario> _userManager;
        public AuthController(UserManager<Usuario> userManager)
        {
            _userManager = userManager;
        }
        [HttpPost]
        [Route("auth/register")]
        public async Task<IActionResult> Registro(RegisterViewModel  registerViewModel)
        {
            var UsuarioExiste = await _userManager.FindByNameAsync(registerViewModel.UserName);
            if(UsuarioExiste != null)
            {
                return BadRequest(new {Status ="Error",Messege="El Usuario que intenta crear ya existe." });
            }
            var NuevoUsuario = new Usuario 
            { 
                Nombre = registerViewModel.UserName,
                Apellido = registerViewModel.LastName,
                EmailUsuario = registerViewModel.EmailUser,
                Contraseña = registerViewModel.Password

            };

            var result = await _userManager.CreateAsync(NuevoUsuario, registerViewModel.Password);
            if (!result.Succeeded)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new
                {
                    Status = "Error",
                    Messege = $"La creacion del usuario ha fallado!{string.Join(",", result.Errors.Select(e => e.Description))} "
                });
            }
            return Ok(new
            {
                Status = "Success",
                Messege = $"Se ha creado el usuario {NuevoUsuario.UserName} correctamente!"
            });
        }
    }
}
