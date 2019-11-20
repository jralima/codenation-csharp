using Codenation.Challenge.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Source.Maps
{
    public class CandidateMaps : IEntityTypeConfiguration<Candidate>
    {
        public void Configure(EntityTypeBuilder<Candidate> builder)
        {
            builder.ToTable("candidate");

            builder.HasKey(p => new { p.UserId, p.AccelerationId, p.CompanyId });

            builder.Property(p => p.UserId).HasColumnName("user_id").IsRequired();
            builder.Property(p => p.AccelerationId).HasColumnName("acceleration_id").IsRequired();
            builder.Property(p => p.CompanyId).HasColumnName("company_id").IsRequired();
            builder.Property(p => p.Status).HasColumnName("status").IsRequired();
            builder.Property(p => p.CreatedAt).HasColumnName("created_at").HasColumnType("timestamp").IsRequired();


            builder.HasOne(x => x.Acceleration)
                .WithMany(x => x.Candidates)
                .HasForeignKey(x => x.AccelerationId);

            builder.HasOne(x => x.Company)
                .WithMany(x => x.Candidates)
                .HasForeignKey(x => x.CompanyId);

            builder.HasOne(x => x.User)
                .WithMany(x => x.Candidates)
                .HasForeignKey(x => x.UserId);
        }
    }
}
