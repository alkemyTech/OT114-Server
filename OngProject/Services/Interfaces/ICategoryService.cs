using OngProject.Models;
using System.Collections.Generic;

namespace OngProject.Services.Interfaces
{
    public interface ICategoryService : IService<Category>
    {
        Category AddCategory(Category category);
        List<Category> GetAllCategory();
        Category GetCategory(Category category);
        Category UpdateCategory(Category category);

    }
}
