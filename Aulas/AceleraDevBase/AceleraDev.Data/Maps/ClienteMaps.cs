using AceleraDev.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AceleraDev.Data.Maps
{
    public class ClienteMaps : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable("cliente");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Cpf).HasMaxLength(11).IsRequired();
            builder.Property(p => p.Nome).IsRequired();
            builder.Property(p => p.Sobrenome).IsRequired();
            builder.HasMany(p => p.Telefones).WithOne(p => p.Cliente).HasForeignKey(p => p.ClienteId);
            builder.HasMany(p => p.Enderecos).WithOne(p => p.Cliente).HasForeignKey(p => p.ClienteId);

            //builder.Property(p => p.Ativo).HasColumnType("char").HasMaxLength(1).HasDefaultValue("S");
        }
    }
}
