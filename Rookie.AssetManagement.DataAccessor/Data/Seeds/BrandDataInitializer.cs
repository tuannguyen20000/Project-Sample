using Microsoft.EntityFrameworkCore;
using Rookie.AssetManagement.DataAccessor.Entities;
using Rookie.AssetManagement.DataAccessor.Enums;

namespace Rookie.AssetManagement.DataAccessor.Data.Seeds
{
    public static class BrandDataInitializer
    {
        public static void SeedBrandData(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Brand>().HasData(
                new Brand
                {
                    Id = 1,
                    Name = "Test Brand 1",
                    Type = (BrandTypeEnum)BrandTypeEnum.Normal
                },
                new Brand
                {
                    Id = 2,
                    Name = "Test Brand 2",
                    Type = (BrandTypeEnum)BrandTypeEnum.Normal
                },
                new Brand
                {
                    Id = 3,
                    Name = "Test Brand 3",
                    Type = (BrandTypeEnum)BrandTypeEnum.Normal
                },
                new Brand
                {
                    Id = 4,
                    Name = "Test Brand 4",
                    Type = (BrandTypeEnum)BrandTypeEnum.Luxury
                },
                new Brand
                {
                    Id = 5,
                    Name = "Test Brand 5",
                    Type = (BrandTypeEnum)BrandTypeEnum.Luxury
                },
                new Brand
                {
                    Id = 6,
                    Name = "Test Brand 6",
                    Type = (BrandTypeEnum)BrandTypeEnum.Luxury
                }
            );
        }
    }
}