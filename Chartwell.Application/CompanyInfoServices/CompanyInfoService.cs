using AutoMapper;
using Chartwell.Core.DTOs.CompanyINFO;
using Chartwell.Core.DTOs.CompanyServices;
using Chartwell.Core.Entity.Company;
using Chartwell.Core.Entity.CompanyServices;
using Chartwell.Core.RepositoryContract;
using Chartwell.Core.Services.Contract.CompanyInfoServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chartwell.Application.CompanyInfoServices
{
    public class CompanyInfoService : ICompanyInfoService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CompanyInfoService(IUnitOfWork unitOfWork,
                                  IMapper mapper)
        {
            _unitOfWork = unitOfWork;
           _mapper = mapper;
        }
        public async Task<IReadOnlyList<CompanyInfoToReturnDTO>> GetAllAsync()
        {
            var allInfo = await _unitOfWork.Repository<CompanyInfo>().GetAllAsync();
  
            return _mapper.Map<IReadOnlyList<CompanyInfoToReturnDTO>>(allInfo);
        }

        public async Task<CompanyInfoToReturnDTO> UpdateAsync(CompanyInfoDTO companyInfoDTO)
        {
            if (companyInfoDTO is null)
                return null;

            var repo = _unitOfWork.Repository<CompanyInfo>();

            var entity = await repo.GetEntityAsync(companyInfoDTO.Id);

            if (entity is null)
                return null;

            _mapper.Map(companyInfoDTO, entity);

            repo.Update(entity);

            var result = await _unitOfWork.CompleteAsync();

            if (result <= 0)
                return null;

            return _mapper.Map<CompanyInfoToReturnDTO>(entity);
        }
    }
}
