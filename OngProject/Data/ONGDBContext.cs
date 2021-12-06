﻿using Microsoft.EntityFrameworkCore;
using OngProject.Models;

namespace OngProject.Data
{
    public class ONGDBContext : DbContext
    {

        public ONGDBContext(DbContextOptions<ONGDBContext> options) : base(options)
        {
        }
        public DbSet<Category> Categories { get; set; }
    }
}