using BrainBoxAPI.Data;
using BrainBoxAPI.DTO;
using BrainBoxAPI.Models;
using BrainBoxAPI.Services.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace BrainBoxAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
       private readonly IProductService _productService;
        
        private readonly ProductDbContext _productDbContext;

        public ProductController(IProductService productService,  ProductDbContext productDbContext)
        {

            _productService = productService ?? throw new ArgumentNullException();
            


            _productDbContext = productDbContext;
        }

        //  [Authorize(Roles = "ADMIN")]
        [HttpPost]
        public async Task<ActionResult<Product>> AddProduct(AddProductDto addProduct)
        {
            var mapProductToDto = new Product()
            {
                Name = addProduct.Name,
                Cost = addProduct.Cost,
                Category = addProduct.Category,
            };

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var productAdd = await _productService.AddProductAsync(mapProductToDto);
            return Ok(productAdd);

        }

        //  [Authorize(Roles = "ADMIN")]
        [HttpDelete("delete/{id}")]
        public async Task<ActionResult> DeleteProduct(int id)
        {
            if (id <= 0)
            {
                return BadRequest("This is not a valid id");
            }
            else
            {
                var delete = await _productService.DeleteProductAsync(id);
                if (delete > 0)
                {
                    return NoContent();
                }
                else { return NotFound($"Product not found"); }
            }
        }

        // [Authorize]
        [HttpPut("update/{id}")]
        public async Task<ActionResult> UpdateProduct(UpdateProductDto updateProducttDto, int id)
        {
            var mapUpdateItem = new Product()
            {
                Id = id,
                Name = updateProducttDto.Name,
                Cost = updateProducttDto.Cost,
                Category = updateProducttDto.Category,
            };
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var updateItem = await _productService.UpdateProductAsync(mapUpdateItem);
            if (updateItem > 0)
            {
                return NoContent();
            }
            else
            {
                return BadRequest(ModelState);
            }

        }

        //  [Authorize(Roles = "ADMIN")]
        [HttpGet("search")]
        public async Task<ActionResult<IEnumerable<ProductDto>>> SearchProduct(string search)
        {
            var productTosearch = await _productService.SearchProductAsync(search);
            if (productTosearch == null)
            {
                return NotFound(productTosearch);
            }
            return Ok(productTosearch);
        }

        //   [Authorize(Roles = "ADMIN,USER")]
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDto>> GetSingleProductById(int id)
        {
            var product = await _productService.GetProductAsync(id);
            if (product == null)
            {
                return NotFound(product);
            }
            return Ok(product);
        }
       // [Authorize]
        //  [Authorize(Roles = "ADMIN, USER")]
        [HttpGet("all")]
        public async Task<ActionResult<IEnumerable<Product>>> GetAllProduct()
        {

            return Ok(await _productService.GetAllProductAsync());

        }


    }
}
