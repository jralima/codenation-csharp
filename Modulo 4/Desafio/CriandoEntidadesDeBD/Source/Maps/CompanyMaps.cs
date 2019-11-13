using Codenation.Challenge.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Source.Maps
{
    public class CompanyMaps : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.ToTable("company");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Name).HasColumnName("name").HasColumnType("varchar").IsRequired();
            builder.Property(p => p.Slug).HasColumnName("slug").HasMaxLength(50).HasColumnType("varchar").IsRequired();
            builder.Property(p => p.CreatedAt).HasColumnName("created_at").HasColumnType("timestamp").IsRequired();
        }
    }
}