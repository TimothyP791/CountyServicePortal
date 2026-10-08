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
        public DbSet<Civilian> Civilians { get; set; } // DbSet for the Civilian entity
        public DbSet<Employee> Employees { get; set; } // DbSet for the Employee entity
    }
}
