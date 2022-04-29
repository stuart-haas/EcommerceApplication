using EcommerceApplication.Models;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceApplication.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository productRepository;

        public ProductsController(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        [HttpGet]
        public async Task<ActionResult<Product>> GetProducts()
        {
            try
            {
                return Ok(await productRepository.GetProducts());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retreiving data from database");
            }
        }

        [HttpPost]
        public async Task<ActionResult<Product>> CreateProduct(Product product)
        {
            try
            {
                if(product == null)
                {
                    return BadRequest();
                }

                var createdProduct = await productRepository.CreateProduct(product);

                return CreatedAtAction(nameof(CreateProduct), new { id = createdProduct.Id }, createdProduct);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retreiving data from database");
            }
        }
    }
}