using Microsoft.EntityFrameworkCore;
using Inventory.DAL.Contract.Models;
using Microsoft.Extensions.Configuration;
using Npgsql;

namespace Inventory.DAL.EF
{
    public class DataAccessContext : DbContext
    {
        public DbSet<InventoryDate> InventoryDates { get; set; }
        public DbSet<InventoryHead> InventoryHeads { get; set; }
        public DbSet<InventoryBody> InventoryBody { get; set; }
        public DbSet<InventoryResult> InventoryResult { get; set; }

        public string ConnectionString { get; }

        public DataAccessContext(IConfiguration configuration) => ConnectionString = configuration.GetSection("ConnectionStrings:DefaultConnection")
           .Value;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connection = new NpgsqlConnection(ConnectionString);
            optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            optionsBuilder.UseNpgsql(connection);
        }
    }
}
