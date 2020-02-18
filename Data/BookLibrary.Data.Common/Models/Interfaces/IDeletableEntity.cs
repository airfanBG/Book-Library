using System;
using System.Collections.Generic;
using System.Text;

namespace BookLibrary.Data.Common.Models.Interfaces
{
    public interface IDeletableEntity
    {
        public DateTime? DeletedAt { get; set; }
    }
}
