using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Rrezart.Vibe.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rrezart.Vibe.Persistence.Configuration
{
    public class SongGenreConfiguration : IEntityTypeConfiguration<SongGenre>
    {
        public void Configure(EntityTypeBuilder<SongGenre> builder)
        {
            builder.HasKey(x => new { x.SongId, x.GenreId });

            builder.Property(x => x.SongId)
                .HasColumnName("SongId")
                .IsRequired(true);

            builder.Property(x => x.GenreId)
                .HasColumnName("GenreId")
                .IsRequired(true);

            Relationships(builder);

            builder.ToTable("SongGenre");
        }

        private void Relationships(EntityTypeBuilder<SongGenre> builder)
        {
            builder.HasOne(x => x.Song)
                .WithMany(x => x.SongGenre)
                .HasForeignKey(x => x.SongId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.Genre)
                .WithMany(x => x.SongGenre)
                .HasForeignKey(x => x.GenreId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
