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
        //Replace YOUR_DB before run
        public DbSet<DataSet> YOUR_DB { get; set; }


    }
}
