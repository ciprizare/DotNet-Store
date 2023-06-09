using Application.Repositories.Interfaces;
using Application.Services.Interfaces;
using Domain.Entities;

namespace Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repo;
        public ProductService(IProductRepository repo)
        {
            _repo = repo;
        }

        public async Task<Product?> GetProduct (int id) 
        {
           return await _repo.GetById(id);   
        }

        public async Task<IEnumerable<Product>> GetAllProducts ()
        {
            return await _repo.GetAll();
        }

        public async Task<bool> AddProduct (Product product)
        {
            return await _repo.Add(product);
        }

        public async Task<bool> UpdateProduct (Product product)
        {
            return await _repo.Update(product);
        }

        public async Task<bool> RemoveProduct(Product product)
        {
            return await _repo.Remove(product);
        }

        public async Task<bool> ProductExists(string productName)
        {
            return await _repo.ProductExists(productName);
        }
    }
}