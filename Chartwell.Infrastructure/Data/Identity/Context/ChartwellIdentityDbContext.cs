using Chartwell.Core.Entity.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chartwell.Infrastructure.Data.Identity.Context
{
    public class ChartwellIdentityDbContext : IdentityDbContext<AppUser>
    {
        public ChartwellIdentityDbContext(DbContextOptions<ChartwellIdentityDbContext> options)
            : base(options)
        {
            
        }
    }
}
