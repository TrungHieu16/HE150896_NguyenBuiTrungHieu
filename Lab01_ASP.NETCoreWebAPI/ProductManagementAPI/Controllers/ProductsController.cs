using BusinessObjects;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repositories;

namespace ProductManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private IProductRepository repository = new ProductRepository();

        [HttpGet]

        public ActionResult<IEnumerable<Products>> GetProducts() => repository.GetProducts();

        [HttpPost]
        public IActionResult PostProduct(Products p)
        {
            repository.SaveProduct(p);
            return NoContent();
        }
        [HttpDelete("id")]
        public IActionResult DeleteProduct(int id)
        {
            var p = repository.GetProductsById(id);
            if(p==null)
                return NotFound();
            repository.DeleteProduct(p);
            return NoContent();
        }
        [HttpPut("id")]
        public IActionResult UpdateProduct(int id, Products p)
        {
            var pTmp = repository.GetProductsById(id);
            if(p == null)
                return NotFound();
            repository.UpdateProduct(p);
            return NoContent();
        }
    }
}
