using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ITAsset.core.Data
{
    public partial class itassetContext : DbContext
    {
        public itassetContext()
        {
        }

        public itassetContext(DbContextOptions<itassetContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Asset> Assets { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySql("server=localhost;database=itasset;user id=root;password=Test123", Microsoft.EntityFrameworkCore.ServerVersion.Parse("9.0.1-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8mb4_0900_ai_ci")
                .HasCharSet("utf8mb4");

            modelBuilder.Entity<Asset>(entity =>
            {
                entity.ToTable("Asset");

                entity.HasIndex(e => e.SerialNumber, "SerialNumber")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Brand)
                    .HasMaxLength(255)
                    .IsRequired();

                entity.Property(e => e.SerialNumber)
                    .HasMaxLength(255)
                    .IsRequired();

                entity.Property(e => e.WarrantyExpirationDate)
                    .HasColumnType("DATE");

                entity.Property(e => e.Status)
                    .HasColumnType("ENUM('New','In Use','Damaged','Dispose')")
                    .IsRequired();

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("TIMESTAMP")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");
            });

            OnModelCreatingPartial(modelBuilder);
        }


        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
