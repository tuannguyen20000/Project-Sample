using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using Services.Brands.BrandsSPA.Rookie.AssetManagement.DataAccessor.Entities;

namespace Services.Brands.BrandsSPA.Rookie.AssetManagement.DataAccessor.Data.Seeds
{
    public static class DefaultUsers
    {
        public static async Task SeedAsync(UserManager<User> userManager)
        {
            if (!userManager.Users.Any())
            {
                var adminHCM = new User
                {
                    UserName = "adminhcm"
                };

                await userManager.CreateAsync(adminHCM, "123456");
            }

        }
    }
}