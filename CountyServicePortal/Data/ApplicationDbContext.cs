using Microsoft.EntityFrameworkCore;
using CountyServicePortal.Models;

namespace CountyServicePortal.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(
            DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<ServiceRequest> ServiceRequests { get; set; }
    }
}
