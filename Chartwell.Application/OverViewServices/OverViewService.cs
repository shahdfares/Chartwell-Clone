using AutoMapper;
using Chartwell.Core.DTOs.OverViewSections;
using Chartwell.Core.Entity.OverViewSections;
using Chartwell.Core.RepositoryContract;
using Chartwell.Core.Services.Contract.OverViewSectionServices;
using Chartwell.Core.Specification.OverViewSpecs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chartwell.Application.OverViewServices
{
    public class OverViewService : IOverViewService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public OverViewService(IUnitOfWork unitOfWork,
                               IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
      
        public async Task<IReadOnlyList<OverViewToReturnDTO>> GetAllAsync(OverViewSpecsParams specsParams)
        {
            var specs = new OverViewWithCompanyExpertiseAndServiceSpecs(specsParams);

            var allSections = await _unitOfWork.Repository<OverViewSection>().GetAllWithSpecAsync(specs);

            var data = _mapper.Map<IReadOnlyList<OverViewToReturnDTO>> (allSections);

            return data;
        }

        public async Task<OverViewToReturnDTO> GetEntityAsync(int? id)
        {
            if (id is null)
                return null;

            var specs = new OverViewWithCompanyExpertiseAndServiceSpecs(id.Value);

            var entity = await _unitOfWork.Repository<OverViewSection>().GetEntityWithSpecs(specs);

            if (entity is null)
                return null;

            var data = _mapper.Map< OverViewToReturnDTO>(entity);

            return data;
        }

        public async Task<OverViewSection> CreateOrUpdateAsync(overViewSectionDTO viewSectionDTO)
        {
            if (viewSectionDTO is null)
                return null;

            var repo = _unitOfWork.Repository<OverViewSection>();

            var entity = await repo.GetEntityAsync(viewSectionDTO.Id);

            if (entity is null)
            {
                // Create

                var mapping = _mapper.Map<OverViewSection>(viewSectionDTO);

                if (mapping is null)
                    throw new Exception("Mapping Failed");

                await repo.AddAsync(mapping);

                await _unitOfWork.CompleteAsync();

                return mapping;

            }

            else
            {
                // Update

                  _mapper.Map(viewSectionDTO, entity);
                
                  repo.Update(entity);
            }

            await _unitOfWork.CompleteAsync();

            return (entity);
        }

        public async Task<bool> DeleteAsync(int? id)
        {
            if (id is null)
                return false;

            var repo = _unitOfWork.Repository<OverViewSection>();

            var entity = await repo.GetEntityAsync(id.Value);

            if(entity is null)
                return false;

            repo.Delete(entity);

            await _unitOfWork.CompleteAsync();

            return true;
        }
    }
}
