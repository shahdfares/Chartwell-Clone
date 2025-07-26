using AutoMapper;
using AutoMapper.Execution;
using Chartwell.Core.DTOs.CompanyExpertise;
using Chartwell.Core.DTOs.CompanyExpertises;
using Chartwell.Core.DTOs.TeamRoleTitles;
using Chartwell.Core.Entity.ExpertisesNews;
using Chartwell.Core.Entity.TeamMembers;
using Chartwell.Core.RepositoryContract;
using Chartwell.Core.Services.Contract.CompanyExpertises;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chartwell.Application.CompanyExpertisesServices
{
    public class CompanyExpertiseService : ICompanyExpertiseService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CompanyExpertiseService(IUnitOfWork unitOfWork,
                                       IMapper mapper)
        {
           _unitOfWork = unitOfWork;
           _mapper = mapper;
        }
     
        public async Task<IReadOnlyList<CompanyExpertiseToReturnDTO>> GetAllAsync()
        {
            var allExpertise = await _unitOfWork.Repository<CompanyExpertise>().GetAllAsync();

            return _mapper.Map<IReadOnlyList<CompanyExpertiseToReturnDTO>>(allExpertise);
        }

        public async Task<CompanyExpertiseToReturnDTO> GetEntityAsync(int? id)
        {
            if (id is null)
                return null;

            var entity = await _unitOfWork.Repository<CompanyExpertise>().GetEntityAsync(id.Value);

            if (entity is null)
                return null;

            return _mapper.Map<CompanyExpertiseToReturnDTO>(entity);
        }

        public async Task<List<string>> GenerateSlugAsync()
        {
            var repo =  _unitOfWork.Repository<CompanyExpertise>();

            var allExpertise = await repo.GetAllAsync();
           
            var slugs = new List<string>();

            foreach(var expertise in allExpertise)
            {
                var slug = SlugHelper.GenerateSlug(expertise.Name);
                expertise.Slug = slug;

                repo.Update(expertise);

                slugs.Add(slug);
            }

            await _unitOfWork.CompleteAsync();

            return slugs;
        }

        public async Task<CompanyExpertiseToReturnDTO> CreateOrUpdateAsync(CompanyExpertiseDTO companyExpertiseDTO)
        {
            if (companyExpertiseDTO is null)
                return null;

            var repo = _unitOfWork.Repository<CompanyExpertise>();

            var entity = await repo.GetEntityAsync(companyExpertiseDTO.Id);

            if (entity is null)
            {
                // Create 

                var roleMapping = _mapper.Map<CompanyExpertise>(companyExpertiseDTO);

                if (roleMapping is null)
                    throw new Exception("Mapping Failed");

                roleMapping.Slug = SlugHelper.GenerateSlug(roleMapping.Name);

                await repo.AddAsync(roleMapping);

                await _unitOfWork.CompleteAsync();

                return _mapper.Map<CompanyExpertiseToReturnDTO>(roleMapping);
            }

            else
            {
                // Update 

                _mapper.Map(companyExpertiseDTO, entity);

                entity.Slug = SlugHelper.GenerateSlug(entity.Name);


                repo.Update(entity);

            }

            await _unitOfWork.CompleteAsync();

            return _mapper.Map<CompanyExpertiseToReturnDTO>(entity);
        }

        public async Task<bool> DeleteAsync(int? id)
        {
            if (id is null)
                return false;

            var repo = _unitOfWork.Repository<CompanyExpertise>();
           
            var entity = await repo.GetEntityAsync(id.Value);

            if (entity is null)
                return false;

            repo.Delete(entity);

            await _unitOfWork.CompleteAsync();

            return true;

        }
    }
}
