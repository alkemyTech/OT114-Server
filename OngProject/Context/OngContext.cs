using Microsoft.EntityFrameworkCore;
using OngProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OngProject.Context
{
    
    public class OngContext : DbContext
    {
        public OngContext (DbContextOptions<OngContext> options)
            : base(options)
        {

        }
        public  DbSet<Organizacion> organizaciones { get; set; }

    }
}
