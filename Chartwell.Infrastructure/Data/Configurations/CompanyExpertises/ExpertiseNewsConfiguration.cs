using Chartwell.Core.Entity.ExpertisesNews;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chartwell.Infrastructure.Data.Configurations.ExpertisesNews
{
    internal class ExpertiseNewsConfiguration : IEntityTypeConfiguration<ExpertiseNews>
    {
        public void Configure(EntityTypeBuilder<ExpertiseNews> builder)
        {
            builder.Property(E => E.Content)
                .HasMaxLength(50000)
                .IsRequired();

            builder.Property(E => E.Title)
                .HasMaxLength (500)
                .IsRequired();

            builder.Property(E => E.DisplayOrder)
               .IsRequired();

            builder.Property(T => T.CreatedAt).HasDefaultValueSql("GETUTCDATE()");

            builder.Property(T => T.UpdatesAt).HasDefaultValueSql("GETUTCDATE()");

            builder.HasOne(E => E.CompanyExpertise)
                .WithMany();
                

            builder.HasOne(E => E.TeamMembers)
              .WithMany();
              
        }
    }
}
