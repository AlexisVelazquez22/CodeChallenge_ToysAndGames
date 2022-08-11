using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using Services.ViewModels;

namespace CodeChallenge_WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public IActionResult GetProducts()
        {
            try
            {
                return Ok(_productService.Get());
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct([FromBody] ProductRequest model)
        {
            try
            {
                var product = await _productService.Add(model);
                return StatusCode(StatusCodes.Status201Created, product);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditProduct([FromBody] ProductRequest model, [FromRoute] int id)
        {
            try
            {
                var editedProduct = await _productService.Edit(model, id);
                return (editedProduct != null) ? Ok(editedProduct) : NotFound();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct([FromRoute] int id)
        {
            try
            {
                var productDeleted = await _productService.Delete(id);
                return (productDeleted == true) ? NoContent() : NotFound();          
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

    }
}
