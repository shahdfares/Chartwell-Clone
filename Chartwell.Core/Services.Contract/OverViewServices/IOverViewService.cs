using Chartwell.Core.DTOs.OverViewSections;
using Chartwell.Core.Entity.OverViewSections;
using Chartwell.Core.Specification;
using Chartwell.Core.Specification.OverViewSpecs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chartwell.Core.Services.Contract.OverViewSectionServices
{
    public interface IOverViewService
    {
        Task<IReadOnlyList<OverViewToReturnDTO>> GetAllAsync(OverViewSpecsParams specsParams);
        Task<OverViewToReturnDTO> GetEntityAsync(int? id);

        Task<OverViewSection> CreateOrUpdateAsync(overViewSectionDTO viewSectionDTO);
        Task<bool> DeleteAsync(int? id);
        
    }
}
