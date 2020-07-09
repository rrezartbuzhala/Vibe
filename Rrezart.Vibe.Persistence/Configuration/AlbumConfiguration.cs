using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Rrezart.Vibe.Domain.Entities;

namespace Rrezart.Vibe.Persistence.Configuration
{
    public class AlbumConfiguration : IEntityTypeConfiguration<Album>
    {
        public void Configure(EntityTypeBuilder<Album> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("Id")
                .IsRequired(true);

            builder.Property(x => x.Title)
                .HasColumnName("Title")
                .IsRequired(true);

            builder.Property(x => x.ArtistId)
                .HasColumnName("ArtisId")
                .IsRequired(true);

            builder.Property(x => x.CoverSource)
                .HasColumnName("CoverSource")
                .IsRequired(true);

            builder.Property(x => x.ReleaseDate)
                .HasColumnName("ReleaseDate")
                .IsRequired(true);

            builder.ToTable("Album");
        }
    }
}
