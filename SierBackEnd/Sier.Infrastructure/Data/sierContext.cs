using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Sier.Core.Entities;

#nullable disable

namespace Sier.Infrastructure.Data
{
    public partial class sierContext : DbContext
    {
        public sierContext()
        {
        }

        public sierContext(DbContextOptions<sierContext> options)
            : base(options)
        {
        }

        public virtual DbSet<DetalleProducto> DetalleProductos { get; set; }
        public virtual DbSet<Producto> Productos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<DetalleProducto>(entity =>
            {
                entity.HasKey(e => e.IdDetalleProducto);

                entity.ToTable("DetalleProducto");

                entity.Property(e => e.ValorIva)
                    .HasColumnType("money")
                    .HasColumnName("ValorIVA");

                entity.Property(e => e.ValorTotal).HasColumnType("money");

                entity.HasOne(d => d.IdProductoNavigation)
                    .WithMany(p => p.DetalleProductos)
                    .HasForeignKey(d => d.IdProducto)
                    .HasConstraintName("FK_DetalleProducto_Producto");
            });

            modelBuilder.Entity<Producto>(entity =>
            {
                entity.ToTable("Producto");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.Precio).HasColumnType("money");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
