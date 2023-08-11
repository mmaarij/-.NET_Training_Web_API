using DOTNET_Training.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DOTNET_Training.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        // Get list of all categories
        [HttpGet]
        public async Task<ActionResult<List<Category>>> GetAllCategories()
        {
            var result = await _categoryService.GetAllCategories();
            return Ok(result);
        }

        // Get a single category using the id
        [HttpGet("{id}")]
        public async Task<ActionResult<Category>> GetSingleCategory(int id)
        {
            var category = await _categoryService.GetCategoryById(id);

            if (category == null)
                return NotFound("Category Not Found");
            return Ok(category);
        }

        // Add a category or get one if it already exists
        [HttpPost]
        public async Task<ActionResult<Category>> AddOrGetCategory([FromBody] Category newCategory)
        {
            var result = await _categoryService.GetOrCreateCategory(newCategory);
            return Ok(result);
        }

        // update a product
        [HttpPut("{id}")]
        public async Task<ActionResult<List<Category>>> UpdateCategory(int id, [FromBody] Category updatedCategory)
        {
            var result = await _categoryService.UpdateCategory(id, updatedCategory);

            if (result == null)
                return NotFound("Category Not Found");
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Category>>> DeleteCategory(int id)
        {
            var result = await _categoryService.DeleteCategory(id);

            if (result == null)
                return NotFound("Category Not Found");
            return Ok(result);
        }
    }
}
