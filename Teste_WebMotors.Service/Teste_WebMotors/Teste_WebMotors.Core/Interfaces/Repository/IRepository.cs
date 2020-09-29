using System.Collections.Generic;

namespace Teste_WebMotors.Core.Interfaces.Repository
{
    public interface IRepository<T> where T:class
    {
        void Add(T obj);
        void Delete(T obj);
        IEnumerable<T> GetAll();
        T GetById(int id);
        void update(T obj);
    }
}
