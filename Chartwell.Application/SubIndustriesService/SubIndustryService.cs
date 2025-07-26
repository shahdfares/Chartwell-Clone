using AutoMapper;
using Chartwell.Core.DTOs.Industries;
using Chartwell.Core.DTOs.SubIndustries;
using Chartwell.Core.Entity.CompanyServices;
using Chartwell.Core.RepositoryContract;
using Chartwell.Core.Services.Contract.SubIndustryServices;
using Chartwell.Core.Specification.SubIndustrySpecs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chartwell.Application.SubIndustriesService
{
    public class SubIndustryService : ISubIndustryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public SubIndustryService(IUnitOfWork unitOfWork,
                                  IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
      
        public async Task<IReadOnlyList<SubIndustryToReturnDTO>> GetAllAsync(SubIndustrySpecParams specParams)
        {
            var specs = new SubIndustryWithIndustrySpecs(specParams);

            var allSubIndustries = await _unitOfWork.Repository<SubIndustry>().GetAllWithSpecAsync(specs);

            var data = _mapper.Map<IReadOnlyList<SubIndustryToReturnDTO>>(allSubIndustries);

            return data;
        }

        public async Task<SubIndustryToReturnDTO> GetByIdAsync(int? id)
        {
            if (id is null)
                return null;

            var specs = new SubIndustryWithIndustrySpecs(id.Value);

            var entity = await _unitOfWork.Repository<SubIndustry>().GetEntityWithSpecs(specs);

            if (entity is null)
                return null;

            return _mapper.Map<SubIndustryToReturnDTO>(entity);
        }

        public async Task<SubIndustryToReturnDTO> CreateOrUpdateAsync(SubIndustryDTO subIndustryDTO)
        {
            if (subIndustryDTO is null)
                return null;

            var repo = _unitOfWork.Repository<SubIndustry>();

            var entity = await repo.GetEntityAsync(subIndustryDTO.Id);

            if (entity is null)
            {
                // Create

                var mapping = _mapper.Map<SubIndustry>(subIndustryDTO);

                if (mapping is null)
                    throw new Exception("Mapping Failed");

                await repo.AddAsync(mapping);

                await _unitOfWork.CompleteAsync();

                return _mapper.Map<SubIndustryToReturnDTO>(mapping);

            }

            else
            {
                // Update 

                _mapper.Map(subIndustryDTO, entity);

                repo.Update(entity);
            }

            var updated = await repo.GetEntityAsync(subIndustryDTO.Id);

            await _unitOfWork.CompleteAsync();

            return _mapper.Map<SubIndustryToReturnDTO>(updated);
        }

        public async Task<bool> DeleteAsync(int? id)
        {
            if (id is null)
                return false;

            var repo = _unitOfWork.Repository<SubIndustry>();

            var entity = await repo.GetEntityAsync(id.Value);

            if (entity is null)
                return false;

            repo.Delete(entity);

            await _unitOfWork.CompleteAsync();

            return true;
        }
    }
}
