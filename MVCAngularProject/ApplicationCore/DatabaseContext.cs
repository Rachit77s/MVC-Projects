using DomainModels.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore
{
    public class DatabaseContext : DbContext
    {
        //Rachit
        //Defining DB Connection String
        public DatabaseContext(): base("DefaultConnection")
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

        //Create below function otherwise you will face error
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            //m:m
            modelBuilder.Entity<User>().HasMany(u => u.Roles).WithMany(r => r.Users).Map((m) =>
            {
                m.MapLeftKey("UserId");
                m.MapRightKey("RoleId");
                m.ToTable("UserRoles");
            });                
        }
    }
}
