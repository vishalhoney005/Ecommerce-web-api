using ecommerce_web_api.Models;
using ecommerce_web_api.Services.Categories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ecommerce_web_api.Controllers
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
        //get category by id
        [HttpGet]
        public ActionResult<List<Category>> GetAlllCategories()
        {
            var data= _categoryService.GetCategories();
            return Ok(data);
        }
        [HttpGet("{id}")]
        public ActionResult GetCategoryById(int id) 
        {
            var data = _categoryService.GetCategoryById(id);
            if(data == null)
                return NotFound("no category found with Id: "+ id);
            return Ok(data);
        }
        //Add
        [HttpPost]
        public ActionResult<Category> PostCategory([FromBody] Category category)
        {
            var data = _categoryService.AddCategory(category);
            if (data == null)
                return BadRequest();
            return Created("",data);
        }
        //update
        [HttpPut("{id}")]
        public ActionResult<Category> PutCategory(int id, [FromBody] Category category)
        {
            var data = _categoryService.GetCategoryById(id);
            if (data == null)
                return NotFound("no category found with Id: " + id);
            var response = _categoryService.UpdateCategory(id, category);
            return Ok(data);
        }

        //delete category
        [HttpDelete("{id}")]
        public ActionResult DeleteCategory(int id)
        {
            var data = _categoryService.GetCategoryById(id);
            if (data == null)
                return NotFound("No Category Found with Id: " + id);
            _categoryService.DeleteCategory(id);
            return Ok("category deleted");
        }
    }
}