﻿using Microsoft.EntityFrameworkCore;
using OngProject.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;


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
            modelBuilder.HasSequence<int>("IdUser").StartsAt(0).IncrementsBy(1);
            modelBuilder.Entity<User>().Property(o => o.IdUser).HasDefaultValueSql("NEXT VALUE FOR IdUser");

            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Roles> Roles { get; set; }
        public DbSet<Contact> Contacts { get; set; }
    }
}
