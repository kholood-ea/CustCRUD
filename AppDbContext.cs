using Microsoft.EntityFrameworkCore;

namespace CustCRUD
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions options):base(options)
        {

        }
        public DbSet<Customer> Customer { get; set; }
    }
}