using Codenation.Challenge.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Source.Maps
{
    public class SubmissionMaps : IEntityTypeConfiguration<Submission>
    {
        public void Configure(EntityTypeBuilder<Submission> builder)
        {
            builder.ToTable("submission");

            builder.HasKey(p => new { p.UserId, p.ChallengeId });

            builder.Property(p => p.UserId).HasColumnName("user_id").IsRequired();
            builder.Property(p => p.ChallengeId).HasColumnName("challenge_id").IsRequired();
            builder.Property(p => p.Score).HasColumnName("score").IsRequired();
            builder.Property(p => p.CreatedAt).HasColumnName("created_at").HasColumnType("timestamp").IsRequired();

            builder.HasOne(x => x.User)
                .WithMany(x => x.Submissions)
                .HasForeignKey(x => x.UserId);

            builder.HasOne(x => x.Challenge)
                .WithMany(x => x.Submissions)
                .HasForeignKey(x => x.ChallengeId);
        }
    }
}
