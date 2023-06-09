using Domain.Entities;

namespace Application.Repositories.Interfaces
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        Task<bool> ProductExists(string name);
        
    }
}