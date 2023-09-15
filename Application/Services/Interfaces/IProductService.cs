using Application.Models;
using Domain.Entities;

namespace Application.Services.Interfaces
{
    public interface IProductService
    {
      Task<ProductDTO?> GetProduct (int id);
      Task<IEnumerable<ProductDTO>> GetAllProducts ();
      Task<bool> AddProduct (ProductDTO product);
      Task<bool> UpdateProduct (int id, UpsertProductDTO product);
      Task<ProductDTO?> PatchProduct (int id, PatchProductDTO product);
      Task<bool> RemoveProduct(int id);
      Task<bool> ProductExists(string productName);
    }
}