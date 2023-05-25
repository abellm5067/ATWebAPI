using EFRepository.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System.Security.Principal;

namespace EFRepository
{
    public class ATWebDbContext : DbContext
    {
        public ATWebDbContext()
        {

        }
        public ATWebDbContext(DbContextOptions<ATWebDbContext> options) : base(options) { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(StaticHelper.ConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderDetail>().HasOne(od => od.Order).WithMany(o => o.OrderDetails).HasForeignKey(o => o.OrderId);
            modelBuilder.Entity<OrderDetail>().HasOne(od => od.ProductInfo).WithMany(o => o.OrderDetails).HasForeignKey(o => o.ProductId);
            modelBuilder.Entity<ProductInfo>().HasOne(od => od.Inventory).WithMany(o => o.Products).HasForeignKey(o => o.InventoryId);
            modelBuilder.Entity<Inventory>().HasOne(i => i.SellerInfo).WithMany(s => s.Inventories).HasForeignKey(o => o.SellerId);
            modelBuilder.Entity<ProductInfo>().HasOne(i => i.Category).WithMany(s => s.Products).HasForeignKey(o => o.CategoryId);
            modelBuilder.Entity<Order>()
                .HasOne(o => o.Customer)
                .WithMany(c => c.Orders)
                .HasForeignKey(o => o.CustomerId);
            modelBuilder.Entity<Role_Screen>().HasKey(e => new { e.RoleId, e.ScreenId });
            modelBuilder.Entity<User_Role>().HasKey(e => new { e.UserId, e.RoleId });

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Screen> Screens { get; set; }
        public DbSet<Role_Screen> Role_Screens { get; set; }
        public DbSet<User_Role> User_Roles { get; set; }
        public DbSet<Inventory> Inventory { get; set; }
        public DbSet<SellerInfo> Sellers { get; set; }
        public DbSet<ProductInfo> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}