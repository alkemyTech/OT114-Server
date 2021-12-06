using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using OngProject.Models;
using Microsoft.EntityFrameworkCore;

namespace OngProject.Data
{
    public class UserContext : IdentityDbContext<User>
    {
        //Hereda de un Identity context, da funcionalidad particular


        private const string Schema = "dbo";
        public UserContext()
        {

        }
        public UserContext(DbContextOptions<UserContext> options) : base(options)
        {

        }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            //Fluent dpi
            //No hay ningún db set
            base.OnModelCreating(builder);
            builder.HasDefaultSchema(Schema);
        }
    }
}
