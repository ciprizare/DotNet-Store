using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Repositories.Interfaces
{
    public interface IGenericRepository<T> where T:class
    {
        Task<T?> GetById(int id);
        Task<IEnumerable<T>> GetAll();
        Task<bool> Add(T entity);
        Task<bool> Update(T entity);
        Task<bool> Remove(T entity);
        Task<bool> SaveChanges();
    }
}