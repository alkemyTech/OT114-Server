﻿using Microsoft.EntityFrameworkCore;
using OngProject.Data;
using OngProject.Interfaces;
using OngProject.Models;
using OngProject.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OngProject.Repositories
{
    public class CategoryRepository : BaseRepository<Category, ONGDBContext>
    {
        public CategoryRepository(ONGDBContext context) : base(context)
        {
        }
    }
}
