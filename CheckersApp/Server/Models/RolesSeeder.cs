using CheckersApp.Server.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CheckersApp.Server.Models
{
    public class RolesSeeder
    {
        private ApplicationDbContext dbContext;

        public RolesSeeder(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async void SeedRoles()
        {
            var roleStore = new RoleStore<IdentityRole>(dbContext);

            if(!(dbContext.Roles.Any(r => r.Name == "administrator")))
            {
                await roleStore.CreateAsync(new IdentityRole { Name = "administrator", NormalizedName = "administrator" });
            }
            if (!(dbContext.Roles.Any(r => r.Name == "user")))
            {
                await roleStore.CreateAsync(new IdentityRole { Name = "user", NormalizedName = "user" });
            }
            if (!(dbContext.Roles.Any(r => r.Name == "moderator")))
            {
                await roleStore.CreateAsync(new IdentityRole { Name = "moderator", NormalizedName = "moderator" });
            }

            await dbContext.SaveChangesAsync();
        }
    }
}
