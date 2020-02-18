using BookLibrary.Data.Common.Models.Interfaces;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BookLibrary.Models
{
    public class User : IdentityUser, IAuditInfo, IDeletableEntity
    {
        public User()
        {
            UserBooks = new HashSet<UserBooks>();
            this.Id = Guid.NewGuid().ToString();
        }
       

        public string EmployeeId { get; set; }
        [Required]
        [Column("First_Name")]
        [MinLength(2)]
        [MaxLength(20)]
        public string FirstName { get; set; }
        [Required]
        [Column("Last_Name")]
        [MinLength(2)]
        [MaxLength(20)]
        public string LastName { get; set; }
        public DateTime? DeletedAt { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }

        public virtual Employee Employee { get; set; }
        public virtual ICollection<UserBooks> UserBooks { get; set; }
       
    }
}
