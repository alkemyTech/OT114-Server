using OngProject.Models;
using System.Threading.Tasks;

namespace OngProject.Services
{
    public interface IMailService
    {
        Task SendEmail(User user);
        Task SendByEmail(string email);
    }
}