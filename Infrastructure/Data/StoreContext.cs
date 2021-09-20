using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class StoreContext : DbContext
    {
        // tell DBContext what type we pass (Name of our class)
        public StoreContext(DbContextOptions<StoreContext> options) : base(options)
        {
        }
        // Add properties Products = name of table that gets created 
        public DbSet<Product> Products{ get; set; }
    }
}