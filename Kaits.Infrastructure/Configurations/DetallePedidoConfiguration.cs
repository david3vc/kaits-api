using Kaits.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kaits.Infrastructure.Configurations
{
    public class DetallePedidoConfiguration : IEntityTypeConfiguration<DetallePedido>
    {
        public void Configure(EntityTypeBuilder<DetallePedido> builder)
        {
            builder.ToTable("detalle_pedido");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Id).HasColumnName("id_detalle_pedido");
            builder.Property(t => t.IdProducto).HasColumnName("id_producto");
            builder.Property(t => t.IdPedido).HasColumnName("id_pedido");
            builder.Property(t => t.Cantidad).HasColumnName("cantidad");
            builder.Property(t => t.Subtotal).HasColumnName("subtotal");
            builder.Property(t => t.FechaCreacion).HasColumnName("fecha_creacion");
            builder.Property(t => t.FechaActualizacion).HasColumnName("fecha_actualizacion");
            builder.Property(t => t.Estado).HasColumnName("estado");

            builder.HasOne(one => one.Producto).WithMany(many => many.DetallePedidos).HasForeignKey(fk => fk.IdProducto);
            builder.HasOne(one => one.Pedido).WithMany(many => many.DetallePedidos).HasForeignKey(fk => fk.IdPedido);
        }
    }
}
