using AutoMapper;
using Chartwell.Core.DTOs.TeamRoleTitles;
using Chartwell.Core.Entity.TeamMembers;
using Chartwell.Core.RepositoryContract;
using Chartwell.Core.Services.Contract.TeamMemberService;
using Chartwell.Core.Services.Contract.TeamRoleTitleServices;
using Chartwell.Core.Specification.TeamRoleTitleSpecs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chartwell.Application.TeamRolesTitle
{
    public class TeamRoleTitleService : ITeamRoleTitleService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public TeamRoleTitleService(IUnitOfWork unitOfWork,
                                    IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IReadOnlyList<TeamRoleTitleToReturnDTO>> GetAllAsync(TeamRoleTitleSpecParams specParams)
        {
            var specs = new TeamRoleTitleWithOuFirmSpecs(specParams);

            var allRoles = await _unitOfWork.Repository<TeamRoleTitle>().GetAllWithSpecAsync(specs);

            return _mapper.Map<IReadOnlyList<TeamRoleTitleToReturnDTO>>(allRoles);
        }

        public async Task<TeamRoleTitleToReturnDTO> GetEntityAsync(int? id)
        {
            if (id is null)
                return null;

            var specs = new TeamRoleTitleWithOuFirmSpecs(id.Value);


            var entity = await _unitOfWork.Repository<TeamRoleTitle>().GetEntityWithSpecs(specs);

            if (entity is null)
                return null;

            return _mapper.Map<TeamRoleTitleToReturnDTO>(entity);
        }

        public async Task<TeamRoleTitleToReturnDTO> CreateOrUpdateAsync(TeamRoleTitleDTO teamRoleTitleDTO)
        {
            if (teamRoleTitleDTO is null)
                return null;

            var repo = _unitOfWork.Repository<TeamRoleTitle>();

            var entity = await repo.GetEntityAsync(teamRoleTitleDTO.Id);

            if(entity is null)
            {
                // Create 

                var roleMapping = _mapper.Map<TeamRoleTitle>(teamRoleTitleDTO);

                if (roleMapping is null)
                    throw new Exception("Mapping Failed");

                await repo.AddAsync(roleMapping);

                await _unitOfWork.CompleteAsync();

                return _mapper.Map<TeamRoleTitleToReturnDTO>(roleMapping);
            }

            else
            {
                // Update 

                _mapper.Map(teamRoleTitleDTO, entity);

                repo.Update(entity);

            }
             
            await _unitOfWork.CompleteAsync();

            return _mapper.Map<TeamRoleTitleToReturnDTO>(entity);
        }

        public async Task<bool> DeleteAsync(int? id)
        {
            if (id is null)
                return false;

            var getEntity = _unitOfWork.Repository<TeamRoleTitle>();

            var entity = await getEntity.GetEntityAsync(id.Value);

            if (entity is null) 
                return false;

            getEntity.Delete(entity);

            await _unitOfWork.CompleteAsync();

            return true;
        }
    }
}
