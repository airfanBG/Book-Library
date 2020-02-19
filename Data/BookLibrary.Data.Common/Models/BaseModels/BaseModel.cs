using BookLibrary.Data.Common.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BookLibrary.Data.Common.Models.BaseModels
{
    public abstract class BaseModel<Tkey> : IAuditInfo
    {

        [Key]
        public Tkey Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }
    }
}
