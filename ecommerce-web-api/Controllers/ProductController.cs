using ecommerce_web_api.Models;
using ecommerce_web_api.Services.Products;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ecommerce_web_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        // GET: api/<ProductController>
        [HttpGet]
        public ActionResult<List<Product>> Get()
        {
            var data= _productService.GetProducts();
            return Ok(data);
        }

        // GET api/<ProductController>/5
        [HttpGet("{id}")]
        public ActionResult GetByProductId(int id)
        {
            var data= _productService.GetProductById(id);
            if (data == null) 
            {
                return NotFound("No Product Found with id:"+id);
            }
            return Ok(data);
        }

        // GET api/<ProductController>/5
        [HttpGet("category/{catId}")]
        public ActionResult<List<Product>> GetByProductByCatId(int catId)
        {
            var data = _productService.GetProductByCatId(catId);
            if (data == null)
            {
                return NotFound("No Product Found with catid:" + catId);
            }
            return Ok(data);
        }

        // POST api/<ProductController>
        [HttpPost("{catid}")]
        public ActionResult Post([FromBody] Product product,int catid)
        {
            var data= _productService.AddProduct(product,catid);
            if (data == null)
            {  return BadRequest(); }
            return Created("",data);
        }

        // PUT api/<ProductController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Product product)
        {
            var data= _productService.GetProductById(id);
            if (data == null)
            {
                return NotFound("No Product Found with id: "+id);
            }
            var response= _productService.UpdateProduct(id, product);
            return Ok(data);
        }

        // DELETE api/<ProductController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var data =_productService.GetProductById(id);
            if(data == null)
            {
                return NotFound("No Product Found with id: " + id);
            }
            _productService.DeleteProduct(id);
            return Ok("Product Deleted");

        }
    }
}
