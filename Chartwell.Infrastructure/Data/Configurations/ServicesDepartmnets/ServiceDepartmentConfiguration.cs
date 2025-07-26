using Chartwell.Core.Entity.Departments;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chartwell.Infrastructure.Data.Configurations.Departmnets
{
    internal class ServiceDepartmentConfiguration : IEntityTypeConfiguration<DepartmentService>
    {
        public void Configure(EntityTypeBuilder<DepartmentService> builder)
        {
            builder.Property(D => D.Name)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(D => D.Description)
               .HasMaxLength(5000)
               .IsRequired();

         

            builder.Property(T => T.CreatedAt).HasDefaultValueSql("GETUTCDATE()");

            builder.Property(T => T.UpdatesAt).HasDefaultValueSql("GETUTCDATE()");


        }
    }
}
