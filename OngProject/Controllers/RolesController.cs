using Microsoft.AspNetCore.Mvc;
using OngProject.Entities;
using OngProject.Repositories;
using OngProject.ViewModels.Roles;

namespace OngProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RolesController : ControllerBase
    {
        private readonly IRolesRepository _rolesRepository;

        public RolesController(IRolesRepository rolesRepository)
        {
            _rolesRepository = rolesRepository;
        }
        [HttpGet]
        public IActionResult Get(int id)
        {
            var roles = _rolesRepository.GetRoles();
            if (id != 0)
            {
                var role = _rolesRepository.GetRole(id);
                if (role == null) return NotFound($"El Role con Id {id} no existe :(");
                return Ok(role);
            }
            
            return Ok(roles);
        }

        [HttpPost]
        public IActionResult Post(RolesVM rolesPostVM)
        {
            var roles = new Roles
            {
                Name = rolesPostVM.Name,
                Description = rolesPostVM.Description
            };
            _rolesRepository.Add(roles);
            return Ok(roles);

        }

        [HttpPut]
        public IActionResult Put(RolesPutVM rolesViewModel)
        {
            var rolesEdit = _rolesRepository.GetRole(rolesViewModel.Id);
            if (rolesEdit == null) return NotFound($"El rol con Id {rolesEdit.Id} no existe :(");
            rolesEdit.Name = rolesViewModel.Name;
            rolesEdit.Description = rolesViewModel.Description;
            
            _rolesRepository.Update(rolesEdit);
            return Ok(rolesEdit);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var role = _rolesRepository.GetRole(id); 
            if (role == null) return NotFound($"El rol con Id {id} no existe :(");
            _rolesRepository.Delete(id);
            return Ok("el Rol se elimino correctamente");
        }

    }
}
