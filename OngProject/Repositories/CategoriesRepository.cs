using OngProject.Context;
using OngProject.Entities;
using OngProject.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OngProject.Repositories
{
    public class CategoriesRepository : BaseRepository<Categories, OngContext>, ICategoriesRepository
    {
        public CategoriesRepository(OngContext dbContext) : base(dbContext)
        {
        }

        public Categories GetCategories(int id)
        {
            throw new NotImplementedException();
        }

        public List<Categories> GetCategories()
        {
            throw new NotImplementedException();
        }
    }
}
