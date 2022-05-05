using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductManagement.DAL;
using ProductManagement.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProductManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly AppDbContext _context;
        public ProductController(AppDbContext context)
        {
            _context = context;
        }
        // GET: api/<ProductController>
        [HttpGet]
        public ActionResult<List<Product>> Get()
        {
            var products = _context.Products.Where(p => p.Status == true).ToList();

            return products;
        }

        // GET api/<ProductController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> Get(int id)
        {
            Product product = await _context.Products.FindAsync(id);
            if (product == null) return StatusCode(StatusCodes.Status404NotFound, new Response { Status = "Error", Message = "Product NotFound!" });
            return product;
        }

        

        // POST api/<ProductController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Product product)
        {
            Product products = new Product
            {
                Name = product.Name,
                Price = product.Price,
                Description = product.Description,
                Count = product.Count,
                Status = true,
                TaxRate = product.TaxRate,  
                Code=product.Code,
                CreatedDate = DateTime.Now,
                DeletedDate = null,
            };
            
            await _context.AddAsync(products);
            await _context.SaveChangesAsync();
            return StatusCode(StatusCodes.Status200OK, new Response { Status = "Success", Message = "Product created successfully!" });
        }

        // PUT api/<ProductController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] Product product)
        {
            Product dbproduct = await _context.Products.FindAsync(id);
            if (dbproduct == null) return NotFound();

            dbproduct.Name = product.Name;
            dbproduct.Price = product.Price;
            dbproduct.Description = product.Description;
            dbproduct.Count = product.Count;
            dbproduct.Status = true;
            dbproduct.TaxRate = product.TaxRate;
            dbproduct.Code = product.Code;
            dbproduct.CreatedDate=product.CreatedDate;
            dbproduct.DeletedDate = product.DeletedDate;
          
            await _context.SaveChangesAsync();
            return StatusCode(StatusCodes.Status200OK, new Response { Status = "Success", Message = "Updated!" });
        }

        // DELETE api/<ProductController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            Product product = await _context.Products.FindAsync(id);
            product.CreatedDate = product.CreatedDate;
            product.Status = false;
            product.DeletedDate = DateTime.Now; 
          //  _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return StatusCode(StatusCodes.Status200OK, new Response { Status = "Success", Message = "Deleted!" });
        }


    }
}
