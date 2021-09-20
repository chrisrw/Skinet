using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    // ControllerBase
    // Route adds api/ onto all controllers (it's conventional)
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        //inject StoreContext into Products controller. Gives access to methods in class
        //what class do you want to inject (get methods from?) StoreContext 
        private readonly StoreContext _context;
        public ProductsController(StoreContext context)
        {
            _context = context;
        }

        [HttpGet]
        // specify type of what we return inside <> 
        // ActionResult = some kind of HTTP response status
        public async Task<ActionResult<List<Product>>> GetProducts()
        {
            var products = await _context.Products.ToListAsync();

            return Ok(products);

        }

        // help distinguish which endpoint using the id in the httpget
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            return await _context.Products.FindAsync(id);

        }

    }
}