using BookLibrary.Data.Common.Models.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookLibrary.Data.Repository
{
    public interface IRepository<T>:IDisposable where T : class, IAuditInfo
    {
        DbContext Context { get; set; }
        DbSet<T> DbSet { get; set; }
        IQueryable<T> GetAll(Func<T, bool> func = null);
        bool Add(T entity);
        bool Update(T entity);
        bool Delete(object id);
        T FindById(object id);
        int SaveChanges();
    }
}
