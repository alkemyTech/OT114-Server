using System.ComponentModel.DataAnnotations;

namespace OngProject.ViewModels.Roles
{
    public class RolesPutVM
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [MaxLength(120)]
        public string Name { get; set; } = null!;
        [MaxLength(250)]
        public string Description { get; set; }
    }
}
