using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FabricShop.Data;
using FabricShop.Data.Entities;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using FabricShop.Services;

namespace FabricShop.Controllers
{
    [Produces("application/json")]
    [Route("api/Products")]
    public class ProductsController : Controller
    {
        private readonly Db _context;
        private UserManager<ApplicationUser> _userManager;
        private readonly ProductService _productService;
        public ProductsController(Db context, UserManager<ApplicationUser> userManager, ProductService productService)
        {
            _context = context;
            _userManager = userManager;
            _productService = productService;
        }

        private  Task<ApplicationUser> GetCurrentUserAsync() =>  _userManager.GetUserAsync(HttpContext.User);
        

        // GET: api/Products
        [HttpGet]
        public IActionResult GetProducts()
        {
            var userMail = User.FindFirstValue(ClaimTypes.Email);

            return Json(_productService.GetAll(userMail));
        }

        // GET: api/Products/5
        [HttpGet("{id}")]
        public IActionResult GetProduct([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var product = _productService.GetProduct(id);

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        // PUT: api/Products/{}
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct([FromRoute] string id, [FromBody] Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != product.ProductId)
            {
                return BadRequest();
            }

            _context.Entry(product).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_productService.ProductExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Products
        [HttpPost]
        public async Task<IActionResult> PostProduct([FromBody] Product product)
        {
            var userMail = User.FindFirstValue(ClaimTypes.Email);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            product.VendorName = userMail;
            _productService.AddProduct(product);

            return CreatedAtAction("GetProduct", new { id = product.ProductId }, product);
        }

        // DELETE: api/Products/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var product = _productService.GetProduct(id);
            if (product == null)
            {
                return NotFound();
            }
            _productService.DeleteProduct(product);

            return Ok(product);
        }

        
    }
}