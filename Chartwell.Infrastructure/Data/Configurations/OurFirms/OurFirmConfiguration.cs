using Chartwell.Core.Entity.OurFirms;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chartwell.Infrastructure.Data.Configurations.OurFirms
{
    internal class OurFirmConfiguration : IEntityTypeConfiguration<OurFirm>
    {
        public void Configure(EntityTypeBuilder<OurFirm> builder)
        {
            builder.Property(O => O.Title).HasMaxLength(1000);

            builder.Property(o => o.PictureUrl).IsRequired();

            builder.Property(T => T.CreatedAt).HasDefaultValueSql("GETUTCDATE()");

            builder.Property(T => T.UpdatesAt).HasDefaultValueSql("GETUTCDATE()");
        }
    }
}
