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
        private const string Schema = "";
        public OngContext(DbContextOptions<OngContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.HasDefaultSchema(Schema);

          
        }
        public DbSet<Member> Members { get; set; }
       
    }
}
