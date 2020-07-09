using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Rrezart.Vibe.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rrezart.Vibe.Persistence.Configuration
{
    public class EnviromentConfiguration : IEntityTypeConfiguration<Enviroment>
    {
        public void Configure(EntityTypeBuilder<Enviroment> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("Id")
                .IsRequired(true);

            builder.Property(x => x.EnviromentName)
                .HasColumnName("EnviromentName")
                .IsRequired(true);

            builder.ToTable("Enviroment");
        }
    }
}
