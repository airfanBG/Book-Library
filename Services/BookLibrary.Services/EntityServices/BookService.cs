using BookLibrary.Data.Repository;
using BookLibrary.Models;
using BookLibrary.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BooksLibrary.Services.EntityServices
{
    public class BookService : IBaseOperations<Book>
    {
        private IRepository<Book> context;
        public BookService(IRepository<Book> db)
        {
            context = db;
        }

        public bool Add(Book model)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Book> All(Func<Book, bool> func = null)
        {
            return context.GetAll(func);
        }

        public bool Delete(object id)
        {
            throw new NotImplementedException();
        }

        public bool Update(Book model)
        {
            throw new NotImplementedException();
        }
    }
}
