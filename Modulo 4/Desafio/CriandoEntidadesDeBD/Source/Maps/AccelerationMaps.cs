using Codenation.Challenge.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Source.Maps
{
    public class AccelerationMaps : IEntityTypeConfiguration<Acceleration>
    {
        public void Configure(EntityTypeBuilder<Acceleration> builder)
        {
            builder.ToTable("acceleration");

            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).HasColumnName("id").IsRequired();

            builder.Property(p => p.Name).HasColumnName("name").HasColumnType("varchar").IsRequired();
            builder.Property(p => p.Slug).HasColumnName("slug").HasMaxLength(50).HasColumnType("varchar").IsRequired();
            builder.Property(p => p.ChallengeId).HasColumnName("challenge_id").IsRequired();
            builder.Property(p => p.CreatedAt).HasColumnName("created_at").HasColumnType<DateTime>("timestamp").IsRequired();

            builder.HasOne(x => x.Challenge)
                .WithMany(x => x.Accelerations)
                .HasForeignKey(x => x.ChallengeId);
        }
    }
}
