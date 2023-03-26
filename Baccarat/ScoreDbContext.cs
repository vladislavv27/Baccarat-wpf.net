using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Baccarat
{
    public partial class ScoreDbContext : DbContext
    {
        public ScoreDbContext()
        {
        }

        public ScoreDbContext(DbContextOptions<ScoreDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Score> Scores { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=DESKTOP-9CGM079;Database=ScoreDb;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Score>(entity =>
            {
                entity.ToTable("Score");

                entity.Property(e => e.DateTime).HasColumnType("datetime");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
