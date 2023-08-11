using DOTNET_Training.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DOTNET_Training.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        private readonly IProductService _productService;
        public ProductController (IProductService productService)
        {
            _productService = productService;
        }

        // Get list of all products
        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetAllProducts()
        {
            var result = await _productService.GetAllProducts();
            return Ok(result);
        }

        // Get a single product using the product id
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetSingleProduct(int id)
        {
            var product = await _productService.GetSingleProduct(id);

            if (product == null)
                return NotFound("Product Not Found");
            return Ok(product);
        }

        // Add a product to the product list
        [HttpPost]
        public async Task<ActionResult<List<Product>>> AddProduct([FromBody]Product newProduct)
        {
            var result = await _productService.AddProduct(newProduct);
            return Ok(result);
        }

        // update a product
        [HttpPut("{id}")]
        public async Task<ActionResult<List<Product>>> UpdateProduct(int id, [FromBody] Product updatedProduct)
        {
            var result = await _productService.UpdateProduct(id, updatedProduct);

            if (result == null)
                return NotFound("Product Not Found");
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Product>>> DeleteProduct(int id)
        {
            var result = await _productService.DeleteProduct(id);

            if (result == null)
                return NotFound("Product Not Found");
            return Ok(result);
        }

    }
}
