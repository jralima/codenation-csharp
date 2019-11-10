using AceleraDev.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AceleraDev.Data.Maps
{
    public class TelefoneMaps : IEntityTypeConfiguration<Telefone>
    {
        public void Configure(EntityTypeBuilder<Telefone> builder)
        {
            builder.ToTable("telefone");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.DDI).HasMaxLength(3);
            builder.Property(p => p.DDD).HasMaxLength(3).IsRequired();
            builder.Property(p => p.Numero).HasMaxLength(9).IsRequired();
        }
    }
}
