using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace OurDecor.Models;

public partial class OurDecorContext : DbContext
{
    public OurDecorContext()
    {
    }

    public OurDecorContext(DbContextOptions<OurDecorContext> options)
        : base(options)
    {
    }

    public virtual DbSet<EdIzm> EdIzms { get; set; }

    public virtual DbSet<Material> Materials { get; set; }

    public virtual DbSet<MaterialType> MaterialTypes { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<ProductMaterial> ProductMaterials { get; set; }

    public virtual DbSet<ProductType> ProductTypes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-5RGECJ1;Database=Our_Decor;User Id=well_fuck;Password=1912Daka$;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<EdIzm>(entity =>
        {
            entity.ToTable("Ed_izm");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<Material>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Materials_import");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.ColInUp).HasColumnName("Col_in_up");
            entity.Property(e => e.CountInWarehouse).HasColumnName("Count_in_warehouse");
            entity.Property(e => e.EdIzm).HasColumnName("Ed_izm");
            entity.Property(e => e.IdMaterialType).HasColumnName("ID_material_type");
            entity.Property(e => e.MaterialName)
                .HasMaxLength(100)
                .HasColumnName("Material_name");
            entity.Property(e => e.MinCol).HasColumnName("Min_col");
            entity.Property(e => e.PriceEd).HasColumnName("Price_ed");

            entity.HasOne(d => d.EdIzmNavigation).WithMany(p => p.Materials)
                .HasForeignKey(d => d.EdIzm)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Materials_Ed_izm");

            entity.HasOne(d => d.IdMaterialTypeNavigation).WithMany(p => p.Materials)
                .HasForeignKey(d => d.IdMaterialType)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Materials_Material_type");
        });

        modelBuilder.Entity<MaterialType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Material_type_import");

            entity.ToTable("Material_type");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.ProcentOfBrak).HasColumnName("Procent_of_brak");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.IdProductType).HasColumnName("ID_product_type");
            entity.Property(e => e.MinPriceForPartner).HasColumnName("Min_price_for_partner");
            entity.Property(e => e.ProductionName)
                .HasMaxLength(100)
                .HasColumnName("Production_name");
            entity.Property(e => e.ShirinaRulona).HasColumnName("Shirina_rulona");

            entity.HasOne(d => d.IdProductTypeNavigation).WithMany(p => p.Products)
                .HasForeignKey(d => d.IdProductType)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Products_Product_type1");
        });

        modelBuilder.Entity<ProductMaterial>(entity =>
        {
            entity.ToTable("Product_materials");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.IdMaterial).HasColumnName("ID_material");
            entity.Property(e => e.IdProduct).HasColumnName("ID_product");
            entity.Property(e => e.NeobColMaterial).HasColumnName("Neob_col_material");

            entity.HasOne(d => d.IdMaterialNavigation).WithMany(p => p.ProductMaterials)
                .HasForeignKey(d => d.IdMaterial)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Product_materials_Materials");

            entity.HasOne(d => d.IdProductNavigation).WithMany(p => p.ProductMaterials)
                .HasForeignKey(d => d.IdProduct)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Product_materials_Products");
        });

        modelBuilder.Entity<ProductType>(entity =>
        {
            entity.ToTable("Product_type");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.KoeffProduct).HasColumnName("Koeff_product");
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
