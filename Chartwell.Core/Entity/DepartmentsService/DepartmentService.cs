using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chartwell.Core.Entity.Departments
{
    public class DepartmentService : AuditableEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
       

    }
}
