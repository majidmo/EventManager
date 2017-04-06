using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EventManager.Models;

namespace EventManager.Repository
{
    public interface IRepository<T> where T : BaseEntity
    {
        void Add(T item);
        void Remove(int id);
        void Update(T item);
        T FindByID(int id);
        IEnumerable<T> FindAll();
    }
}
