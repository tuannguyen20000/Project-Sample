using System.Collections.Generic;
using Services.Brands.BrandsSPA.Rookie.AssetManagement.Contracts.Dtos.EnumDtos;

namespace Services.Brands.BrandsSPA.Rookie.AssetManagement.Contracts.Dtos.BrandDtos
{
    public class BrandQueryCriteriaDto : BaseQueryCriteria
    {
        public int[] Types { get; set; }
        public int Id { get; set; }
    }
}
