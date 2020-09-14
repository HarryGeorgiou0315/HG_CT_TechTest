using Microsoft.EntityFrameworkCore;

namespace HG_CT_TechTest.DatabaseInfrastructure
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions options) : base(options)
        {

        }
        
        public DbSet<Messages> Messages { get; set; }

    }
}
