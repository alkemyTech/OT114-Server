using Microsoft.EntityFrameworkCore;
using OngProject.Models;

namespace OngProject.Data
{
    public class ONGDBContext : DbContext
    {
        
        public ONGDBContext(DbContextOptions<ONGDBContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)

        {
            modelBuilder.Entity<User>(entity => {
                entity.HasIndex(e => e.Email).IsUnique();
            });

            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Roles> Roles { get; set; }
    }
}
