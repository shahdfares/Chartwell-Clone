using Chartwell.Core.DTOs.CompanyExpertise;
using Chartwell.Core.DTOs.CompanyExpertises;
using Chartwell.Core.Entity.ExpertisesNews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chartwell.Core.Services.Contract.CompanyExpertises
{
    public interface ICompanyExpertiseService
    {
        Task<IReadOnlyList<CompanyExpertiseToReturnDTO>> GetAllAsync();
        Task<CompanyExpertiseToReturnDTO> GetEntityAsync(int? id);
        Task<List<string>> GenerateSlugAsync();
        Task<CompanyExpertiseToReturnDTO> CreateOrUpdateAsync(CompanyExpertiseDTO companyExpertiseDTO);
        Task<bool> DeleteAsync(int? id);
    }
}
