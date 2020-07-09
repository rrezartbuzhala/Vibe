using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Rrezart.Vibe.Domain.Entities;

namespace Rrezart.Vibe.Persistence.Configuration
{
    public class PlaylistSongsConfiguration : IEntityTypeConfiguration<PlaylistSongs>
    {
        public void Configure(EntityTypeBuilder<PlaylistSongs> builder)
        {
            builder.HasKey(x => new { x.SongId, x.PlaylistId });

            builder.Property(x => x.SongId)
                .HasColumnName("SongId")
                .IsRequired(true);

            builder.Property(x => x.PlaylistId)
                .HasColumnName("PlaylistId")
                .IsRequired(true);

            Relationships(builder);

            builder.ToTable("PlaylistSongs");

        }

        private void Relationships(EntityTypeBuilder<PlaylistSongs> builder)
        {
            builder.HasOne(x => x.Song)
                .WithMany(x => x.PlaylistSongs)
                .HasForeignKey(x => x.SongId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.Playlist)
                .WithMany(x => x.PlaylistSongs)
                .HasForeignKey(x => x.PlaylistId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
