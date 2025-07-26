using Chartwell.Core.DTOs.Industries;
using Chartwell.Core.DTOs.SubIndustries;
using Chartwell.Core.Specification.IndustrySpecs;
using Chartwell.Core.Specification.SubIndustrySpecs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chartwell.Core.Services.Contract.SubIndustryServices
{
    public interface ISubIndustryService
    {
        Task<IReadOnlyList<SubIndustryToReturnDTO>> GetAllAsync(SubIndustrySpecParams specParams);
        Task<SubIndustryToReturnDTO> GetByIdAsync(int? id);
        Task<SubIndustryToReturnDTO> CreateOrUpdateAsync(SubIndustryDTO industryDTO);
        Task<bool> DeleteAsync(int? id);
    }
}
