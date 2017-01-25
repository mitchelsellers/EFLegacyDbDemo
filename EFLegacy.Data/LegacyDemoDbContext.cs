using System.Data.Entity;
using EFLegacy.Data.Models;

namespace EFLegacy.Data
{
    public class LegacyDemoDbContext : DbContext
    {
        public LegacyDemoDbContext() : base("DemoConnection")
        {
            //Disable database initialization
            Database.SetInitializer(new NullDatabaseInitializer<LegacyDemoDbContext>());
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<CustomerAddress> Addresses { get; set; }
    }
}