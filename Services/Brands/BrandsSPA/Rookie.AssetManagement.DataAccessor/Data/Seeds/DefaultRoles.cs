using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Services.Brands.BrandsSPA.Rookie.AssetManagement.Constants;

namespace Services.Brands.BrandsSPA.Rookie.AssetManagement.DataAccessor.Data.Seeds
{
    public static class DefaultRoles
    {
        public static async Task SeedAsync(RoleManager<IdentityRole<int>> roleManager)
        {
            await roleManager.CreateAsync(new IdentityRole<int>(Roles.Staff.ToString()));
            await roleManager.CreateAsync(new IdentityRole<int>(Roles.Admin.ToString()));
        }
    }
}