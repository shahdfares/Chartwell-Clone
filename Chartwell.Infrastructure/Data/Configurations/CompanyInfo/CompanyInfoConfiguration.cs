using Chartwell.Core.Entity.Company;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Chartwell.Infrastructure.Data.Configurations.Company
{
    internal class CompanyInfoConfiguration : IEntityTypeConfiguration<Core.Entity.Company.CompanyInfo>
    {
        public void Configure(EntityTypeBuilder<Core.Entity.Company.CompanyInfo> builder)
        {
            //builder.OwnsOne(O => O.Address, contactDetails => contactDetails.WithOwner());

            //builder.HasOne(O => O.Address).WithOne();

            builder.OwnsOne(O => O.SocialLinks, socialLinks => socialLinks.WithOwner());

            builder.Property(C => C.CompanyName).HasMaxLength(500).IsRequired();

            builder.Property(C => C.LogoUrl).IsRequired();
        }
    }
}
