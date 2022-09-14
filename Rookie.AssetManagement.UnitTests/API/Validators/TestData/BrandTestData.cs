using Rookie.AssetManagement.Contracts.Constants;
using Rookie.AssetManagement.Contracts.Dtos;
using Rookie.AssetManagement.Contracts.Dtos.BrandDtos;
using Rookie.AssetManagement.Contracts.Dtos.EnumDtos;
using Rookie.AssetManagement.DataAccessor.Entities;
using Rookie.AssetManagement.DataAccessor.Enums;
using System.Collections.Generic;

namespace Rookie.AssetManagement.UnitTests.API.Validators.TestData
{
    public static class BrandTestsData
    {
        public static IEnumerable<object[]> ValidTexts()
        {
            return new object[][]
            {
                new object[] { "Mac Pro 2021 M1" },
                new object[] { "Lenovo ThinkIdea 2020" },
            };
        }

        public static IEnumerable<object[]> ValidIds()
        {
            return new object[][]
            {
                new object[] { 1 },
                new object[] { 2 },
            };
        }

        public static IEnumerable<object[]> InvalidIds()
        {
            return new object[][]
            {
                new object[]
                {
                    -1,
                    string.Format(ErrorTypes.Common.NumberGreaterThanError, nameof(BrandDto.Id), 0),
                },
                new object[]
                {
                    -2,
                    string.Format(ErrorTypes.Common.NumberGreaterThanError, nameof(BrandDto.Id), 0),
                },
            };
        }

        public static int UnExistedBrandId = 3;
        public static int ExistedBrandId = 1;

        public static BrandCreateDto GetCreateBrandDto()
        {
            return new BrandCreateDto() {
                Name = "Test Brand",
                Type = BrandTypeEnumDto.Normal
            };
        }

        public static BrandUpdateDto GetUpdateBrandDto()
        {
            return new BrandUpdateDto() {
                Type = BrandTypeEnumDto.Luxury
            };
        }

        public static Brand GetUpdateBrand()
        {
            var updateBrand = GetBrand(ExistedBrandId);
            updateBrand.Type = BrandTypeEnum.Luxury;
            return updateBrand;
        }

        public static Brand GetBrand(int id, bool isDeleted = false)
        {
            return new Brand() {
                Id = id,
                Name = "Test Brand",
                Type = BrandTypeEnum.Normal,
                IsDeleted = isDeleted
            };
        }

        public static List<Brand> GetBrands()
        {
            return new List<Brand>() {
                new Brand() {
                    Id = 1,
                    Name = "Test Brand 1",
                    Type = BrandTypeEnum.Normal,
                    IsDeleted = false
                },
                new Brand() {
                    Id = 2,
                    Name = "Test Brand 2",
                    Type = BrandTypeEnum.Normal,
                    IsDeleted = false
                }
            };
        }
    }
}
