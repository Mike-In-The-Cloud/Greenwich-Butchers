using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace GreButchersEFCore_V2.Models
{
    public partial class GreButchersContext : IdentityDbContext
    {
        public GreButchersContext()
        {
        }

        public GreButchersContext(DbContextOptions<GreButchersContext> options)
            : base(options)
        {
        }

        public virtual DbSet<BulkOrder> BulkOrder { get; set; }
        public virtual DbSet<BulkOrderItem> BulkOrderItem { get; set; }
        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<InShopSales> InShopSales { get; set; }
        public virtual DbSet<ModifiedBy> ModifiedBy { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<Stock> Stock { get; set; }
        public virtual DbSet<Supplier> Supplier { get; set; }
        public virtual DbSet<SupplierContacted> SupplierContacted { get; set; }

        public DbSet<ApplicationUser> ApplicationUser { get; set; }

        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.HasAnnotation("ProductVersion", "2.2.1-servicing-10028");

            

            modelBuilder.Entity<BulkOrder>(entity =>
            {
                entity.HasIndex(e => e.FkCustomerId);

                entity.Property(e => e.BulkOrderCreationDate).IsUnicode(false);

                entity.Property(e => e.BulkOrderMargin).IsUnicode(false);

                entity.HasOne(d => d.FkCustomer)
                    .WithMany(p => p.BulkOrder)
                    .HasForeignKey(d => d.FkCustomerId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_BulkOrder_Customer");
            });

            modelBuilder.Entity<BulkOrderItem>(entity =>
            {
                entity.HasIndex(e => e.FkBulkOrderId);

                entity.HasIndex(e => e.FkProductId);

                entity.HasOne(d => d.FkBulkOrder)
                    .WithMany(p => p.BulkOrderItem)
                    .HasForeignKey(d => d.FkBulkOrderId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_BulkOrderItem_BulkOrder");

                entity.HasOne(d => d.FkProduct)
                    .WithMany(p => p.BulkOrderItem)
                    .HasForeignKey(d => d.FkProductId)
                    .HasConstraintName("FK_BulkOrderItem_Product");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.Property(e => e.CategoryName).IsUnicode(false);
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                

                entity.Property(e => e.CustomerCompanyName).IsUnicode(false);

            });

            modelBuilder.Entity<Employee>(entity =>
            {

                entity.Property(e => e.EmployeeEndDate).IsUnicode(false);

                entity.Property(e => e.EmployeeStartDate).IsUnicode(false);

                entity.Property(e => e.EmployeeType).IsUnicode(false);
            });

            modelBuilder.Entity<InShopSales>(entity =>
            {
                entity.HasIndex(e => e.FkEmployeeId);

                entity.HasIndex(e => e.FkProductId);

                entity.Property(e => e.InShopSalesDate).IsUnicode(false);

                entity.HasOne(d => d.FkEmployee)
                    .WithMany(p => p.InShopSales)
                    .HasForeignKey(d => d.FkEmployeeId)
                    .HasConstraintName("FK_InShopSales_Employee");

                entity.HasOne(d => d.FkProduct)
                    .WithMany(p => p.InShopSales)
                    .HasForeignKey(d => d.FkProductId)
                    .HasConstraintName("FK_InShopSales_Product");
            });

            modelBuilder.Entity<ModifiedBy>(entity =>
            {
                entity.HasIndex(e => e.FkBulkOrderId);

                entity.HasIndex(e => e.FkEmployeeId);

                entity.Property(e => e.ModifiedByDate).IsUnicode(false);

                entity.HasOne(d => d.FkBulkOrder)
                    .WithMany(p => p.ModifiedBy)
                    .HasForeignKey(d => d.FkBulkOrderId)
                    .HasConstraintName("FK_ModifiedBy_BulkOrder");

                entity.HasOne(d => d.FkEmployee)
                    .WithMany(p => p.ModifiedBy)
                    .HasForeignKey(d => d.FkEmployeeId)
                    .HasConstraintName("FK_ModifiedBy_Employee");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasIndex(e => e.FkCategoryId);

                entity.Property(e => e.ProductDescription).IsUnicode(false);

                entity.Property(e => e.ProductName).IsUnicode(false);

                entity.HasOne(d => d.FkCategory)
                    .WithMany(p => p.Product)
                    .HasForeignKey(d => d.FkCategoryId)
                    .HasConstraintName("FK_Product_Category");
            });

            modelBuilder.Entity<Stock>(entity =>
            {
                entity.HasIndex(e => e.FkProductId);

                entity.HasOne(d => d.FkProduct)
                    .WithMany(p => p.Stock)
                    .HasForeignKey(d => d.FkProductId)
                    .HasConstraintName("FK_Stock_Product");
            });

            modelBuilder.Entity<Supplier>(entity =>
            {
                

                entity.Property(e => e.SupplierName).IsUnicode(false);
            });

            modelBuilder.Entity<SupplierContacted>(entity =>
            {
                entity.HasIndex(e => e.FkBulkOrderId);

                entity.HasIndex(e => e.FkSupplerId);

                entity.Property(e => e.SupplerContactedReplyDate).IsUnicode(false);

                entity.Property(e => e.SupplierContactedDate).IsUnicode(false);

                entity.Property(e => e.SupplierContactedQuote).IsUnicode(false);

                entity.HasOne(d => d.FkBulkOrder)
                    .WithMany(p => p.SupplierContacted)
                    .HasForeignKey(d => d.FkBulkOrderId)
                    .HasConstraintName("FK_SupplierContacted_BulkOrder");

                entity.HasOne(d => d.FkSuppler)
                    .WithMany(p => p.SupplierContacted)
                    .HasForeignKey(d => d.FkSupplerId)
                    .HasConstraintName("FK_SupplierContacted_Supplier");
            });
        }
    }
}
