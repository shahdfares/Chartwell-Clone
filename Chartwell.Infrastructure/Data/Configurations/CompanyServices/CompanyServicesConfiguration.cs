using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chartwell.Infrastructure.Data.Configurations.CompanyServices
{
    internal class CompanyServicesConfiguration : IEntityTypeConfiguration<Core.Entity.CompanyServices.CompanyService>
    {
        public void Configure(EntityTypeBuilder<Core.Entity.CompanyServices.CompanyService> builder)
        {
            builder.Property(C => C.Name)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(C => C.PictureUrl)
               .IsRequired();

            builder.Property(T => T.CreatedAt).HasDefaultValueSql("GETUTCDATE()");

            builder.Property(T => T.UpdatesAt).HasDefaultValueSql("GETUTCDATE()");
        }
    }
}
