using Chartwell.Core.DTOs.OurFirms;
using Chartwell.Core.Entity.OurFirms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chartwell.Core.Services.Contract.OurFirms
{
    public interface IOurFirmService
    {
        Task<IReadOnlyList<OurFirmToReturnDTO>> GetAllAsync();
        Task<OurFirmToReturnDTO> GetEntityAsync(int? id);
        Task<OurFirmToReturnDTO?> CreateOrUpdateFirm(OurFirmDTO firmDTO);
       Task<bool> DeleteFirmAsync(int? id);
    }
}
