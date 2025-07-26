using Chartwell.Core.Entity.CompanyServices;
using Chartwell.Core.Entity.ExpertisesNews;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chartwell.Infrastructure.Data.Configurations.CompanyServices
{
    internal class IndustryConfiguration : IEntityTypeConfiguration<Industry>
    {
        public void Configure(EntityTypeBuilder<Industry> builder)
        {
            builder.Property(I => I.Name)
                .HasMaxLength(100)
                .IsRequired();


            builder.HasOne(I => I.CompanyServices)
                .WithMany();

            builder.Property(T => T.CreatedAt).HasDefaultValueSql("GETUTCDATE()");

            builder.Property(T => T.UpdatesAt).HasDefaultValueSql("GETUTCDATE()");

        }
    }
}
