using AutoMapper;
using Chartwell.Core.DTOs.TeamMembers;
using Chartwell.Core.Entity.TeamMembers;
using Chartwell.Core.RepositoryContract;
using Chartwell.Core.Services.Contract.TeamMemberService;
using Chartwell.Core.Specification.TeamMemberSpecs;

namespace Chartwell.Application.TeamMemberService
{
    public class TeamMemberService : ITeamMemberService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public TeamMemberService(IUnitOfWork unitOfWork,
               IMapper mapper)
                               
        {
           _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
      
        public async Task<IReadOnlyList<TeamMemberToReturnDTO>> GetAllAsync(TeamMemberSpecsParams specsParams)
        {
            var specs = new TeamMemberWithAllSpecs(specsParams);

            var allNews = await _unitOfWork.Repository<TeamMember>().GetAllWithSpecAsync(specs);

            return _mapper.Map<IReadOnlyList<TeamMemberToReturnDTO>>(allNews);
        }

        public async Task<TeamMemberToReturnDTO> GetByIdAsync(int? id)
        {
            if (id is null)
                return null;

            var specs = new TeamMemberWithAllSpecs(id.Value);

            var member = await _unitOfWork.Repository<TeamMember>().GetEntityWithSpecs(specs);

            if (member is null)
                return null;

            var memberMapping = _mapper.Map<TeamMemberToReturnDTO>(member);

            return memberMapping;
        }
        
        public async Task<List<string>> GenerateSlugsForAllTeamMembersAsync()
        {
            var repo = _unitOfWork.Repository<TeamMember>();

            var allMembers = await repo.GetAllAsync();

            var slugs = new List<string>();

            foreach(var member in allMembers)
            {
                var slug = SlugHelper.GenerateSlug($"{member.FirstName}-{member.LastName}");
                
                member.Slug = slug;

                repo.Update(member);

                slugs.Add(slug);
            }

            await _unitOfWork.CompleteAsync();

            return slugs;
        }

        public async Task<TeamMemberToReturnDTO?> CreateOrUpdateAsync(TeamMemberDTO memberDTO)
        {
            if (memberDTO is null)
                return null;

            var repo = _unitOfWork.Repository<TeamMember>();

            var existing = await repo.GetEntityAsync(memberDTO.Id);

            if (existing == null)
            {
                // Create
                var member = _mapper.Map<TeamMember>(memberDTO);

                if (member is null)
                    throw new Exception("Mapping failed");

                member.Slug = SlugHelper.GenerateSlug($"{member.FirstName}-{member.LastName}");
              
                await repo.AddAsync(member);

                var data = _mapper.Map<TeamMemberToReturnDTO>(member);

              var result =  await _unitOfWork.CompleteAsync();

                if(result <= 0)
                    return null;

                return data;    
                   
            }
            else
            {
                // Update
                _mapper.Map(memberDTO, existing);

                existing.Slug = SlugHelper.GenerateSlug($"{existing.FirstName}-{existing.LastName}");

                repo.Update(existing);
            }

            await _unitOfWork.CompleteAsync();
                
            return _mapper.Map<TeamMemberToReturnDTO>(existing);
        }

        public async Task<bool> DeleteAsync(int? id)
        {
            if (id is null)
                return false;

            var getEntity =  _unitOfWork.Repository<TeamMember>();

            var entity = await getEntity.GetEntityAsync(id.Value);

            if (entity is null)
                return false;

            getEntity.Delete(entity);

            await _unitOfWork.CompleteAsync();

            return true;
          
        }
    }
}
