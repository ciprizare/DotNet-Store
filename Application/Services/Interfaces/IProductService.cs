using Domain.Entities;

namespace Application.Services.Interfaces
{
    public interface IProductService
    {
      Task<Product?> GetProduct (int id);
      Task<IEnumerable<Product>> GetAllProducts ();
      Task<bool> AddProduct (Product product);
      Task<bool> UpdateProduct (Product product);
      Task<bool> RemoveProduct(Product product);
      Task<bool> ProductExists(string productName);
    }
}