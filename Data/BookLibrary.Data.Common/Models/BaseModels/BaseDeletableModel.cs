using BookLibrary.Data.Common.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookLibrary.Data.Common.Models.BaseModels
{
    public abstract class BaseDeletableModel<TKey> : BaseModel<TKey>, IDeletableEntity
    {
        public DateTime? DeletedAt { get; set; }
    }
}
