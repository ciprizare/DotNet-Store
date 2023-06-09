using Application.Repositories.Interfaces;
using Data;
using Microsoft.EntityFrameworkCore;

namespace Application.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly DataContext _context;
        public GenericRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<bool> Add(T entity)
        {
            _context.Set<T>().Add(entity);
            return await SaveChanges();
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T?> GetById(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<bool> Remove(T entity)
        {
            _context.Set<T>().Remove(entity);
            return await SaveChanges();
        }

        public async Task<bool> SaveChanges()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> Update(T entity)
        {
            _context.Set<T>().Update(entity);
            return await SaveChanges();
        }
    }
}