using Codenation.Challenge.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Source.Maps
{
    public class UserMaps : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("user");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.FullName).HasColumnName("full_name").HasColumnType("varchar").IsRequired();
            builder.Property(p => p.Email).HasColumnName("email").HasColumnType("varchar").IsRequired();
            builder.Property(p => p.NickName).HasColumnName("nickname").HasMaxLength(50).HasColumnType("varchar").IsRequired();
            builder.Property(p => p.Password).HasColumnName("password").HasMaxLength(255).HasColumnType("varchar").IsRequired();
            builder.Property(p => p.CreatedAt).HasColumnName("created_at").HasColumnType("timestamp").IsRequired();
        }
    }
}
