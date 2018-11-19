using Microsoft.EntityFrameworkCore;
using InventoryDAL.Entities;
using Microsoft.Extensions.Configuration;
using Npgsql;

namespace InventoryDAL.EF
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Good> Good { get; set; }
        public DbSet<GoodGroup> GoodGroup { get; set; }
        public DbSet<Department> Department { get; set; }

        public DbSet<InventoryDate> InventoryDate { get; set; }
        public DbSet<InventoryHead> InventoryHead { get; set; }
        public DbSet<InventoryBody> InventoryBody { get; set; }
        public DbSet<InventoryResult> InventoryResults { get; set; }

        public string ConnectionString {get;}

        public ApplicationContext(IConfiguration configuration) => ConnectionString = configuration.GetSection("ConnectionStrings:DefaultConnection")
           .Value;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connection = new  NpgsqlConnection(ConnectionString);
            optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            optionsBuilder.UseNpgsql(connection);
        }
    }
}
