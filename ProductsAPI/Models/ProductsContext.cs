using Microsoft.EntityFrameworkCore;

namespace ProductsAPI.Models
{
    public class ProductsContext : DbContext {
        public ProductsContext(DbContextOptions<ProductsContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)      //SeedData gibi calisiyor eger veri yoksa bu verileri yukluyor.
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>().HasData(new Product() {ProductId = 1, ProductName = "Iphone", Price = 60000, IsActive=true});
            modelBuilder.Entity<Product>().HasData(new Product() {ProductId = 2, ProductName = "Xiaomi", Price = 50000, IsActive=true});
            modelBuilder.Entity<Product>().HasData(new Product() {ProductId = 3, ProductName = "Samsung", Price = 40000, IsActive=false});
            modelBuilder.Entity<Product>().HasData(new Product() {ProductId = 4, ProductName = "Huawei", Price = 30000, IsActive=true});
            modelBuilder.Entity<Product>().HasData(new Product() {ProductId = 5, ProductName = "Lenovo", Price = 20000, IsActive=false});
        }

        public DbSet<Product> Products { get; set; }
    }
}