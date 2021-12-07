﻿using OngProject.Interfaces;
using OngProject.Models;
using OngProject.Repositories;
using OngProject.Data;
using System.Collections.Generic;

namespace OngProject.Services
{
    public class CategoryService : ICategoryService
    {
        public CategoryService(ONGDBContext dbContext) : base(dbContext)
        {
        }
        
        public Category AddCategory(Category category)
        {
            return Add(category);
        }

        public List<Category> GetAllCategory()
        {
            return GetAllEntities();
        }

        public Category GetCategory(Category category)
        {
            return Get(category.Id);
        }

        public Category UpdateCategory(Category category)
        {
            return Update(category);
        }
    }
}
