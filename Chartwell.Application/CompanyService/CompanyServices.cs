using Chartwell.Core.Services.Contract.CompanyServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chartwell.Core.RepositoryContract;
using Chartwell.Core.DTOs.CompanyServices;
using Chartwell.Core.Entity.CompanyServices;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Chartwell.Application.CompanyServices
{
    public class CompanyServices : ICompanyServices
    {
        private readonly IUnitOfWork  _unitOfWork;
        private readonly IMapper _mapper;

        public CompanyServices(IUnitOfWork  unitOfWork,
                              IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

       
        public async Task<IReadOnlyList<CompanyServiceToReturnDTO>> GetAllAsync()
        {
            var allService = await _unitOfWork.Repository<CompanyService>().GetAllAsync();
           
            return _mapper.Map<IReadOnlyList<CompanyServiceToReturnDTO>>(allService);
        }

        public async Task<CompanyServiceToReturnDTO> GetByIdAsync(int? id)
        {
            if (id is null)
                return null;

            var service = await _unitOfWork.Repository<CompanyService>().GetEntityAsync(id.Value);

            if (service is null)
                return null;

            return _mapper.Map<CompanyServiceToReturnDTO>(service);
        }
        public async Task<CompanyServiceToReturnDTO> AddAsync(CompanyServicesDTO servicesDTO)
        {

       
         var repo =  _unitOfWork.Repository<CompanyService>();

         var mapping = _mapper.Map<CompanyService>(servicesDTO);
          
         await repo.AddAsync(mapping);   

         var result =  await _unitOfWork.CompleteAsync();

            if (result <= 0)
                return null;

            return _mapper.Map<CompanyServiceToReturnDTO>(mapping);
        }

        public async Task<CompanyServiceToReturnDTO?> UpdateAsync(CompanyServicesDTO serviceDto)
        {
            if(serviceDto is null)
                return null;

            var repo = _unitOfWork.Repository<CompanyService>();

            var existingService = await repo.GetEntityAsync(serviceDto.Id);

            if (existingService is null)
                return null;

           _mapper.Map(serviceDto, existingService);

             repo.Update(existingService);

            var result = await _unitOfWork.CompleteAsync();

            if (result <= 0)
                return null;

            return _mapper.Map<CompanyServiceToReturnDTO>(existingService);
        }

        public async Task<bool> DeleteAsync(int? id)
        {
            if (id is null)
                return false;

            var getService = _unitOfWork.Repository<CompanyService>();

            var service = await getService.GetEntityAsync(id.Value);

            if (service is null)
                return false;

            getService.Delete(service);

            var result = await _unitOfWork.CompleteAsync();

            if(result <= 0)
                return false;

            return true;

        }

    }
}
