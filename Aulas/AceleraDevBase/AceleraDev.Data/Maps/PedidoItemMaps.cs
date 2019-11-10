using AceleraDev.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AceleraDev.Data.Maps
{
    public class PedidoItemMaps : IEntityTypeConfiguration<PedidoItem>
    {
        public void Configure(EntityTypeBuilder<PedidoItem> builder)
        {
            builder.ToTable("pedido_item");

            builder.HasKey(p => new { p.PedidoId, p.ProdutoId});
            builder.HasOne(p => p.Pedido);
            builder.HasOne(p => p.Produto);
        }
    }
}
