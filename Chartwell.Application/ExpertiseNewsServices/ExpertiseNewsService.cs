using AutoMapper;
using Chartwell.Core.DTOs.CompanyExpertises;
using Chartwell.Core.DTOs.EXpertiseNews;
using Chartwell.Core.Entity.ExpertisesNews;
using Chartwell.Core.Entity.TeamMembers;
using Chartwell.Core.RepositoryContract;
using Chartwell.Core.Services.Contract.EXpertiseNewsServices;
using Chartwell.Core.Specification.ExpertiseNewsSpecs;

namespace Chartwell.Application.ExpertiseNewsServices
{
    public class ExpertiseNewsService : IExpertiseNewsService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ExpertiseNewsService(IUnitOfWork unitOfWork,
                                    IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<ExpertiseNewsToReturnDTO> CreateOrUpdateAsync(ExpertiseNewsDTO expertiseNewsDTO)
        {

            if (expertiseNewsDTO is null)
                return null;


            var repo = _unitOfWork.Repository<ExpertiseNews>();

            var entity = await repo.GetEntityAsync(expertiseNewsDTO.Id);

            if (entity is null)
            {
                // Create

                var mapping = _mapper.Map<ExpertiseNews>(expertiseNewsDTO);

                if (mapping is null)
                    throw new Exception("Mapping Failed");

                mapping.Slug = SlugHelper.GenerateSlug(mapping.Title);

                await repo.AddAsync(mapping);

                await _unitOfWork.CompleteAsync();

                return _mapper.Map<ExpertiseNewsToReturnDTO>(mapping);

            }

            else
            {
                // Update

                _mapper.Map(expertiseNewsDTO, entity);

                repo.Update(entity);
            }

            var updated = await repo.GetEntityAsync(expertiseNewsDTO.Id);

            entity.Slug = SlugHelper.GenerateSlug(entity.Title);

            await _unitOfWork.CompleteAsync();

            return _mapper.Map<ExpertiseNewsToReturnDTO>(updated);
        }

        public async Task<IReadOnlyList<ExpertiseNewsToReturnDTO>> GetAllAsync(ExpertiseNewsSpecParams specParams)
        {
            var specs = new ExpertiseNewWithCompanyExpertiseAndTeamMemberSpecs(specParams);

            var allNews = await _unitOfWork.Repository<ExpertiseNews>().GetAllWithSpecAsync(specs);

            return  _mapper.Map<IReadOnlyList<ExpertiseNewsToReturnDTO>>(allNews);
        }

        public async Task<ExpertiseNewsToReturnDTO> GetEntityAsync(int? id)
        {
            if (id is null)
                return null;

            var specs = new ExpertiseNewWithCompanyExpertiseAndTeamMemberSpecs(id.Value);

            var entity = await _unitOfWork.Repository<ExpertiseNews>().GetEntityWithSpecs(specs);

            if (entity is null)
                return null;

            return _mapper.Map<ExpertiseNewsToReturnDTO>(entity);
        }

        public async Task<bool> DeleteAsync(int? id)
        {
            if (id is null)
                return false;

            var repo = _unitOfWork.Repository<ExpertiseNews>();

            var entity = await repo.GetEntityAsync(id.Value);

            if (entity is null)
                return false;

            repo.Delete(entity);

            await _unitOfWork.CompleteAsync();

            return true;
        }

    }
}
