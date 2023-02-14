using Microsoft.EntityFrameworkCore;
using ThriftshopWeb.Models;

namespace ThriftshopWeb.Data
{
    public class ApplicationDbContext :DbContext
    {
        public ApplicationDbContext(DbContext<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }

    }
}
