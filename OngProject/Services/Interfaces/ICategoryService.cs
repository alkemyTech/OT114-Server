using OngProject.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OngProject.Interfaces
{
    public interface ICategoryService 
    {
       List<Category> GetAll();        
    }
}
