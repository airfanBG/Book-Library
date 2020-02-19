using BookLibrary.Data.Common.Models.BaseModels;
using BookLibrary.Data.Common.Models.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;

namespace BookLibrary.Data.Repository
{
    public class BaseRepository<T,Tkey> :IDisposable, IRepository<T> where T: BaseModel<Tkey>, IAuditInfo,new()
    {

        bool disposed = false;
        SafeHandle handle = new SafeFileHandle(IntPtr.Zero, true);
        public DbContext Context { get; set; }
        public DbSet<T> DbSet { get; set; }

        public BaseRepository(DbContext context)
        {
            this.Context = context ?? throw new ArgumentException("An instance of context is null");

            this.DbSet = this.Context.Set<T>();
        }
        public BaseRepository()
        {
            Context = new LibraryDbContext();
            this.DbSet = this.Context.Set<T>();
        }
        public bool Add(T entity)
        {
            EntityEntry entry = this.Context.Entry(entity);
            if (entry.State != EntityState.Detached)
            {
                entry.State = EntityState.Added;
            }
            else
            {
                this.DbSet.Add(entity);
                this.SaveChanges();
                return true;
            }
            return false;
        }
       
        public bool Delete(object id)
        {
            var res = this.Context.Set<T>().Where(x =>(object)x.Id ==id).Single();
            EntityEntry entry = this.Context.Entry(res);

            if (entry.State != EntityState.Deleted)
            {
                entry.State = EntityState.Deleted;
            }
            else
            {
                this.DbSet.Attach(res);
                this.DbSet.Remove(res);
                return true;
            }
            return false;
        }

        public T FindById(object id)
        {
            var res = this.Context.Set<T>().Where(x => (object)x.Id == id).Single();
            return res;
        }

        public IQueryable<T> GetAll(Func<T, bool> func = null)
        {
            if (func == null)
            {
                return this.DbSet.AsQueryable<T>().AsNoTracking();
            }
            else
            {
                return this.DbSet.Where(func).AsQueryable<T>().AsNoTracking();
            }
        }

        public int SaveChanges()
        {
           return this.Context.SaveChanges();
        }

        public bool Update(T entity)
        {
            var res = this.Context.Set<T>().Find(entity);
            if (res!=null)
            {
                EntityEntry entry = this.Context.Entry(res);
                if (entry.State == EntityState.Detached)
                {
                    this.DbSet.Attach(entity);

                }
                entry.State = EntityState.Modified;
                return true;
            }
            return false;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
            {
                handle.Dispose();

            }

            disposed = true;
        }

    }
}
