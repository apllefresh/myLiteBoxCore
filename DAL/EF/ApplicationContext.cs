using Microsoft.EntityFrameworkCore;
using DAL.Entities;

namespace DAL.EF
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Good> Goods { get; set; }
        public DbSet<GoodGroup> GoodGroups { get; set; }
        public DbSet<Department> Departments { get; set; }

        public DbSet<InventoryDate> InventoryDates { get; set; }
        public DbSet<InventoryHead> InventoryHeads { get; set; }
        public DbSet<InventoryBody> InventoryBodies { get; set; }
        public DbSet<InventoryResult> InventoryResults { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=MyLTdb;Username=postgres;Password=123456");
        }
    }
}
