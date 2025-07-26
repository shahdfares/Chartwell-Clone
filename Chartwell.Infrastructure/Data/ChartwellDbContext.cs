using Chartwell.Core.Entity.Company;
using Chartwell.Core.Entity.CompanyServices;
using Chartwell.Core.Entity.ContactsUs;
using Chartwell.Core.Entity.Departments;
using Chartwell.Core.Entity.ExpertisesNews;
using Chartwell.Core.Entity.OurFirms;
using Chartwell.Core.Entity.OverViewSections;
using Chartwell.Core.Entity.TeamMembers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Chartwell.Infrastructure.Data
{
    public class ChartwellDbContext : DbContext
    {
        public ChartwellDbContext(DbContextOptions<ChartwellDbContext> options): base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            modelBuilder.Entity<TeamMemberExpertise>().HasKey(K => new { K.TeamMemberId, K.CompanyExpertiseId });
        }

        #region DbSets

        public DbSet<TeamMember> TeamMembers { get; set; }
        public DbSet<CompanyExpertise> CompanyExpertise { get; set; }
        public DbSet<CompanyService> CompanyServices { get; set; }
        public DbSet<Industry> Industries { get; set; }
        public DbSet<SubIndustry> SubIndustries { get; set; }
        public DbSet<TeamMemberExpertise> TeamMemberExpertise { get; set; }
        public DbSet<TeamRoleTitle> TeamRoleTitles { get; set; }
        public DbSet<CompanyInfo> CompanyInfo { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<ExpertiseNews> ExpertiseNews { get; set; }
        public DbSet<DepartmentService> DepartmentServices { get; set; }
        public DbSet<ContactUs> ContactUs { get; set; }
        public DbSet<OurFirm> OurFirms { get; set; }
        public DbSet<OverViewSection> OverViewSections { get; set; } 

        #endregion
    }
}
