using Kaits.Domain.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaits.Infrastructure.Configurations
{
    public class PedidoConfiguration : IEntityTypeConfiguration<Pedido>
    {
        public void Configure(EntityTypeBuilder<Pedido> builder)
        {
            builder.ToTable("pedido");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Id).HasColumnName("id_pedido");
            builder.Property(t => t.Fecha).HasColumnName("fecha");
            builder.Property(t => t.IdCliente).HasColumnName("id_cliente");
            builder.Property(t => t.Total).HasColumnName("total");
            builder.Property(t => t.FechaCreacion).HasColumnName("fecha_creacion");
            builder.Property(t => t.FechaActualizacion).HasColumnName("fecha_actualizacion");
            builder.Property(t => t.Estado).HasColumnName("estado");

            builder.HasOne(one => one.Cliente).WithMany(many => many.Pedidos).HasForeignKey(fk => fk.IdCliente);
        }
    }
}
