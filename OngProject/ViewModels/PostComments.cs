using OngProject.Models;
using System.ComponentModel.DataAnnotations;

namespace OngProject.ViewModels
{
    public class PostComments
    {        

        [Required]
        public string Body { get; set; }
        [Required]

        public User UserId { get; set; }

        [Required]
        public News NewsId { get; set; }
    }
}
