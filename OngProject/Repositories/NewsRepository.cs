﻿using OngProject.Data;
using OngProject.Models;
using OngProject.Services;
using OngProject.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OngProject.Repositories
{
    public class NewsRepository : BaseRepository<News,ONGDBContext>
    {
        public NewsRepository(ONGDBContext context)
            :base(context)
        {
            
        }
    }
}
