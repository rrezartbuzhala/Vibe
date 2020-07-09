using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Rrezart.Vibe.Domain.Entities;

namespace Rrezart.Vibe.Persistence.Configuration
{
    public class SongConfiguration : IEntityTypeConfiguration<Song>
    {
        public void Configure(EntityTypeBuilder<Song> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("Id")
                .IsRequired(true);

            builder.Property(x => x.ArtistId)
               .HasColumnName("ArtistId")
               .IsRequired(true);

            builder.Property(x => x.AlbumId)
               .HasColumnName("AlbumId")
               .IsRequired(true);

            builder.Property(x => x.EnviromentId)
               .HasColumnName("EnviromentId")
               .IsRequired(true);

            builder.Property(x => x.Title)
               .HasColumnName("Title")
               .IsRequired(true);

            builder.Property(x => x.AudioSource)
               .HasColumnName("AudioSource")
               .IsRequired(true);

            builder.Property(x => x.Minutage)
               .HasColumnName("Minutage")
               .IsRequired(true);

            builder.Property(x => x.CoverSource)
               .HasColumnName("CoverSource")
               .IsRequired(true);

            builder.Property(x => x.RegistredDate)
               .HasColumnName("RegistredDate")
               .IsRequired(true);

            Relationships(builder);

            builder.ToTable("Song");
        }

        private void Relationships(EntityTypeBuilder<Song> builder)
        {
            builder.HasOne(x => x.Artist)
                .WithMany(x => x.Songs)
                .HasForeignKey(x => x.ArtistId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.Album)
                .WithMany(x => x.Songs)
                .HasForeignKey(x => x.AlbumId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.Enviroment)
                .WithMany(x => x.Songs)
                .HasForeignKey(x => x.EnviromentId)
                .OnDelete(DeleteBehavior.NoAction);
            

        }
    }
}