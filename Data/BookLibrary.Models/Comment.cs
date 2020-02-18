using BookLibrary.Data.Common.Models.BaseModels;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookLibrary.Models
{
    public class Comment: BaseDeletableModel<string>
    {
        public Comment()
        {
            this.Id = Guid.NewGuid().ToString();
        }
        [Column("Comment_Text")]
        [MaxLength(500)]
        public string CommentText { get; set; }
        public Book Book { get; set; }
    }
}