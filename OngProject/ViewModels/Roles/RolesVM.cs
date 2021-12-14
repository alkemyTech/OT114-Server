using System.ComponentModel.DataAnnotations;

namespace OngProject.ViewModels.Roles
{
    public class RolesVM
    {
       
        [Required]
        [MaxLength(120)]
        public string Name { get; set; } = null!;
        [MaxLength(250)]
        public string Description { get; set; }
        //public DateTime Timestamps { get; set; } = DateTime.Now;
    }
}
