﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace OngProject.Services.Interfaces
{
    public interface IService<T> where T : class
    {
        public List<T> GetAllEntities();
        public T Get(int id);
        public T Add(T entity);
        public T Update(T entity);
        public T Delete(int id);
    }
}
