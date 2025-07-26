using Chartwell.Core.Entity.CompanyServices;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chartwell.Infrastructure.Data.Configurations.CompanyServices
{
    internal class SubIndustryConfiguration : IEntityTypeConfiguration<SubIndustry>
    {
        public void Configure(EntityTypeBuilder<SubIndustry> builder)
        {
            builder.Property(S => S.Title)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(S => S.DisplayOrder)
               .IsRequired();

            builder.HasOne(S => S.Industries)
                .WithMany()
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property(T => T.CreatedAt).HasDefaultValueSql("GETUTCDATE()");

            builder.Property(T => T.UpdatesAt).HasDefaultValueSql("GETUTCDATE()");
        }
    }
}
