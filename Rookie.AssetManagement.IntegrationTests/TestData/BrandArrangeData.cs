using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Rookie.AssetManagement.Business.Services;
using Rookie.AssetManagement.Constants;
using Rookie.AssetManagement.Contracts.Dtos.BrandDtos;
using Rookie.AssetManagement.DataAccessor.Data;
using Rookie.AssetManagement.DataAccessor.Entities;
using Rookie.AssetManagement.DataAccessor.Enums;

namespace Rookie.AssetManagement.IntegrationTests.TestData
{
    public static class BrandArrangeData
    {
        public static List<Brand> GetSeedBrandsData()
        {
            return new List<Brand>()
            {
                new Brand()
                {
                    Name = "Test Brand 1",
                    Type = BrandTypeEnum.Normal
                },
                new Brand()
                {
                    Name = "Test Brand 2",
                    Type = BrandTypeEnum.Normal
                },
                new Brand()
                {
                    Name = "Test Brand 3",
                    Type = BrandTypeEnum.Normal
                },
                new Brand()
                {
                    Name = "Test Brand 4",
                    Type = BrandTypeEnum.Luxury
                },
                new Brand()
                {
                    Name = "Test Brand 5",
                    Type = BrandTypeEnum.Luxury
                },
                new Brand()
                {
                    Name = "Test Brand 6",
                    Type = BrandTypeEnum.Luxury
                }
            };
        }

        public static void InitBrandsData(ApplicationDbContext dbContext)
        {
            var brands = GetSeedBrandsData();
            dbContext.Brands.AddRange(brands);
            dbContext.SaveChanges();
        }

        public static BrandQueryCriteriaDto GetBrandQueryCriteriaDto()
        {
            return new BrandQueryCriteriaDto()
            {
                Limit = 5,
                Page = 1
            };
        }
    }
}