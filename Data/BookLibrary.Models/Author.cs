using BookLibrary.Data.Common.Models.BaseModels;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BookLibrary.Models
{
    public class Author: BaseDeletableModel<string>
    {
        public Author()
        {
            AuthorBooks = new HashSet<AuthorBooks>();
            this.Id = Guid.NewGuid().ToString();
        }
        [Required(ErrorMessage ="Author name is required!")]
        [MaxLength(30)]
        public string Name { get; set; }
        [MaxLength(1000)]
        public string Biography { get; set; }
        public virtual ICollection<AuthorBooks> AuthorBooks { get; set; }
    }
}