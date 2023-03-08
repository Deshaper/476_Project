using RetailManagment.Models;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace RetailManagment.Data
{
    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<Cart> Carts { get; set; }
        public virtual DbSet<Check_out> Check_out { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<Commodity> Commodities { get; set; }
        public virtual DbSet<Commodity_rate> Commodity_rate { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Purchased> Purchaseds { get; set; }
        public virtual DbSet<Rate> Rates { get; set; }
        public virtual DbSet<Recipt> Recipts { get; set; }
        public virtual DbSet<Seller> Sellers { get; set; }
        public virtual DbSet<Shipment> Shipments { get; set; }
        public virtual DbSet<Categories> Categories { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cart>()
                .Property(e => e.Product_name)
                .IsUnicode(false);

            modelBuilder.Entity<Comment>()
                .Property(e => e.Comments)
                .IsUnicode(false);

            modelBuilder.Entity<Commodity>()
                .Property(e => e.Commo_name)
                .IsUnicode(false);

            modelBuilder.Entity<Commodity>()
                .Property(e => e.Category)
                .IsUnicode(false);

            modelBuilder.Entity<Commodity>()
               .Property(e => e.Description)
               .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.Username)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<Purchased>()
                .Property(e => e.Product_name)
                .IsUnicode(false);

            modelBuilder.Entity<Seller>()
                .Property(e => e.Seller_Name)
                .IsUnicode(false);
            modelBuilder.Entity<Categories>()
                .Property(e => e.Category_name) .IsUnicode(false);
        }
    }
}
