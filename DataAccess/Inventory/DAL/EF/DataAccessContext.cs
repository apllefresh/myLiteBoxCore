using Microsoft.EntityFrameworkCore;
using Inventory.DAL.Contract.Models;
using Microsoft.Extensions.Configuration;
using Npgsql;

namespace Inventory.DAL.EF
{
    public class DataAccessContext : DbContext
    {
        private readonly string _connectionString;

        public DataAccessContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        public DbSet<InventoryDate> InventoryDates { get; set; }
        public DbSet<InventoryHead> InventoryHeads { get; set; }
        public DbSet<InventoryBody> InventoryBody { get; set; }
        public DbSet<InventoryResult> InventoryResult { get; set; }
        public DbSet<InventorySpace> InventorySpace { get; set; }
        public DbSet<InventoryDateToSpaceMap> InventoryDateToSpaceMap { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connection = new NpgsqlConnection(_connectionString);
            optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            optionsBuilder.UseNpgsql(connection);
        }
    }
}

