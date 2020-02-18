using BookLibrary.Data.Common.Models.BaseModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookLibrary.Models
{
    public class AuthorBooks: BaseDeletableModel<string>
    {
        public AuthorBooks()
        {
            this.Id = Guid.NewGuid().ToString();
        }
        public string AuthorId{ get; set; }
        public Author Author { get; set; }
        public string BookId { get; set; }
        public Book Book { get; set; }
    }
}
