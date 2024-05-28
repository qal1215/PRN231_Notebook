using Lab3.Infra.Models;
using Microsoft.EntityFrameworkCore;

namespace Lab3.Infra.Data;

public partial class Lab3Prn231Context : DbContext
{
    public Lab3Prn231Context()
    {
    }

    public Lab3Prn231Context(DbContextOptions<Lab3Prn231Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Account> Accounts { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Account>(entity =>
        {
            entity.HasKey(e => e.Accountid).HasName("account_pkey");

            entity.ToTable("account");

            entity.Property(e => e.Accountid).HasColumnName("accountid");
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .HasColumnName("password");
            entity.Property(e => e.Role).HasColumnName("role");
            entity.Property(e => e.Username)
                .HasMaxLength(40)
                .HasColumnName("username");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.Categoryid).HasName("category_pkey");

            entity.ToTable("category");

            entity.Property(e => e.Categoryid).HasColumnName("categoryid");
            entity.Property(e => e.Categoryname)
                .HasMaxLength(40)
                .HasColumnName("categoryname");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Productid).HasName("product_pkey");

            entity.ToTable("product");

            entity.Property(e => e.Productid).HasColumnName("productid");
            entity.Property(e => e.Categoryid).HasColumnName("categoryid");
            entity.Property(e => e.Productname)
                .HasMaxLength(40)
                .HasColumnName("productname");
            entity.Property(e => e.Unitprice)
                .HasPrecision(18, 2)
                .HasColumnName("unitprice");
            entity.Property(e => e.Unitsinstock).HasColumnName("unitsinstock");

            entity.HasOne(d => d.Category).WithMany(p => p.Products)
                .HasForeignKey(d => d.Categoryid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_product_category");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
