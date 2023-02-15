using Microsoft.EntityFrameworkCore;
using ThriftshopWeb.Models;

namespace ThriftshopWeb.DataAccess
{
    public class ApplicationDbContext :DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }

    }
}
