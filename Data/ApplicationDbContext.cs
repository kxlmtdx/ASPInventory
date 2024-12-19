using Microsoft.EntityFrameworkCore;
using ASPInventory.Models;

namespace ASPInventory.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }
        public DbSet<DataSet> Categories { get; set; }
    }
}
