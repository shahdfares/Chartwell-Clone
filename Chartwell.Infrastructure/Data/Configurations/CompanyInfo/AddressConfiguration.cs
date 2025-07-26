using Chartwell.Core.Entity.Company;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chartwell.Infrastructure.Data.Configurations.CompanyInfo
{
    internal class AddressConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.HasOne(A => A.CompanyInfo)
                .WithMany()
                .HasForeignKey(A => A.CompanyInfoId);

        }
    }
}
