using Chartwell.Core.Entity.ContactsUs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chartwell.Infrastructure.Data.Configurations.ContactsUs
{
    internal class ContactUsConfiguration : IEntityTypeConfiguration<ContactUs>
    {
        public void Configure(EntityTypeBuilder<ContactUs> builder)
        {
            builder.Property(C => C.FirstName).IsRequired();

            builder.Property(C => C.LastName).IsRequired();

            builder.Property(C => C.PhoneNumber).IsRequired();

            builder.Property(C => C.Email).IsRequired();

            builder.Property(C => C.Message).IsRequired();

            builder.Property(C => C.CreatedAt).HasDefaultValueSql("GETUTCDATE()");

            builder.HasOne(C => C.Address)
                .WithMany()
                .HasForeignKey(C => C.AddressId);

            builder.HasOne(C => C.CompanyExpertise)
                .WithMany()
                .HasForeignKey(C => C.CompanyExpertiseId);

        }
    }
}
