using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Rrezart.Vibe.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rrezart.Vibe.Persistence.Configuration
{
    public class ArtistConfiguration : IEntityTypeConfiguration<Artist>
    {
        public void Configure(EntityTypeBuilder<Artist> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("Id")
                .IsRequired(true);

            builder.Property(x => x.Name)
                .HasColumnName("Name")
                .IsRequired(true);

            builder.ToTable("Artist");
        }
    }
}
