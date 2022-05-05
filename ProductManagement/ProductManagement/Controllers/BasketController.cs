using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using ProductManagement.DAL;
using ProductManagement.Models;
using ProductManagement.ToDoItems;
using System.ComponentModel.DataAnnotations;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Net.Mail;

namespace ProductManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {


        private readonly AppDbContext _context;
        public BasketController(AppDbContext context)
        {
            _context = context;
        }
        // GET: api/<BasketController>
        [HttpGet]
        public ActionResult<List<Basket>> Get()
        {
            var baskets = _context.Baskets.ToList();
            return baskets;
        }

        [HttpGet("Purchase")]
        public decimal Purchase()
        {
            decimal subtotal = 0;
            decimal total = 0;
            decimal taxRate = 0;

            var baskets = _context.Baskets.Include(b => b.Product).ToList();

            foreach (var item2 in baskets)
            {
                subtotal += Math.Round(Convert.ToDecimal(item2.Product.Price * item2.Count), 2);
                taxRate += Math.Round(Convert.ToDecimal(item2.Product.Price) / item2.Product.TaxRate, 2);
                total += Math.Round(Convert.ToDecimal(item2.Product.Price * item2.Count) + taxRate, 2);
            }
            // return Convert.ToDecimal($"'Subtotal {subtotal}'");

          

            return total;
        }
        // GET: api/<BasketController>
        //[HttpGet]
        //public async Task<ActionResult> Get2()
        //{
        //    List<BasketVM> dbBasket = new List<BasketVM>();
        //    // Product product=new Product();
        //    double total = 0;
        //    double price = 0;
        //    if (Request.Cookies["basket"] != null)
        //    {

        //        List<BasketVM> basket = JsonConvert.DeserializeObject<List<BasketVM>>(Request.Cookies["basket"]);

        //        foreach (BasketVM pro in basket)
        //        {
        //            Product dbProduct = await _context.Products.FindAsync(pro.Id);
        //            price = dbProduct.Price;
        //            pro.Price = dbProduct.Price * pro.Count;
        //            dbBasket.Add(pro);
        //            total += pro.Price;
        //        }
        //    }



        //    return StatusCode(StatusCodes.Status200OK, new Response { Status = "Success", Message = "Basket!" });
        //}


        // POST api/<BasketController>
        //[HttpGet("{id}")]
        //public async Task<IActionResult> AddBasket(int? id)
        //{
        //    if (id == 0) return NotFound();
        //    Product product = await _context.Products.FirstOrDefaultAsync(c => c.Id == id);
        //    if (product == null) return NotFound();
        //    List<BasketVM> basket;
        //    if (Request.Cookies["basket"] != null)
        //    {
        //        basket = JsonConvert.DeserializeObject<List<BasketVM>>(Request.Cookies["basket"]);
        //    }
        //    else
        //    {
        //        basket = new List<BasketVM>();
        //    }
        //    BasketVM isExist = basket.FirstOrDefault(p => p.Id == id);
        //    if (isExist == null)
        //    {
        //        basket.Add(new BasketVM
        //        {
        //            Id = (int)id,
        //            Count = 1
        //        });
        //    }
        //    else
        //    {
        //        isExist.Count += 1;
        //    }
        //    Response.Cookies.Append("basket", JsonConvert.SerializeObject(basket));

        //    return StatusCode(StatusCodes.Status200OK, new Response { Status = "Success", Message = "The product was added to the basket!" });

        //}

        //   POST api/<BasketController>/5

        [HttpPost("AddToBasket")]
        public async Task<IActionResult> AddBasket(BasketInputModel model)
        {
            var userBaskets = _context.Baskets.Where(x => x.UserID == model.UserId).ToList();
            if (userBaskets.Count() <= 0)
            {
                var basket = new Basket
                {
                    ProductId = model.ProductId,
                    Count = 1,
                    Product = _context.Products.FirstOrDefault(x => x.Id == model.ProductId),
                    UserID = model.UserId,
                };
                await _context.Baskets.AddAsync(basket);
            }
            else
            {
                var productInBasket = userBaskets.FirstOrDefault(x => x.ProductId == model.ProductId);
                if (productInBasket != null)
                {
                    productInBasket.Count += 1;
                }
                else
                {
                    var basket = new Basket
                    {
                        ProductId = model.ProductId,
                        Count = 1,
                        Product = _context.Products.FirstOrDefault(x => x.Id == model.ProductId),
                        UserID = model.UserId,
                    };
                    await _context.Baskets.AddAsync(basket);
                }
            }
            await _context.SaveChangesAsync();


            return StatusCode(StatusCodes.Status200OK, new Response { Status = "Success", Message = "Basket Added!" });
        }


        // DELETE api/<BasketController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> RemoveItem(int? id)
        {
            Basket basket = await _context.Baskets.FindAsync(id);

            _context.Baskets.Remove(basket);
            await _context.SaveChangesAsync();
            return StatusCode(StatusCodes.Status200OK, new Response { Status = "Success", Message = "Deleted!" });
        }
    
    }
}
