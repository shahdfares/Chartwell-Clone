using AutoMapper;
using Chartwell.Core.DTOs.Industries;
using Chartwell.Core.Entity.CompanyServices;
using Chartwell.Core.Entity.OverViewSections;
using Chartwell.Core.RepositoryContract;
using Chartwell.Core.Services.Contract.Industries;
using Chartwell.Core.Specification.IndustrySpecs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chartwell.Application.IndustryServices
{
    public class IndustryService : IIndustryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public IndustryService(IUnitOfWork unitOfWork,
                               IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IReadOnlyList<IndustryToReturnDTO>> GetAllAsync(IndustrySpecParams specParams)
        {
            var specs = new IndustryWithCompanyServicesSpecs(specParams);

            var allIndustries = await _unitOfWork.Repository<Industry>().GetAllWithSpecAsync(specs); 

            var data = _mapper.Map<IReadOnlyList<IndustryToReturnDTO>>(allIndustries);

            return data;
        }

        public async Task<IndustryToReturnDTO> GetByIdAsync(int? id)
        {
            if (id is null)
                return null;

            var specs = new IndustryWithCompanyServicesSpecs(id.Value);

            var entity = await _unitOfWork.Repository<Industry>().GetEntityWithSpecs(specs);

            if (entity is null)
                return null;

            var mappingEntity = _mapper.Map<IndustryToReturnDTO>(entity);

            return mappingEntity;
        }

        public async Task<IndustryToReturnDTO> CreateOrUpdateAsync(IndustryDTO industryDTO)
        {
            if (industryDTO is null)
                return null;

            var repo = _unitOfWork.Repository<Industry>();

            var entity = await repo.GetEntityAsync(industryDTO.Id);

            if (entity is null)
            {
                // Create

                var mapping = _mapper.Map<Industry>(industryDTO);

                if (mapping is null)
                    throw new Exception("Mapping Failed");

                await repo.AddAsync(mapping);

                await _unitOfWork.CompleteAsync();

                var result = _mapper.Map<IndustryToReturnDTO>(mapping);

                return result;

            }

            else
            {
                // Update 

                _mapper.Map(industryDTO, entity);

                repo.Update(entity);
            }

            var updated = await repo.GetEntityAsync(industryDTO.Id);

            await _unitOfWork.CompleteAsync();

            return _mapper.Map<IndustryToReturnDTO>(updated);
        }

        public async Task<bool> DeleteAsync(int? id)
        {
            if (id is null)
                return false;

            var repo = _unitOfWork.Repository<Industry>();

            var entity = await repo.GetEntityAsync(id.Value);

            if(entity is null)
                return false;

             repo.Delete(entity);

            await _unitOfWork.CompleteAsync();

            return true;
        }
    }
}
