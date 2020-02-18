using BookLibrary.Data.Common.Models.Interfaces;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookLibrary.Models
{
    public class Role : IdentityRole, IAuditInfo, IDeletableEntity
    {
        public Role():this(null)
        {

        }
        public Role(string name):base(name)
        {

        }
        public DateTime CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
    }
}
