using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Entity_Layer.Entities
{
    public partial class ProductCatalogContext : DbContext
    {
        public ProductCatalogContext()
        {
        }

        public ProductCatalogContext(DbContextOptions<ProductCatalogContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Category> Categories { get; set; } = null!;
        public virtual DbSet<Feature> Features { get; set; } = null!;
        public virtual DbSet<FeatureValue> FeatureValues { get; set; } = null!;
        public virtual DbSet<Product> Products { get; set; } = null!;
        public virtual DbSet<ProductType> ProductTypes { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=SYNCLAPN-31446; Database=ProductCatalog; Trusted_Connection=True; Encrypt=False;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>(entity =>
            {
                entity.Property(e => e.CategoryId).HasColumnName("CategoryID");

                entity.Property(e => e.CategoryName)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Feature>(entity =>
            {
                entity.Property(e => e.FeatureId).HasColumnName("FeatureID");

                entity.Property(e => e.FeatureName)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.TypeId).HasColumnName("TypeID");

                entity.HasOne(d => d.Type)
                    .WithMany(p => p.Features)
                    .HasForeignKey(d => d.TypeId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__Features__TypeID__44FF419A");
            });

            modelBuilder.Entity<FeatureValue>(entity =>
            {
                entity.HasKey(e => e.ValueId)
                    .HasName("PK__FeatureV__93364E68D7834558");

                entity.Property(e => e.ValueId).HasColumnName("ValueID");

                entity.Property(e => e.FeatureId).HasColumnName("FeatureID");

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.Property(e => e.ValueName)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.Feature)
                    .WithMany(p => p.FeatureValues)
                    .HasForeignKey(d => d.FeatureId)
                    .HasConstraintName("FK__FeatureVa__Featu__5070F446");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.FeatureValues)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__FeatureVa__Produ__4F7CD00D");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.Property(e => e.BrandName)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.CategoryId).HasColumnName("CategoryID");

                entity.Property(e => e.ProductName)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.TypeId).HasColumnName("TypeID");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK__Products__Catego__412EB0B6");

                entity.HasOne(d => d.Type)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.TypeId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__Products__TypeID__4222D4EF");
            });

            modelBuilder.Entity<ProductType>(entity =>
            {
                entity.HasKey(e => e.TypeId)
                    .HasName("PK__ProductT__516F039599D6FAD6");

                entity.Property(e => e.TypeId).HasColumnName("TypeID");

                entity.Property(e => e.CategoryId).HasColumnName("CategoryID");

                entity.Property(e => e.TypeName)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.ProductTypes)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__ProductTy__Categ__3E52440B");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
