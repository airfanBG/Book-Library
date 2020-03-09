using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookLibrary.Models;
using BookLibrary.Services.Interfaces;
using BooksLibrary.WebLibrary.Models.ViewModels;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Mvc;

namespace BooksLibrary.WebLibrary.Controllers
{
    public class BooksController : Controller
    {
        private readonly IDataProtector _protector;
        private IBaseOperations<Book> _book;
        public BooksController(IBaseOperations<Book> baseOperations, IDataProtectionProvider provider)
        {
            _book = baseOperations;
            _protector = provider.CreateProtector("BooksLibrary.WebLibrary.Controllers");
        }
        public IActionResult Index()
        {
            //var res = _book.All().Select(x =>
            //new {
            //    EncryptedId = _protector.Protect(x.Id)

            //}).ToList();
            var res = _book.All().Select(x => new BookModel()
            {
                BookName = x.BookName,
                Annotation = x.BookAnnotation,
                Author = x.AuthorBooks.Select(a => a.Author.Name).FirstOrDefault()
            }).ToList();
            return View(res);
        }
    }
}