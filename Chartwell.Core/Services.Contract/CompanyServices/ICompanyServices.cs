using Chartwell.Core.DTOs.CompanyServices;
using Chartwell.Core.Entity.CompanyServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Chartwell.Core.Services.Contract.CompanyServices
{
    public interface ICompanyServices
    {
        Task<IReadOnlyList<CompanyServiceToReturnDTO>> GetAllAsync();
        Task<CompanyServiceToReturnDTO> GetByIdAsync(int? id);
        Task<CompanyServiceToReturnDTO> AddAsync(CompanyServicesDTO serviceDto);
        Task<CompanyServiceToReturnDTO?> UpdateAsync(CompanyServicesDTO servicesDTO);
        Task<bool> DeleteAsync(int? id);

    }
}
