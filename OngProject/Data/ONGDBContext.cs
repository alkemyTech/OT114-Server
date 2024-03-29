﻿using Microsoft.EntityFrameworkCore;
using OngProject.Models;
using System;

namespace OngProject.Data
{
    public class ONGDBContext : DbContext
    {
        private const string Schema = "ONG";
        public ONGDBContext(DbContextOptions<ONGDBContext> options) : base(options)
        {
           
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)

        {
            modelBuilder.HasDefaultSchema(Schema);
            modelBuilder.Entity<News>().HasData(new News()
            {
                Id =1,
                Name= "Últimas Novedades",
                Text = "texto complementario",
                Image = "Sin Imagen",
                DeletedAt = DateTime.Now
            });
            modelBuilder.Entity<Organization>()
                .HasOne(b => b.Slide)
                .WithOne(i => i.Organization)
                .HasForeignKey<Slide>(b => b.OrganizationId);

            modelBuilder.Entity<User>(entity => {
                entity.HasIndex(e => e.Email).IsUnique();
            });
            modelBuilder.HasSequence<int>("IdUser").StartsAt(0).IncrementsBy(1);
            modelBuilder.Entity<User>().Property(o => o.IdUser).HasDefaultValueSql("NEXT VALUE FOR IdUser");

            base.OnModelCreating(modelBuilder);

            modelBuilder.Seed();
            modelBuilder.UserSeed();
            modelBuilder.MembersSeed();
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Roles> Roles { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<Testimonials> Testimonials { get; set; }
        public DbSet<Slide> Slides { get; set; }
        public DbSet<Comments> Comments { get; set; }
        public DbSet<News> News { get; set; }
        public DbSet<Activity> Activities { get; set; }
        public DbSet<Organization> organizations { get; set; }
    }
}
