using OngProject.Models;
using System.ComponentModel.DataAnnotations;

namespace OngProject.ViewModels
{
    public class PutComment
    {
        [Required]
        public int Id { get; set; }
        public string Body { get; set; }
        public User UserId { get; set; }
        public News NewsId { get; set; }
    }
}
