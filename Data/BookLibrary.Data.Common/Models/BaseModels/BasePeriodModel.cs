﻿using BookLibrary.Data.Common.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BookLibrary.Data.Common.Models.BaseModels
{
    public abstract class BasePeriodModel<Tkey> : IPeriodInfo
    {
        [Key]
        public Tkey Id { get; set; }
        public DateTime TakenAt { get; set; }
        public DateTime? ReturnedAt { get; set; }
    }
}