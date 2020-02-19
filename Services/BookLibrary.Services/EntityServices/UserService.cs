
using BookLibrary.Data.Common.Models.Interfaces;
using BookLibrary.Data.Repository;
using BookLibrary.Models;
using BookLibrary.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace BookLibrary.Services.EntityServices
{
    public class UserService : IBaseOperations<User>
    {
        private DbContext context;
        public UserService(DbContext db)
        {
            context = db;
        }

        public bool Add(User model)
        {
            try
            {
                context.Set<User>().Add(model);
                var res=context.SaveChanges();
                return res == 1 ? true : false; 
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            
        }

        public IQueryable<User> All(Func<User, bool> func = null)
        {
            try
            {
                if (func!=null)
                {
                    return context.Set<User>().Where(func).AsQueryable();
                }
                return context.Set<User>().AsQueryable();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool Delete(object id)
        {
            try
            {
                var model=context.Set<User>().First(x => (object)x.Id == id);
                context.Set<User>().Remove(model);
                var res = context.SaveChanges();
                return res == 1 ? true : false;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool Update(User model)
        {
            try
            {
                var entity = context.Set<User>().Find(model);
                context.Set<User>().Update(model);

                var res = context.SaveChanges();
                return res == 1 ? true : false;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
