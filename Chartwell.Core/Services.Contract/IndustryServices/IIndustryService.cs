using Chartwell.Core.DTOs.Industries;
using Chartwell.Core.Entity.CompanyServices;
using Chartwell.Core.Specification.IndustrySpecs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chartwell.Core.Services.Contract.Industries
{
    public interface IIndustryService
    {
        Task<IReadOnlyList<IndustryToReturnDTO>> GetAllAsync(IndustrySpecParams specParams);
        Task<IndustryToReturnDTO> GetByIdAsync(int? id);
        Task<IndustryToReturnDTO> CreateOrUpdateAsync(IndustryDTO industryDTO);
        Task<bool> DeleteAsync(int? id);
    }
}
