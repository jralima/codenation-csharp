using AceleraDev.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AceleraDev.Data.Maps
{
    public class PedidoMaps : IEntityTypeConfiguration<Pedido>
    {
        public void Configure(EntityTypeBuilder<Pedido> builder)
        {
            builder.ToTable("pedido");

            builder.HasKey(p => p.Id);
            builder.HasMany(p => p.Itens).WithOne(p => p.Pedido).HasForeignKey(p => p.PedidoId);
        }
    }
}
