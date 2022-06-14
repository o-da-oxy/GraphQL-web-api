using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace PictureGallery.Data.Models
{
    public partial class GalleriesContext : DbContext
    {
        public GalleriesContext()
        {
        }

        public GalleriesContext(DbContextOptions<GalleriesContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Author> Authors { get; set; } = null!;
        public virtual DbSet<Gallery> Galleries { get; set; } = null!;
        public virtual DbSet<Picture> Pictures { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer(" Server=.;Database=Gallery;Integrated Security=True;TrustServerCertificate=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>(entity =>
            {
                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsFixedLength();

                entity.HasOne(d => d.Gallery)
                    .WithMany(p => p.Authors)
                    .HasForeignKey(d => d.GalleryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Authors_Galleries");
            });

            modelBuilder.Entity<Gallery>(entity =>
            {
                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsFixedLength();

                entity.Property(e => e.Town)
                    .HasMaxLength(50)
                    .IsFixedLength();
            });

            modelBuilder.Entity<Picture>(entity =>
            {
                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsFixedLength();

                entity.HasOne(d => d.Author)
                    .WithMany(p => p.Pictures)
                    .HasForeignKey(d => d.AuthorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Pictures_Authors");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
