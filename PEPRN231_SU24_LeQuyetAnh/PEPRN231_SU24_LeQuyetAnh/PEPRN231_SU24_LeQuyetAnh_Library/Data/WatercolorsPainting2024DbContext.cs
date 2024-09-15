using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PEPRN231_SU24_LeQuyetAnh_Library.Models;

namespace PEPRN231_SU24_LeQuyetAnh_Library.Data;

public partial class WatercolorsPainting2024DbContext : DbContext
{
    public WatercolorsPainting2024DbContext()
    {
    }

    public WatercolorsPainting2024DbContext(DbContextOptions<WatercolorsPainting2024DbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Style> Styles { get; set; }

    public virtual DbSet<UserAccount> UserAccounts { get; set; }

    public virtual DbSet<WatercolorsPainting> WatercolorsPaintings { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

        IConfigurationRoot configuration = builder.Build();

        optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Style>(entity =>
        {
            entity.HasKey(e => e.StyleId).HasName("PK__Style__8AD146406BE51B8C");

            entity.ToTable("Style");

            entity.Property(e => e.StyleId).HasMaxLength(30);
            entity.Property(e => e.OriginalCountry).HasMaxLength(160);
            entity.Property(e => e.StyleDescription).HasMaxLength(250);
            entity.Property(e => e.StyleName).HasMaxLength(100);
        });

        modelBuilder.Entity<UserAccount>(entity =>
        {
            entity.HasKey(e => e.UserAccountId).HasName("PK__UserAcco__DA6C70BA4F116ACE");

            entity.ToTable("UserAccount");

            entity.HasIndex(e => e.UserEmail, "UQ__UserAcco__08638DF8D66A33B2").IsUnique();

            entity.Property(e => e.UserAccountId)
                .ValueGeneratedNever()
                .HasColumnName("UserAccountID");
            entity.Property(e => e.UserEmail).HasMaxLength(90);
            entity.Property(e => e.UserFullName).HasMaxLength(70);
            entity.Property(e => e.UserPassword).HasMaxLength(50);
        });

        modelBuilder.Entity<WatercolorsPainting>(entity =>
        {
            entity.HasKey(e => e.PaintingId).HasName("PK__Watercol__CF2D90F28FBF42D9");

            entity.ToTable("WatercolorsPainting");

            entity.Property(e => e.PaintingId).HasMaxLength(45);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.PaintingAuthor).HasMaxLength(120);
            entity.Property(e => e.PaintingDescription).HasMaxLength(250);
            entity.Property(e => e.PaintingName).HasMaxLength(100);
            entity.Property(e => e.Price).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.StyleId).HasMaxLength(30);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
