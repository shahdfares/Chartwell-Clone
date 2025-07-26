using Chartwell.Core.Entity.Company;
using Chartwell.Core.Entity.CompanyServices;
using Chartwell.Core.Entity.Departments;
using Chartwell.Core.Entity.ExpertisesNews;
using Chartwell.Core.Entity.OurFirms;
using Chartwell.Core.Entity.OverViewSections;
using Chartwell.Core.Entity.TeamMembers;
using System.Text.Json;

namespace Chartwell.Infrastructure.Data
{
    public class ChartwellContextSeeds
    {
        public async static Task SeedAsync(ChartwellDbContext _dbContext)
        {

            if (_dbContext.CompanyServices?.Count() == 0)
            {

                var companyServicesData = File.ReadAllText("../Chartwell.Infrastructure/Data/DataSeeds/CopmanyServices.JSON");
                var companyServices = JsonSerializer.Deserialize<List<CompanyService>>(companyServicesData);

                if (companyServices?.Count() > 0)
                {
                    foreach (var companyService in companyServices)
                    {
                        _dbContext.Set<CompanyService>().Add(companyService);
                    }
                    await _dbContext.SaveChangesAsync();
                }
            }

            if (_dbContext.Industries?.Count() == 0)
            {

                var industryData = File.ReadAllText("../Chartwell.Infrastructure/Data/DataSeeds/Industry.JSON");
                var industries = JsonSerializer.Deserialize<List<Industry>>(industryData);

                if (industries?.Count() > 0)
                {
                    foreach (var industry in industries)
                    {
                        _dbContext.Set<Industry>().Add(industry);
                    }
                    await _dbContext.SaveChangesAsync();
                }
            }

            if (_dbContext.SubIndustries?.Count() == 0)
            {

                var subIndustryData = File.ReadAllText("../Chartwell.Infrastructure/Data/DataSeeds/SubIndustry.JSON");
                var subindustries = JsonSerializer.Deserialize<List<SubIndustry>>(subIndustryData);

                if (subindustries?.Count() > 0)
                {
                    foreach (var subIndustry in subindustries)
                    {
                        _dbContext.Set<SubIndustry>().Add(subIndustry);
                    }
                    await _dbContext.SaveChangesAsync();
                }
            }

            if (_dbContext.CompanyExpertise?.Count() == 0)
            {

                var companyExpertiseData = File.ReadAllText("../Chartwell.Infrastructure/Data/DataSeeds/CompanyExpertise.JSON");
                var companyExpertise = JsonSerializer.Deserialize<List<CompanyExpertise>>(companyExpertiseData);

                if (companyExpertise?.Count() > 0)
                {
                    foreach (var companyEXpertise in companyExpertise)
                    {
                        _dbContext.Set<CompanyExpertise>().Add(companyEXpertise);
                    }
                    await _dbContext.SaveChangesAsync();
                }
            }

            if (_dbContext.DepartmentServices?.Count() == 0)
            {

                var departmentServicesData = File.ReadAllText("../Chartwell.Infrastructure/Data/DataSeeds/DepartmentServices.JSON");
                var departmentServices = JsonSerializer.Deserialize<List<DepartmentService>>(departmentServicesData);

                if (departmentServices?.Count() > 0)
                {
                    foreach (var Departmentservice in departmentServices)
                    {
                        _dbContext.Set<DepartmentService>().Add(Departmentservice);
                    }
                    await _dbContext.SaveChangesAsync();
                }
            }

            if (_dbContext.OurFirms?.Count() == 0)
            {

                var ourFirmsData = File.ReadAllText("../Chartwell.Infrastructure/Data/DataSeeds/OurFirm.JSON");
                var OurFirms = JsonSerializer.Deserialize<List<OurFirm>>(ourFirmsData);

                if (OurFirms?.Count() > 0)
                {
                    foreach (var ourFirm in OurFirms)
                    {
                        _dbContext.Set<OurFirm>().Add(ourFirm);
                    }
                    await _dbContext.SaveChangesAsync();
                }
            }

            if (_dbContext.TeamRoleTitles?.Count() == 0)
            {

                var teamRoleTitlesData = File.ReadAllText("../Chartwell.Infrastructure/Data/DataSeeds/TeamRoleTitle.JSON");
                var teamRoleTitles = JsonSerializer.Deserialize<List<TeamRoleTitle>>(teamRoleTitlesData);

                if (teamRoleTitles?.Count() > 0)
                {
                    foreach (var teamRoleTitle in teamRoleTitles)
                    {
                        _dbContext.Set<TeamRoleTitle>().Add(teamRoleTitle);
                    }
                    await _dbContext.SaveChangesAsync();
                }
            }

            if (_dbContext.TeamMembers?.Count() == 0)
            {

                var teamMembersData = File.ReadAllText("../Chartwell.Infrastructure/Data/DataSeeds/TeamMember.JSON");
                var teamMembers = JsonSerializer.Deserialize<List<TeamMember>>(teamMembersData);

                if (teamMembers?.Count() > 0)
                {
                    foreach (var teamMember in teamMembers)
                    {

                        _dbContext.Set<TeamMember>().Add(teamMember);
                    }
                    await _dbContext.SaveChangesAsync();
                }
            }

            if (_dbContext.OverViewSections?.Count() == 0)
            {

                var overViewData = File.ReadAllText("../Chartwell.Infrastructure/Data/DataSeeds/OverViewSection.JSON");
                var overViews = JsonSerializer.Deserialize<List<OverViewSection>>(overViewData);

                if (overViews?.Count() > 0)
                {
                    foreach (var overView in overViews)
                    {

                        _dbContext.Set<OverViewSection>().Add(overView);
                    }
                    await _dbContext.SaveChangesAsync();
                }
            }

            if (_dbContext.CompanyInfo?.Count() == 0)
            {

                var companyInfoData = File.ReadAllText("../Chartwell.Infrastructure/Data/DataSeeds/CompanyInfo.JSON");
                var companyInfo = JsonSerializer.Deserialize<List<CompanyInfo>>(companyInfoData);

                if (companyInfo?.Count() > 0)
                {
                    foreach (var CInfo in companyInfo)
                    {

                        _dbContext.Set<CompanyInfo>().Add(CInfo);
                    }
                    await _dbContext.SaveChangesAsync();
                }
            }

            if (_dbContext.Addresses?.Count() == 0)
            {

                var addressData = File.ReadAllText("../Chartwell.Infrastructure/Data/DataSeeds/Address.JSON");
                var address = JsonSerializer.Deserialize<List<Address>>(addressData);

                if (address?.Count() > 0)
                {
                    foreach (var addresses in address)
                    {

                        _dbContext.Set<Address>().Add(addresses);
                    }
                    await _dbContext.SaveChangesAsync();
                }
            }

        }

    }
}
