using System;
using Rookie.AssetManagement.Contracts.Dtos.EnumDtos;

namespace Rookie.AssetManagement.Contracts.Dtos.BrandDtos
{
    public class BrandCreateDto
    {
        public string Name { get; set; }
        public BrandTypeEnumDto Type { get; set; }
    }
}
