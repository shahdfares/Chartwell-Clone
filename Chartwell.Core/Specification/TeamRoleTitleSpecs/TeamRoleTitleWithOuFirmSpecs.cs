using Chartwell.Core.Entity.TeamMembers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chartwell.Core.Specification.TeamRoleTitleSpecs
{
    public class TeamRoleTitleWithOuFirmSpecs : BaseSpecification<TeamRoleTitle>
    {
        public TeamRoleTitleWithOuFirmSpecs(TeamRoleTitleSpecParams specParams) 
            : base (P => (!specParams.OurFirmId.HasValue || P.OurFirmId == specParams.OurFirmId.Value))
        {
            ApplyInclude();
        }

        public TeamRoleTitleWithOuFirmSpecs(int? id)
            : base(P => P.Id == id)
        {
            ApplyInclude();
        }
        private void ApplyInclude()
        {
            Include.Add(P => P.OurFirm);
        }
    }
}

