using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace GICMicro.Models
{
    public partial class LmsDbMyHclContext : DbContext
    {
        public LmsDbMyHclContext()
        {
        }

        public LmsDbMyHclContext(DbContextOptions<LmsDbMyHclContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CompanyId> CompanyId { get; set; }
        public virtual DbSet<EmployeeMyhcl> EmployeeMyhcl { get; set; }
        public virtual DbSet<LmsTransactions> LmsTransactions { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<ProductCompany> ProductCompany { get; set; }
        public virtual DbSet<ProductInfo> ProductInfo { get; set; }
        public virtual DbSet<UsersInfo> UsersInfo { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=lmsdbmyhcl.database.windows.net;Database=LmsDbMyHcl;user id=LmsDbMyHcl;password=Raghu123;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CompanyId>(entity =>
            {
                entity.HasKey(e => e.CompanyId1);

                entity.ToTable("CompanyID");

                entity.Property(e => e.CompanyId1).HasColumnName("CompanyID");
            });

            modelBuilder.Entity<EmployeeMyhcl>(entity =>
            {
                entity.HasKey(e => e.EmpId);

                entity.Property(e => e.Band).IsRequired();

                entity.Property(e => e.DateOfJoining).HasColumnType("datetime");

                entity.Property(e => e.Email).HasColumnName("email");

                entity.Property(e => e.EmpName).IsRequired();

                entity.Property(e => e.Location).IsRequired();

                entity.Property(e => e.ManagerId).HasColumnName("ManagerID");
            });

            modelBuilder.Entity<LmsTransactions>(entity =>
            {
                entity.HasKey(e => e.TnsactionId);

                entity.ToTable("LMS_Transactions");

                entity.Property(e => e.TnsactionId).HasColumnName("TnsactionID");

                entity.Property(e => e.AppliedDate).HasColumnType("datetime");

                entity.Property(e => e.EmpId).HasColumnName("EmpID");

                entity.Property(e => e.LeaveOnDate).HasColumnType("datetime");

                entity.Property(e => e.LeaveType)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Status).IsRequired();
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.Property(e => e.ProductName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ProductCompany>(entity =>
            {
                entity.Property(e => e.ProductCompanyId).HasColumnName("ProductCompanyID");

                entity.Property(e => e.CompanyId).HasColumnName("CompanyID");

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.ProductCompany)
                    .HasForeignKey(d => d.CompanyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProductCompany_CompanyID");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ProductCompany)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProductCompany_ProductInfo");
            });

            modelBuilder.Entity<ProductInfo>(entity =>
            {
                entity.HasKey(e => e.ProductId);

                entity.Property(e => e.ProductId).HasColumnName("ProductID");
            });

            modelBuilder.Entity<UsersInfo>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.UserEmailId)
                    .IsRequired()
                    .HasColumnName("UserEmailID");

                entity.Property(e => e.UserName).IsRequired();

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.UsersInfo)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UsersInfo_CompanyID");
            });
        }
    }
}
