using Chartwell.Core.Entity.Identity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chartwell.Infrastructure.Data.Identity.DataSeeds
{
    public class ChartwellIdentityContextSeeds
    {
        public static async Task SeedAppUserAsync(UserManager<AppUser> userManager)
        {
            if (userManager.Users.Count() == 0)
            {
                var user = new AppUser()
                {
                    Email = "shahdfares708@gmail.com",
                    DisplayName = "Shahd Fares",
                    UserName = "shahd_fares",
                    PhoneNumber = "0158785223",
                    Address = new Address()
                    {
                        FirstName = "Shahd",
                        LastName = "Fares",
                        Street = "10th",
                        City = "LA",
                        Country = "US"

                    }
                };

                await userManager.CreateAsync(user, "P@ssw0rd");
            }
        }
    }
}

