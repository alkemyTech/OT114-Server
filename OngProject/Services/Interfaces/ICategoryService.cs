using OngProject.Models;
using OngProject.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace OngProject.Interfaces
{
    public interface ICategoryService: IService<Category>
    {
        Category AddCategory(Category category);
        List<Category> GetAllCategory();
        Category GetCategory(Category category);
        Category UpdateCategory(Category category);

    }
}
