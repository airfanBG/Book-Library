using BookLibrary.Data.Common.Models.BaseModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BookLibrary.Models
{
   
    public class Book: BaseDeletableModel<string>
    {
        public Book()
        {
            Comments = new HashSet<Comment>();
            AuthorBooks = new HashSet<AuthorBooks>();
            UserBooks = new HashSet<UserBooks>();
            this.Id = Guid.NewGuid().ToString();
        }
        [Required]
        [MinLength(2)]
        [MaxLength(100)]
        [Column("Book_Name",Order =2)]       
        public string BookName { get; set; }

        [MinLength(1)]
        [Column("Book_Pages", Order = 3)]
        public int BookPages { get; set; }

        [Column("Book_Annotation", Order = 4)]
        public string BookAnnotation { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<AuthorBooks> AuthorBooks { get; set; }
        public virtual ICollection<UserBooks> UserBooks { get; set; }
    }
}
