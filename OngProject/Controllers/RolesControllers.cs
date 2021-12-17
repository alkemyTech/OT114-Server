using Microsoft.AspNetCore.Mvc;
using OngProject.Models;
using OngProject.Services.Interfaces;

namespace OngProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RolesController : ControllerBase
    {
        private readonly IRolesService _rolesService;
             

        public RolesController(IRolesService rolesService)
        {
            _rolesService = rolesService;
        }


        [HttpGet]
        [Route("/ObtenerRoles")]
        public IActionResult Get(int id)
        {
            var roles = _rolesService.GetRoles();
            if (id != 0)
            {
                var role = _rolesService.GetById(id);
                if (role == null) return NotFound($"El Rol con Id {id} no existe :(");
                return Ok(role);
            }

            return Ok(roles);
        }

        [HttpPost]
        [Route("/CrearRoles")]
        public IActionResult Post(Roles roles)
        {
            var role = new Roles
            {
                Name = roles.Name,
                Description = roles.Description
            };
            _rolesService.AddRoles(role);
            return Ok(roles);

        }

        [HttpPut]
        [Route("/ActualizarRoles")]
        public IActionResult Put(Roles roles)
        {
            var rolesEdit = _rolesService.GetById(roles.Id);
            if (rolesEdit == null) return NotFound($"El rol con Id {roles.Id} no existe :(");
            rolesEdit.Name = roles.Name;
            rolesEdit.Description = roles.Description;

            _rolesService.UpdateRoles(rolesEdit);
            return Ok(rolesEdit);
        }

        [HttpDelete]
        [Route("/BorrarRoles")]
        public IActionResult Delete(int id)
        {
            var role = _rolesService.GetById(id);
            if (role == null) return NotFound($"El rol con Id {id} no existe :(");
            _rolesService.DeleteRoles(id);
            return Ok("el Rol se elimino correctamente");
        }

    }
}
