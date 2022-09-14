using System.Collections.Generic;
using Rookie.AssetManagement.Contracts.Dtos.EnumDtos;

namespace Rookie.AssetManagement.Contracts.Dtos.BrandDtos
{
    public class BrandQueryCriteriaDto : BaseQueryCriteria
    {
        public int[] Types { get; set; }
        public int Id { get; set; }
    }
}
