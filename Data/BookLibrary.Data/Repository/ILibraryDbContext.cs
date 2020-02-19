using BookLibrary.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookLibrary.Data.Repository
{
    public interface ILibraryDbContext:IDisposable
    {
        DbContext DbContext { get; }
        public IRepository<User> Users { get; }
        public IRepository<Author> Authors { get; }
        public IRepository<AuthorBooks> AuthorBooks { get;}
        public IRepository<Book> Books { get;}
        public IRepository<Comment> Comments { get;}
        public IRepository<Department> Departments { get;}
        public IRepository<Employee> Employees { get;}
        public IRepository<Role> Roles { get;}
        public IRepository<UserBooks> UserBooks { get;}
        int SaveChanges();

    }
}
