using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace WebLaptopVM.Models
{
    public partial class LaptopVMDbContext : DbContext
    {
        public LaptopVMDbContext()
            : base("name=LaptopVMDbContext")
        {
        }

        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<Cart> Carts { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Edit> Edits { get; set; }
        public virtual DbSet<Level> Levels { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Sex> Sexes { get; set; }
        public virtual DbSet<StatusOrder> StatusOrders { get; set; }
        public virtual DbSet<StatusProduct> StatusProducts { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Admin>()
                .HasMany(e => e.Edits)
                .WithOptional(e => e.Admin1)
                .HasForeignKey(e => e.Admin);

            modelBuilder.Entity<Category>()
                .HasMany(e => e.Edits)
                .WithOptional(e => e.Category1)
                .HasForeignKey(e => e.Category);

            modelBuilder.Entity<Category>()
                .HasMany(e => e.Products)
                .WithRequired(e => e.Category1)
                .HasForeignKey(e => e.Category)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Level>()
                .HasMany(e => e.Admins)
                .WithRequired(e => e.Level1)
                .HasForeignKey(e => e.Level)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Order>()
                .HasMany(e => e.Edits)
                .WithOptional(e => e.Order1)
                .HasForeignKey(e => e.Order);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.Carts)
                .WithRequired(e => e.Product1)
                .HasForeignKey(e => e.Product)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.Edits)
                .WithOptional(e => e.Product1)
                .HasForeignKey(e => e.Product);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.Orders)
                .WithRequired(e => e.Product1)
                .HasForeignKey(e => e.Product)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Sex>()
                .HasMany(e => e.Admins)
                .WithRequired(e => e.Sex1)
                .HasForeignKey(e => e.Sex)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Sex>()
                .HasMany(e => e.Users)
                .WithRequired(e => e.Sex1)
                .HasForeignKey(e => e.Sex)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<StatusOrder>()
                .HasMany(e => e.Orders)
                .WithRequired(e => e.StatusOrder)
                .HasForeignKey(e => e.Stutus)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<StatusProduct>()
                .HasMany(e => e.Products)
                .WithRequired(e => e.StatusProduct)
                .HasForeignKey(e => e.Status)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Carts)
                .WithRequired(e => e.User1)
                .HasForeignKey(e => e.User)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Edits)
                .WithOptional(e => e.User1)
                .HasForeignKey(e => e.User);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Orders)
                .WithRequired(e => e.User1)
                .HasForeignKey(e => e.User)
                .WillCascadeOnDelete(false);
        }
    }
}
