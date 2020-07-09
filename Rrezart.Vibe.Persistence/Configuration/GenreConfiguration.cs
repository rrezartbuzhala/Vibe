using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Rrezart.Vibe.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rrezart.Vibe.Persistence.Configuration
{
    public class GenreConfiguration : IEntityTypeConfiguration<Genre>
    {
        public void Configure(EntityTypeBuilder<Genre> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("Id")
                .IsRequired(true);

            builder.Property(x => x.GenreName)
                .HasColumnName("GenreName")
                .IsRequired(true);

            builder.ToTable("Genre");
        }
    }
}
