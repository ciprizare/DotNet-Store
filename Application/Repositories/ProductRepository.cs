using Application.Repositories.Interfaces;
using Data;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        private readonly DataContext _context;
        public ProductRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        public async Task<bool> ProductExists(string name)
        {
            return await _context.Products.AnyAsync(p => p.Name == name);            
        }
    }
}