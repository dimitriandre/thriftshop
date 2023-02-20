using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Thriftshop.Models;
using ThriftshopWeb.Models;

namespace Thriftshop.DataAccess
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<ItemCondition> ItemConditions { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
