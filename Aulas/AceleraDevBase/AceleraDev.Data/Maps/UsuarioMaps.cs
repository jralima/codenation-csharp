using AceleraDev.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AceleraDev.Data.Maps
{
    public class UsuarioMaps : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("usuario");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Nome).IsRequired();
            builder.Property(p => p.Email).HasMaxLength(150).IsRequired();
            builder.Property(p => p.Senha).HasMaxLength(50).IsRequired();
            builder.Property(p => p.Perfil).HasMaxLength(50).IsRequired();
        }
    }
}
