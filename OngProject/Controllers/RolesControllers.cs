using Microsoft.AspNetCore.Mvc;
using OngProject.Models;
using OngProject.Services.Interfaces;
using OngProject.ViewModels.Roles;

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
        public IActionResult Post(RolesVM rolesPostVM)
        {
            var roles = new Roles
            {
                Name = rolesPostVM.Name,
                Description = rolesPostVM.Description
            };
            _rolesService.AddRoles(roles);
            return Ok(rolesPostVM);

        }

        [HttpPut]
        [Route("/ActualizarRoles")]
        public IActionResult Put(RolesPutVM rolesViewModel)
        {
            var rolesEdit = _rolesService.GetById(rolesViewModel.Id);
            if (rolesEdit == null) return NotFound($"El rol con Id {rolesViewModel.Id} no existe :(");
            rolesEdit.Name = rolesViewModel.Name;
            rolesEdit.Description = rolesViewModel.Description;

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
