using Chartwell.Core.Entity.ExpertisesNews;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chartwell.Infrastructure.Data.Configurations.Expertises
{
    internal class CompanyExpertiseConfiguration : IEntityTypeConfiguration<CompanyExpertise>
    {
        public void Configure(EntityTypeBuilder<CompanyExpertise> builder)
        {
            builder.Property(E => E.Name)
               .HasMaxLength(500)
               .IsRequired();

            builder.Property(E => E.Description)
             .HasMaxLength(5000)
             .IsRequired();

            builder.Property(E => E.pictureUrl).IsRequired();

            builder.Property(E => E.CreatedAt).HasDefaultValueSql("GETUTCDATE()");

            builder.Property(E => E.UpdatesAt).HasDefaultValueSql("GETUTCDATE()");

        }
    }
}
