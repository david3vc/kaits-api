using Kaits.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kaits.Infrastructure.Configurations
{
    public class ClienteConfiguration : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable("cliente");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Id).HasColumnName("id_cliente");
            builder.Property(t => t.Nombres).HasColumnName("nombres");
            builder.Property(t => t.ApellidoPaterno).HasColumnName("apellido_paterno");
            builder.Property(t => t.ApellidoMaterno).HasColumnName("apellido_materno");
            builder.Property(t => t.Dni).HasColumnName("dni");
            builder.Property(t => t.FechaCreacion).HasColumnName("fecha_creacion");
            builder.Property(t => t.FechaActualizacion).HasColumnName("fecha_actualizacion");
            builder.Property(t => t.Estado).HasColumnName("estado");
        }
    }
}
