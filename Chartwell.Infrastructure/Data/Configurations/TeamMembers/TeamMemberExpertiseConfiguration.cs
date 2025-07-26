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
    internal class TeamMemberExpertiseConfiguration : IEntityTypeConfiguration<TeamMemberExpertise>
    {
        public void Configure(EntityTypeBuilder<TeamMemberExpertise> builder)
        {
            builder.HasOne(T => T.TeamMembers)
               .WithMany();


            builder.HasOne(T => T.CompanyExpertises)
               .WithMany();
               
            builder.Property(T => T.DisplayOrder).IsRequired();

            builder.Property(T => T.RoleTitle).IsRequired();
        }
    }
}
