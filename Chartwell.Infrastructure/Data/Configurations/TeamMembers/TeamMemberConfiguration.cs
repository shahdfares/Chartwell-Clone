using Chartwell.Core.Entity.TeamMembers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chartwell.Infrastructure.Data.Configurations.TeamMembers
{
    public class TeamMemberConfiguration : IEntityTypeConfiguration<TeamMember>
    {
        public void Configure(EntityTypeBuilder<TeamMember> builder)
        {
           

            builder.Property(T => T.FirstName)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(T => T.LastName)
               .HasMaxLength(50)
               .IsRequired();

            builder.Property(T => T.OfficeLocation)
                .HasMaxLength(50);
               

            builder.Property(T => T.PictureUrl)
               .IsRequired();

            builder.Property(T => T.Position)
               .HasMaxLength(500)
               .IsRequired();

            builder.Property(T => T.Bio)
               .HasMaxLength(500000);
               

            builder.Property(T => T.Education)
               .HasMaxLength(100000);
               

            builder.Property(T => T.Certifications)
               .HasMaxLength(500);


            builder.Property(T => T.Experience)
              .HasMaxLength(500);
              
              

            builder.Property(T => T.CreatedAt).HasDefaultValueSql("GETUTCDATE()");

            builder.Property(T => T.UpdatesAt).HasDefaultValueSql("GETUTCDATE()");

            builder.HasOne(T => T.DepartmentServices)
               .WithMany()
               .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(T => T.TeamRoleTitle)
               .WithMany();
               

            builder.HasOne(T => T.CompanyServices)
               .WithMany();
               

            builder.HasOne(T => T.OurFirm)
               .WithMany()
               .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
