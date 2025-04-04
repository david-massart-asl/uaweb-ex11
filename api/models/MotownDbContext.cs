using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace api.Models
{
    public partial class MotownDbContext : DbContext
    {
        public MotownDbContext()
        {
        }

        public MotownDbContext(DbContextOptions<MotownDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Artists> Artists { get; set; }
        public virtual DbSet<FavoriteActs> FavoriteActs { get; set; }
        public virtual DbSet<ScheduleItems> ScheduleItems { get; set; }
        public virtual DbSet<Stages> Stages { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=motownserverdm.database.windows.net;Initial Catalog=MotownDb;Persist Security Info=True;User ID=david;Password='neSI53;!'");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Artists>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.WebSite).IsUnicode(false);
            });

            modelBuilder.Entity<FavoriteActs>(entity =>
            {
                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.ScheduleItem)
                    .WithMany(p => p.FavoriteActs)
                    .HasForeignKey(d => d.ScheduleItemId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FavoriteActs_ScheduleItems");
            });

            modelBuilder.Entity<ScheduleItems>(entity =>
            {
                entity.Property(e => e.Time).HasColumnType("smalldatetime");

                entity.HasOne(d => d.Artist)
                    .WithMany(p => p.ScheduleItems)
                    .HasForeignKey(d => d.ArtistId)
                    .HasConstraintName("FK_ScheduleItems_Artists");

                entity.HasOne(d => d.Stage)
                    .WithMany(p => p.ScheduleItems)
                    .HasForeignKey(d => d.StageId)
                    .HasConstraintName("FK_ScheduleItems_Stages");
            });

            modelBuilder.Entity<Stages>(entity =>
            {
                entity.Property(e => e.Description).IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
