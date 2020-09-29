using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Teste_WebMotors.Core.Interfaces.Repository;

namespace Teste_WebMotors.Infrastructure.Persistence.Repositories
{
    public class EFRepository<T> : IRepository<T> where T:class
    {

        protected readonly Context _dbContext;

        public EFRepository(Context dbContext)
        {
            _dbContext = dbContext;
        }

        public virtual void Add(T obj)
        {
            _dbContext.Set<T>().Add(obj);
            _dbContext.SaveChanges();
        }

        public void Delete(T obj)
        {
             _dbContext.Set<T>().Remove(obj);
             _dbContext.SaveChanges();
        }

        public IEnumerable<T> GetAll()
        {
            return _dbContext.Set<T>().AsEnumerable();
        }

        public virtual T GetById(int id)
        {
            return _dbContext.Set<T>().Find(id);
        }

        public virtual void update(T obj)
        {
            _dbContext.Entry(obj).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }
    }
}
