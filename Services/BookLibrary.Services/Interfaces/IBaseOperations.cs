using BookLibrary.Data.Common.Models.BaseModels;
using BookLibrary.Data.Common.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookLibrary.Services.Interfaces
{
    public interface IBaseOperations<T> where T: IAuditInfo
    {
        public bool Add(T model);
        public bool Update(T model);
        public IQueryable<T> All(Func<T, bool> func = null);
        public bool Delete(object id);
      
    }
}
