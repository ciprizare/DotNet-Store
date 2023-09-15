using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Models;
using Application.Services;
using Application.Services.Interfaces;
using AutoMapper;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace WepApi.Controllers
{
    [ApiController]
    [Route ("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _service;
        private readonly IMapper _mapper;

        public ProductController(IProductService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            var productsDTOs = await _service.GetAllProducts();
            if (productsDTOs == null || !productsDTOs.Any()) 
            {
                return NotFound();
            }

            return Ok(productsDTOs);
        }

        [HttpGet("{id}", Name = "GetProductById")]
        public async Task<IActionResult> GetProductById([FromRoute] int id)
        {
            var productDTO = await _service.GetProduct(id);
            if (productDTO == null) 
            {
                return NotFound();
            }
            return Ok(productDTO);
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct(ProductDTO product)
        {
            var isAdded = await _service.AddProduct(product);
            if (!isAdded)
                return BadRequest();
                
            return CreatedAtRoute("GetProductById", new { id = product.Id }, product);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct([FromRoute] int id, [FromBody] UpsertProductDTO productDTO)
        {            
            var updateProduct = await _service.UpdateProduct(id, productDTO);

            if (!updateProduct)
                return BadRequest();

            return Ok(productDTO);
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> PatchProduct([FromRoute] int id, [FromBody] PatchProductDTO productDTO)
        {            
            var patchProduct = await _service.PatchProduct(id, productDTO);

            if (patchProduct == null)
                return BadRequest();

            return Ok(patchProduct);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveProduct(int id)
        {            
            var removedProduct = await _service.RemoveProduct(id);

            if (!removedProduct) 
                return BadRequest();

            return Ok();
        }
    }

}