using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
namespace AlGallery.Data
{
    public class AlGalleryDBContext : IdentityDbContext<User>
    {
        public AlGalleryDBContext()
        {

        }
        public AlGalleryDBContext(DbContextOptions<AlGalleryDBContext> options) : base(options)
        {

        }

        public DbSet<User> User { get; set; }
        public DbSet<CartItems> Carts { get; set; }
        public DbSet<Categories> Categories { get; set; }
        public DbSet<Orders> Orders { get; set; }
        public DbSet<OrderItems> OrderItems { get; set; }
        public DbSet<Payments> Payments { get; set; }
        public DbSet<Products> Products { get; set; }
        public DbSet<Shipments> Shipments { get; set; }
        
        public DbSet<CartItems> CartItems { get; set; }
    }
}
