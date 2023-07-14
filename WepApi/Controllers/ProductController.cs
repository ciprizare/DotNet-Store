using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Services.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace WepApi.Controllers
{
    [ApiController]
    [Route ("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _service;
        public ProductController(IProductService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            var products = await _service.GetAllProducts();
            if (products == null || !products.Any()) 
            {
                return NotFound();
            }
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(int id)
        {
            var product = await _service.GetProduct(id);
            if (product == null) 
            {
                return NotFound();
            }
            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct(Product product)
        {
            var newProduct = await _service.AddProduct(product);
            if (!newProduct)
                return BadRequest();
            return Ok(product);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct([FromRoute] int id, [FromBody] Product product)
        {
            var updatedProd = await _service.GetProduct(id);
            if (updatedProd == null) 
            {
                return NotFound();
            }

            updatedProd.Name = product.Name;
            updatedProd.Description = product.Description;
            updatedProd.Price = product.Price;
            updatedProd.PictureUrl = product.PictureUrl;
            updatedProd.QuantityInStock = product.QuantityInStock;
            updatedProd.Brand = product.Brand;
            updatedProd.Type = product.Type;

            var updateProduct = await _service.UpdateProduct(updatedProd);

            if (!updateProduct)
                return BadRequest();

            return Ok(updatedProd);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveProduct(int id)
        {
            var product = await _service.GetProduct(id);
            if (product == null)
                return NotFound();
            var removedProduct = await _service.RemoveProduct(product);

            if (!removedProduct) 
                return BadRequest();

            return Ok();
        }

    }

}