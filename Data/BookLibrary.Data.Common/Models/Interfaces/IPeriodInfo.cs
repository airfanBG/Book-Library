using System;
using System.Collections.Generic;
using System.Text;

namespace BookLibrary.Data.Common.Models.Interfaces
{
    public interface IPeriodInfo
    {
        public DateTime TakenAt { get; set; }
        public DateTime? ReturnedAt { get; set; }
    }
}
