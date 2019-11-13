using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace Codenation.Challenge.Models
{
    public class CodenationContext : DbContext
    {
        public DbSet<Company> Companies { get; set; }
        public DbSet<Candidate> Candidates { get; set; }
        public DbSet<Submission> Submissions { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Challenge> Challenge { get; set; }
        public DbSet<Acceleration> Accelerations { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Codenation;Trusted_Connection=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var property in modelBuilder.Model.GetEntityTypes().SelectMany(t => t.GetProperties()).Where(p => p.ClrType == typeof(string)))
            {
                if (property.GetMaxLength() == null) property.SetMaxLength(100);
            }

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CodenationContext).Assembly);
        }
    }
}