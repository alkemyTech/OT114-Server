﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OngProject.Data;
using OngProject.Models;
using OngProject.Repositories;
using OngProject.Interfaces;
using OngProject.ViewModels;
using Microsoft.EntityFrameworkCore;
using OngProject.Services.Interfaces;
using OngProject.Services;

namespace OngProject.Controllers
{
    [ApiController]
    [Route(template: "api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userRepository;
        private readonly ONGDBContext _context;

        public UserController(IUserService userRepository, ONGDBContext context)
        {
            _context = context;
            _userRepository = userRepository;
        }

        //GetAll 
        //DEVUELVE TODOS LOS USERS EN UN LISTADO
        [HttpGet] //Verbo de http GET 
        [Route(template: "users")]
        public IActionResult Get()
        {

            var user = _userRepository.GetAllUsers();
            // var user = _context.Users.ToList();
            var userVM = new List<UserVM>();

            foreach (var u in user)
            {
                userVM.Add(new UserVM
                {
                    Id = u.Id,
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    Email = u.Email,
                    Photo = u.Photo
                });
            }

            return Ok(userVM);

        }

        //GetOne
        // DEVUELVE INFO DETALLADA DE UN USER EN PARTICULAR
        [HttpGet] //Verbo de http GET 
        [Route(template: "DetailedPerfil")]
        public IActionResult Get(UserVM user)
        {



            //var users = _context.Users.ToList();
            var userVM = new List<UserVM>();

            if (user.Id != null)
            {
                var userById = _userRepository.Get(user.IdUser);

                userVM.Add(new UserVM
                {
                    Id = user.Id,
                    IdUser = user.IdUser,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email,
                    Photo = user.Photo
                });

                return Ok(userVM);
            }
            else
            {
                return BadRequest(error: $"No hay perfiles con este criterio");
            }


        }



        // TODO CREATE - INSERT - POST
        // INSERT DE USER
        [HttpPost] //Verbo de http POST
        public IActionResult Post(User us)
        {
            //Comprueba si el nombre de usuario no existe ya en la base de datos, ya que debe ser unico para cada uno
            // var perfil = _context.Perfiles.ToList();
            //perfil = perfil.Where(x => x.Id == ap.Id).ToList();

            var userExists = _userRepository.Get(us.IdUser);

            if (userExists == null)
            {


                _userRepository.AddUser(us);


                return Ok();
            }
            else
            {
                //Ya hay un usuario con ese nombre
                return BadRequest();
            }

        }

        // TODO UPDATE - PUT / PATCH
        //ACTUALIZO DATOS DEL USER
        [HttpPut] //Verbo de http PUT
        public IActionResult Put(User us)
        {
            var userExists = _userRepository.Get(us.IdUser);


            if (userExists != null)
            {


                _userRepository.UpdateUser(us);


                return Ok();
            }
            else
            {
                //Ya hay un usuario con ese nombre
                return BadRequest();
            }
        }

        //// TODO DELETE
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            if (_context.Users.FirstOrDefault(x => x.IdUser == id) == null) return BadRequest(error: "El user enviado no existe.");

            var internalUser = _context.Users.Find(id);
            _context.Users.Remove(internalUser);
            _context.SaveChanges();

            return Ok();
        }
    }


}