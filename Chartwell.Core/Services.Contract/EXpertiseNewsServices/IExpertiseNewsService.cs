using Chartwell.Core.DTOs.CompanyExpertises;
using Chartwell.Core.DTOs.EXpertiseNews;
using Chartwell.Core.Entity.ExpertisesNews;
using Chartwell.Core.Specification.ExpertiseNewsSpecs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chartwell.Core.Services.Contract.EXpertiseNewsServices
{
    public interface IExpertiseNewsService
    {
        Task<ExpertiseNewsToReturnDTO> CreateOrUpdateAsync(ExpertiseNewsDTO expertiseNewsDTO);
        Task<IReadOnlyList<ExpertiseNewsToReturnDTO>> GetAllAsync(ExpertiseNewsSpecParams specParams);
        Task<ExpertiseNewsToReturnDTO> GetEntityAsync(int? id);
        Task<bool> DeleteAsync(int? id);
    }
}
