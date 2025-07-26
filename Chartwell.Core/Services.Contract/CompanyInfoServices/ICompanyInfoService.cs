using Chartwell.Core.DTOs.CompanyINFO;
using Chartwell.Core.Entity.Company;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chartwell.Core.Services.Contract.CompanyInfoServices
{
    public interface ICompanyInfoService
    {
        Task<IReadOnlyList<CompanyInfoToReturnDTO>> GetAllAsync();
        Task<CompanyInfoToReturnDTO> UpdateAsync(CompanyInfoDTO companyInfoDTO);
    }
}
