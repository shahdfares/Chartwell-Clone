using AutoMapper;
using Chartwell.Core.DTOs.OurFirms;
using Chartwell.Core.Entity.CompanyServices;
using Chartwell.Core.Entity.OurFirms;
using Chartwell.Core.Entity.OverViewSections;
using Chartwell.Core.RepositoryContract;
using Chartwell.Core.Services.Contract.OurFirms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chartwell.Application.OurFirms
{
    public class OurFirmService : IOurFirmService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public OurFirmService(IUnitOfWork unitOfWork,
                              IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IReadOnlyList<OurFirmToReturnDTO>> GetAllAsync()
        {
           var allFirms = await _unitOfWork.Repository<OurFirm>().GetAllAsync();

            return _mapper.Map<IReadOnlyList<OurFirmToReturnDTO>>(allFirms);
        }

        public async Task<OurFirmToReturnDTO> GetEntityAsync(int? id)
        {
            if (id is null)
                return null;

            var firm =  _unitOfWork.Repository<OurFirm>().GetEntityAsync(id.Value);

            if (firm is null)
                return null;

            return _mapper.Map<OurFirmToReturnDTO>(firm);
        }
        public async Task<OurFirmToReturnDTO?> CreateOrUpdateFirm(OurFirmDTO firmDTO)
        {
            if (firmDTO is null)
                return null;

            var repo = _unitOfWork.Repository<OurFirm>();

            var entity = await repo.GetEntityAsync(firmDTO.Id);

            if (entity is null)
            {
                // Create

                var mapping = _mapper.Map<OurFirm>(firmDTO);

                if (mapping is null)
                    throw new Exception("Mapping Failed");

                await repo.AddAsync(mapping);

              var result =  await _unitOfWork.CompleteAsync();

                if(result <= 0)
                    return null;

                return _mapper.Map<OurFirmToReturnDTO>(mapping);

            }

            else
            {
                // Update

                _mapper.Map(firmDTO, entity);

                repo.Update(entity);
            }

            await _unitOfWork.CompleteAsync();

            return _mapper.Map<OurFirmToReturnDTO>(entity);
        }

        public async Task<bool> DeleteFirmAsync(int? id)
        {
            if (id is null)
                return false;

            var getFirm = _unitOfWork.Repository<OurFirm>();

            var firm = await getFirm.GetEntityAsync(id.Value);

            if (firm is null)
                return false;

            getFirm.Delete(firm);

            var result = await _unitOfWork.CompleteAsync();

            if(result <= 0)
                return false;

            return true;

        }
    }
}
