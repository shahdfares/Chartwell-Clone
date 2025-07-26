using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chartwell.Core.Entity
{
    public abstract class AuditableEntity : BaseEntity
    {
        public bool IsActive { get; set; } = true;
        public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;
        public DateTime? UpdatesAt { get; set; } = DateTime.UtcNow;
    }
}
