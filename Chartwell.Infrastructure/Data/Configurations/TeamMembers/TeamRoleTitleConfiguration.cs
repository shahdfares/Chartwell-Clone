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
    internal class TeamRoleTitleConfiguration : IEntityTypeConfiguration<TeamRoleTitle>
    {
        public void Configure(EntityTypeBuilder<TeamRoleTitle> builder)
        {
            builder.Property(T => T.Name)
                .HasMaxLength(500)
                .IsRequired();

            builder.Property(T => T.CreatedAt).HasDefaultValueSql("GETUTCDATE()");

            builder.Property(T => T.UpdatesAt).HasDefaultValueSql("GETUTCDATE()");

            builder.HasOne(T => T.OurFirm)
              .WithMany();
             


        }
    }
}
