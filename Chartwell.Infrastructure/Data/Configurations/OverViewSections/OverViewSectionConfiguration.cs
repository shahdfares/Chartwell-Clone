using Chartwell.Core.Entity.CompanyServices;
using Chartwell.Core.Entity.OverViewSections;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chartwell.Infrastructure.Data.Configurations.OverViewSections
{
    internal class OverViewSectionConfiguration : IEntityTypeConfiguration<OverViewSection>
    {
        public void Configure(EntityTypeBuilder<OverViewSection> builder)
        {
            builder.Property(O => O.Title)
              .HasMaxLength(500)
              .IsRequired();

            builder.Property(O => O.Content)
             .HasMaxLength(5000)
             .IsRequired();

            builder.Property(O => O.DisplayOrder).IsRequired();

            builder.Property(O => O.CreatedAt).HasDefaultValueSql("GETUTCDATE()");

            builder.Property(O => O.UpdatesAt).HasDefaultValueSql("GETUTCDATE()");

            builder.HasOne(O => O.CompanyExpertise)
                   .WithMany();
                   

            builder.HasOne(O => O.CompanyServices)
                  .WithMany()
                  .OnDelete(DeleteBehavior.SetNull);
        } 
    }
}
