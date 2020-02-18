using System;
using System.Collections.Generic;
using System.Text;

namespace BookLibrary.Data.Common.Models.Interfaces
{
    public interface IAuditInfo
    {
        public DateTime CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }
    }
}
