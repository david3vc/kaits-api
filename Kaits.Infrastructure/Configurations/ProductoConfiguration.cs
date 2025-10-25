using Kaits.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kaits.Infrastructure.Configurations
{
    public class ProductoConfiguration : IEntityTypeConfiguration<Producto>
    {
        public void Configure(EntityTypeBuilder<Producto> builder)
        {
            builder.ToTable("producto");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Id).HasColumnName("id_producto");
            builder.Property(t => t.Descripcion).HasColumnName("descripcion");
            builder.Property(t => t.PrecioUnitario).HasColumnName("precio_unitario");
            builder.Property(t => t.FechaCreacion).HasColumnName("fecha_creacion");
            builder.Property(t => t.FechaActualizacion).HasColumnName("fecha_actualizacion");
            builder.Property(t => t.Estado).HasColumnName("estado");
        }
    }
}
