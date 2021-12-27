using Microsoft.EntityFrameworkCore;
using OngProject.Models;

namespace OngProject.Data
{
    public static class MembersSeedData
    {
        public static void MembersSeed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Member>().HasData(
                new Member
                {
                    Id = 1,
                    Name = "María Irola",
                    Description = "Presidenta",
                    Image = "Empty",
                    FacebookUrl = "www.Facebook.com/MariaIrola",
                    InstagramUrl = "www.Instagram.com/MariaIrola",
                    LinkedinUrl = "www.Linkedin.com/MariaIrola",
                    DeletedAt = null                   
                },
                new Member
                {
                    Id = 2,
                    Name = "Marita Gomez",
                    Description = "Fundadora",
                    Image = "Empty",
                    FacebookUrl = "www.Facebook.com/MaritaGomez",
                    InstagramUrl = "www.Instagram.com/MaritaGomez",
                    LinkedinUrl = "www.Linkedin.com/MaritaGomez",
                    DeletedAt = null
                },
                new Member
                {
                    Id = 3,
                    Name = "Miriam Rodriguez",
                    Description = "Terapista Ocupacional",
                    Image = "Empty",
                    FacebookUrl = "www.Facebook.com/MiriamRodriguez",
                    InstagramUrl = "www.Instagram.com/MiriamRodriguez",
                    LinkedinUrl = "www.Linkedin.com/MiriamRodriguez",
                    DeletedAt = null
                },
                new Member
                {
                    Id = 4,
                    Name = "Cecilia Mendez",
                    Description = "Psicopedagoga",
                    Image = "Empty",
                    FacebookUrl = "www.Facebook.com/CeciliaMendez",
                    InstagramUrl = "www.Instagram.com/CeciliaMendez",
                    LinkedinUrl = "www.Linkedin.com/CeciliaMendez",
                    DeletedAt = null
                },
                new Member
                {
                    Id = 5,
                    Name = "Mario Fuentes",
                    Description = "Psicólogo",
                    Image = "Empty",
                    FacebookUrl = "www.Facebook.com/MarioFuentes",
                    InstagramUrl = "www.Instagram.com/MarioFuentes",
                    LinkedinUrl = "www.Linkedin.com/MarioFuentes",
                    DeletedAt = null
                },
                new Member
                {
                    Id = 6,
                    Name = "Rodrigo Fuente",
                    Description = "Contador",
                    Image = "Empty",
                    FacebookUrl = "www.Facebook.com/RodrigoFuente",
                    InstagramUrl = "www.Instagram.com/RodrigoFuente",
                    LinkedinUrl = "www.Linkedin.com/RodrigoFuente",
                    DeletedAt = null
                },
                new Member
                {
                    Id = 7,
                    Name = "Maria Garcia",
                    Description = "Profesora de Artes Dramáticas",
                    Image = "Empty",
                    FacebookUrl = "www.Facebook.com/MariaGarcia",
                    InstagramUrl = "www.Instagram.com/MariaGarcia",
                    LinkedinUrl = "www.Linkedin.com/MariaGarcia",
                    DeletedAt = null
                },
                new Member
                {
                    Id = 2,
                    Name = "Marco Fernandez",
                    Description = "Profesor de Educación Física",
                    Image = "Empty",
                    FacebookUrl = "www.Facebook.com/MarcoFernandez",
                    InstagramUrl = "www.Instagram.com/MarcoFernandez",
                    LinkedinUrl = "www.Linkedin.com/MarcoFernandez",
                    DeletedAt = null
                });
        }
    }
}
