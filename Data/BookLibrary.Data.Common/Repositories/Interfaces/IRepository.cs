using System;
using System.Collections.Generic;
using System.Text;

namespace BookLibrary.Data.Common.Repositories.Interfaces
{
    public interface IRepository<T,Tkey>
    {
        ICollection<T> GetAll(Func<T,bool> func=null);
        bool Add(T entity);
        bool Update(T entity);
        bool Delete(Tkey id);
        T FindById(Tkey id);
        int SaveChanges();
    }
}
