using BookLibrary.Data.Common.Models.BaseModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookLibrary.Models
{
    public class UserBooks: BasePeriodModel<string>
    {
        public UserBooks()
        {
            this.Id = Guid.NewGuid().ToString();
        }
        public string UserId { get; set; }
        public User User { get; set; }
        public string BookId { get; set; }
        public Book Book { get; set; }
    }
}
