using EcommerceWeb.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EcommerceWeb.Presentation.Persistences
{
    public class EcommerceDbContext: DbContext
    {
        public EcommerceDbContext(DbContextOptions<EcommerceDbContext> options): base(options) 
        { }
        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<Cart> Carts { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderDetail> OrderDetails { get; set; }
        public virtual DbSet<Permission> Permissions { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<QandA> QandAs { get; set; }
        public virtual DbSet<Review> Reviews { get; set; }
        public virtual DbSet<Topic> Topics { get; set; }
        public virtual DbSet<Vendor> Vendors { get; set; }
        public virtual DbSet<WishList> WishLists { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(EcommerceDbContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }

    }
}
