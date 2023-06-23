using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Services.Interfaces;
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
            if (products == null) 
            {
                return NotFound();
            }
            return Ok(products);
        }
    }

}