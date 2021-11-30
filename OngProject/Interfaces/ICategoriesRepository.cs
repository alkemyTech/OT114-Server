using OngProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OngProject.Interfaces
{
    public interface ICategoriesRepository : IBaseRepository<Categories>
    {
        Categories GetCategories(int id);

        List<Categories> GetCategories();
    }
}
