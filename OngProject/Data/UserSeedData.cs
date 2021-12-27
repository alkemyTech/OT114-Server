using Microsoft.EntityFrameworkCore;
using OngProject.Models;

namespace OngProject.Data
{
    public static class UserSeedData
    {
        public static void UserSeed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    IdUser = 1,                    
                    FirstName = "User1",                    
                    LastName = "LastNameUser1",
                    Email = "mailuser1@gmail.com",                    
                    Password = "Passworduser1",
                    Photo = "Empty",
                    DeletedAt = null,
                    roleID = new Roles
                    {
                        Id = 1,
                        Name = "User",
                        Description = "Usuario estándar"
                    }
                },
                new User
                {
                    IdUser = 2,
                    FirstName = "User2",
                    LastName = "LastNameUser2",
                    Email = "mailuser2@gmail.com",
                    Password = "Passworduser2",
                    Photo = "Empty",
                    DeletedAt = null,
                    roleID = new Roles { Id = 1,
                                        Name = "User",
                                        Description = "Usuario estándar"
                                       }
                },
                new User
                {
                    IdUser = 3,
                    FirstName = "User3",
                    LastName = "LastNameUser3",
                    Email = "mailuser3@gmail.com",
                    Password = "Passworduser3",
                    Photo = "Empty",
                    DeletedAt = null,
                    roleID = new Roles
                    {
                        Id = 1,
                        Name = "User",
                        Description = "Usuario estándar"                        
                    }
                },
                new User
                {
                    IdUser = 4,
                    FirstName = "User4",
                    LastName = "LastNameUser4",
                    Email = "mailuser4@gmail.com",
                    Password = "Passworduser4",
                    Photo = "Empty",
                    DeletedAt = null,
                    roleID = new Roles
                    {
                        Id = 1,
                        Name = "User",
                        Description = "Usuario estándar"
                    }
                },
                new User
                {
                    IdUser = 5,
                    FirstName = "User5",
                    LastName = "LastNameUser5",
                    Email = "mailuser5@gmail.com",
                    Password = "Passworduser5",
                    Photo = "Empty",
                    DeletedAt = null,
                    roleID = new Roles
                    {
                        Id = 1,
                        Name = "User",
                        Description = "Usuario estándar"
                    }
                },
                new User
                {
                    IdUser = 6,
                    FirstName = "User6",
                    LastName = "LastNameUser6",
                    Email = "mailuser6@gmail.com",
                    Password = "Passworduser6",
                    Photo = "Empty",
                    DeletedAt = null,
                    roleID = new Roles
                    {
                        Id = 1,
                        Name = "User",
                        Description = "Usuario estándar"
                    }
                },
                new User
                {
                    IdUser = 7,
                    FirstName = "User7",
                    LastName = "LastNameUser7",
                    Email = "mailuser7@gmail.com",
                    Password = "Passworduser7",
                    Photo = "Empty",
                    DeletedAt = null,
                    roleID = new Roles
                    {
                        Id = 1,
                        Name = "User",
                        Description = "Usuario estándar"
                    }
                },
                new User
                {
                    IdUser = 8,
                    FirstName = "User8",
                    LastName = "LastNameUser8",
                    Email = "mailuser8@gmail.com",
                    Password = "Passworduser8",
                    Photo = "Empty",
                    DeletedAt = null,
                    roleID = new Roles
                    {
                        Id = 1,
                        Name = "User",
                        Description = "Usuario estándar"
                    }
                },
                new User
                {
                    IdUser = 9,
                    FirstName = "User9",
                    LastName = "LastNameUser9",
                    Email = "mailuser9@gmail.com",
                    Password = "Passworduser9",
                    Photo = "Empty",
                    DeletedAt = null,
                    roleID = new Roles
                    {
                        Id = 1,
                        Name = "User",
                        Description = "Usuario estándar"
                    }
                },
                new User
                {
                    IdUser = 10,
                    FirstName = "User10",
                    LastName = "LastNameUser10",
                    Email = "mailuser10@gmail.com",
                    Password = "Passworduser10",
                    Photo = "Empty",
                    DeletedAt = null,
                    roleID = new Roles
                    {
                        Id = 1,
                        Name = "User",
                        Description = "Usuario estándar"
                    }
                },
                new User
                {
                    IdUser = 11,
                    FirstName = "RegularUser11",
                    LastName = "LastNameRegularUser11",
                    Email = "mailRegularUser11@gmail.com",
                    Password = "PasswordRegularUser11",
                    Photo = "Empty",
                    DeletedAt = null,
                    roleID = new Roles
                    {
                        Id = 2,
                        Name = "RegularUser",
                        Description = "Usuario Regular"
                    }
                },
                new User
                {
                    IdUser = 12,
                    FirstName = "RegularUser12",
                    LastName = "LastNameRegularUser12",
                    Email = "mailRegularUser12@gmail.com",
                    Password = "PasswordRegularUser121",
                    Photo = "Empty",
                    DeletedAt = null,
                    roleID = new Roles
                    {
                        Id = 2,
                        Name = "RegularUser",
                        Description = "Usuario Regular"
                    }
                },
                new User
                {
                    IdUser = 13,
                    FirstName = "RegularUser13",
                    LastName = "LastNameRegularUser13",
                    Email = "mailRegularUser13@gmail.com",
                    Password = "PasswordRegularUser13",
                    Photo = "Empty",
                    DeletedAt = null,
                    roleID = new Roles
                    {
                        Id = 2,
                        Name = "RegularUser",
                        Description = "Usuario Regular"
                    }
                },
                new User
                {
                    IdUser = 14,
                    FirstName = "RegularUser14",
                    LastName = "LastNameRegularUser14",
                    Email = "mailRegularUser14@gmail.com",
                    Password = "PasswordRegularUser14",
                    Photo = "Empty",
                    DeletedAt = null,
                    roleID = new Roles
                    {
                        Id = 2,
                        Name = "RegularUser",
                        Description = "Usuario Regular"
                    }
                },
                new User
                {
                    IdUser = 15,
                    FirstName = "RegularUser15",
                    LastName = "LastNameRegularUser15",
                    Email = "mailRegularUser15@gmail.com",
                    Password = "PasswordRegularUser15",
                    Photo = "Empty",
                    DeletedAt = null,
                    roleID = new Roles
                    {
                        Id = 2,
                        Name = "RegularUser",
                        Description = "Usuario Regular"
                    }
                },
                new User
                {
                    IdUser = 16,
                    FirstName = "RegularUser16",
                    LastName = "LastNameRegularUser16",
                    Email = "mailRegularUser16@gmail.com",
                    Password = "PasswordRegularUser16",
                    Photo = "Empty",
                    DeletedAt = null,
                    roleID = new Roles
                    {
                        Id = 2,
                        Name = "RegularUser",
                        Description = "Usuario Regular"
                    }
                },
                new User
                {
                    IdUser = 17,
                    FirstName = "RegularUser17",
                    LastName = "LastNameRegularUser17",
                    Email = "mailRegularUser17@gmail.com",
                    Password = "PasswordRegularUser17",
                    Photo = "Empty",
                    DeletedAt = null,
                    roleID = new Roles
                    {
                        Id = 2,
                        Name = "RegularUser",
                        Description = "Usuario Regular"
                    }
                },
                new User
                {
                    IdUser = 18,
                    FirstName = "RegularUser18",
                    LastName = "LastNameRegularUser18",
                    Email = "mailRegularUser18@gmail.com",
                    Password = "PasswordRegularUser18",
                    Photo = "Empty",
                    DeletedAt = null,
                    roleID = new Roles
                    {
                        Id = 2,
                        Name = "RegularUser",
                        Description = "Usuario Regular"
                    }
                },
                new User
                {
                    IdUser = 19,
                    FirstName = "RegularUser19",
                    LastName = "LastNameRegularUser19",
                    Email = "mailRegularUser19@gmail.com",
                    Password = "PasswordRegularUser19",
                    Photo = "Empty",
                    DeletedAt = null,
                    roleID = new Roles
                    {
                        Id = 2,
                        Name = "RegularUser",
                        Description = "Usuario Regular"
                    }
                },
                new User
                {
                    IdUser = 20,
                    FirstName = "RegularUser20",
                    LastName = "LastNameRegularUser20",
                    Email = "mailRegularUser20@gmail.com",
                    Password = "PasswordRegularUser20",
                    Photo = "Empty",
                    DeletedAt = null,
                    roleID = new Roles
                    {
                        Id = 2,
                        Name = "RegularUser",
                        Description = "Usuario Regular"
                    }
                }


                );
        }
    }
}
