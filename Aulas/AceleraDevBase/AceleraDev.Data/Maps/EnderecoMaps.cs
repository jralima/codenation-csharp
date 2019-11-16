using AceleraDev.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AceleraDev.Data.Maps
{
    public class EnderecoMaps : IEntityTypeConfiguration<Endereco>
    {
        public void Configure(EntityTypeBuilder<Endereco> builder)
        {
            builder.ToTable("endereco");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Bairro).HasMaxLength(100);

            builder.Property(p => p.Cep).HasMaxLength(10);

            builder.HasOne(p => p.Cliente).WithMany(p => p.Enderecos).HasForeignKey(p => p.ClienteId);
        }
    }
}
