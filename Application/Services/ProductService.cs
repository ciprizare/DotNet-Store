using Application.Models;
using Application.Repositories.Interfaces;
using Application.Services.Interfaces;
using AutoMapper;
using Domain.Entities;

namespace Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repo;
        private readonly IMapper _mapper;
        
        public ProductService(IProductRepository repo, IMapper mapper)
        {
            _mapper = mapper;
            _repo = repo;
        }

        public async Task<ProductDTO?> GetProduct (int id) 
        {
           var product = await _repo.GetById(id);
           if (product == null) {
            return null;
           }
           return _mapper.Map<Product,ProductDTO>(product);
        }

        public async Task<IEnumerable<ProductDTO>> GetAllProducts()
        {
            var products = await _repo.GetAll();
            var productDTO = _mapper.Map<IEnumerable<Product>,IEnumerable<ProductDTO>>(products);

            return productDTO;
        }


        public async Task<bool> AddProduct (ProductDTO productDTO)
        {
            var product = _mapper.Map<ProductDTO, Product>(productDTO);
            return await _repo.Add(product);
        }

        public async Task<bool> UpdateProduct (int id, UpsertProductDTO productDTO)
        {
            var updatedProd = await _repo.GetById(id);
            if (updatedProd == null) 
            {
                return false;
            }

            updatedProd = _mapper.Map(productDTO, updatedProd);

            return await _repo.Update(updatedProd);
        }

        public async Task<ProductDTO?> PatchProduct(int id, PatchProductDTO patchedProductDTO)
        {
            var patchedProd = await _repo.GetById(id);
            if (patchedProd == null) 
            {
                return null;
            }

            patchedProd = _mapper.Map(patchedProductDTO, patchedProd);

            await _repo.Update(patchedProd);

            var productDTO = _mapper.Map<Product, ProductDTO>(patchedProd);

            return productDTO;
        }

        public async Task<bool> RemoveProduct(int id)
        {
            var product = await _repo.GetById(id);

            if (product == null) {
                return false;
            }

            return await _repo.Remove(product);
        }

        public async Task<bool> ProductExists(string productName)
        {
            return await _repo.ProductExists(productName);
        }
    }
}