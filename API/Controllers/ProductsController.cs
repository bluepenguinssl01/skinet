using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Infrastructure.Data;
using Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class ProductsController : ControllerBase
    {
        private readonly StoreContext _context;
        public ProductsController(StoreContext context)
        {
            this._context = context;
        }

        [HttpGet]
       
        public async Task<ActionResult<List<Product>>> GetProducts()
        {

            var products = await _context.Products.ToListAsync();

            return Ok(products);
           
        }

        // public string GetProducts()
        // {
        //     return "This will be a List of Products.";
        // }

        [HttpGet("{id}")]

public async Task<ActionResult<Product>> GetProduct(int Id)
{
    return await _context.Products.FindAsync(Id);
}

        // public string GetProduct(int id)
        // {
        //     return "Single Product.";
        // }

    }
}