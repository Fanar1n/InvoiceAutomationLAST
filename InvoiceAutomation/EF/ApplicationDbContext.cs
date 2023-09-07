using InvoiceAutomation.Models;
using Microsoft.EntityFrameworkCore;

namespace InvoiceAutomation.EF
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Invoice> Invoice { get; set; }

        public ApplicationDbContext(DbContextOptions options)
            : base(options)
        {
            Database.Migrate();
        }
    }
}
