using BookLibrary.Data.Common.Models.Interfaces;
using BookLibrary.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace BookLibrary.Data.Repository
{
    public class LibraryDbContextRepository : ILibraryDbContext
    {
        private LibraryDbContext context;
        bool disposed = false;
        SafeHandle handle = new SafeFileHandle(IntPtr.Zero, true);
        public DbContext DbContext { get { return this.context; } }
        private readonly Dictionary<Type, object> repositories;
        public LibraryDbContextRepository(LibraryDbContext context)
        {
            this.context = context;
            repositories = new Dictionary<Type, object>();
        }
      
        public IRepository<User> Users
        {
            get
            {
                return this.GetRepository<User>();
            }
        }

        public IRepository<Author> Authors
        {
            get
            {
                return this.GetRepository<Author>();
            }
        }

        public IRepository<AuthorBooks> AuthorBooks
        {
            get
            {
                return this.GetRepository<AuthorBooks>();
            }
        }

        public IRepository<Book> Books
        {
            get
            {
                return this.GetRepository<Book>();
            }
        }

        public IRepository<Comment> Comments
        {
            get
            {
                return this.GetRepository<Comment>();
            }
        }


        public IRepository<Department> Departments
        {
            get
            {
                return this.GetRepository<Department>();
            }
        }


        public IRepository<Employee> Employees
        {
            get
            {
                return this.GetRepository<Employee>();
            }
        }


        public IRepository<Role> Roles
        {
            get
            {
                return this.GetRepository<Role>();
            }
        }


        public IRepository<UserBooks> UserBooks
        {
            get
            {
                return this.GetRepository<UserBooks>();
            }
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

        public int SaveChanges()
        {
           return this.context.SaveChanges();
        }
        private IRepository<T> GetRepository<T>() where T : class, IAuditInfo, new()
        {
            if (!this.repositories.ContainsKey(typeof(T)))
            {
                var type = typeof(IRepository<T>);

                this.repositories.Add(typeof(T), Activator.CreateInstance(type, this.context));
            }

            return (IRepository<T>)this.repositories[typeof(T)];
        }
    }
}
