using Infrastructure.Data;
using EcommerceApi.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Core.Interfaces;

namespace EcommerceApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _ProductRepository;
        public ProductController(IProductRepository productRepository)
        {
            _ProductRepository = productRepository;
        }
        [HttpGet]
        public async Task< ActionResult<List<Product>>>  GetProducts()
        {
            var products= await _ProductRepository.GetProducts();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var product=await _ProductRepository.GetProductById(id);
            return Ok(product);
        }
    }
}
