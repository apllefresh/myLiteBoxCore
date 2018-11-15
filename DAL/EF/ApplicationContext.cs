using Microsoft.EntityFrameworkCore;
using DAL.Entities;
using Microsoft.Extensions.Configuration;
using Npgsql;

namespace DAL.EF
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Good> Goods { get; set; }
        public DbSet<GoodGroup> GoodGroups { get; set; }
        public DbSet<Department> Departments { get; set; }

        public DbSet<InventoryDate> inventorydate { get; set; }
        public DbSet<InventoryHead> inventoryhead { get; set; }
        public DbSet<InventoryBody> InventoryBodies { get; set; }
        public DbSet<InventoryResult> InventoryResults { get; set; }

        public string ConnectionString {get;}

        public ApplicationContext(IConfiguration configuration) => ConnectionString = configuration.GetSection("ConnectionStrings:DefaultConnection")
           .Value;

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    var connection = new SqliteConnection(ConnectionString);
        //    optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        //    optionsBuilder.UseSqlite(connection);
        //}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connection = new  NpgsqlConnection(ConnectionString);
            optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            optionsBuilder.UseNpgsql(connection);
        }
    }
}
