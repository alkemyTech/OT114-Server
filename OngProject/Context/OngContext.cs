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
        public OngContext(DbContextOptions<OngContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
          
        }
        public override int SaveChanges()
        {
            foreach(var item in ChangeTracker.Entries().Where(e => e.State == EntityState.Deleted && 
                    e.Metadata.GetProperties().Any(x => x.Name == "IsDeleted")))
            {
                item.State = EntityState.Unchanged;
                item.CurrentValues["IsDeleted"] = true;
            }
            return base.SaveChanges();
        }
        public DbSet<Member> Members { get; set; }
       
    }
}
