using System;
using Services.Brands.BrandsSPA.Rookie.AssetManagement.Contracts.Dtos.EnumDtos;

namespace Services.Brands.BrandsSPA.Rookie.AssetManagement.Contracts.Dtos.BrandDtos
{
    public class BrandCreateDto
    {
        public string Name { get; set; }
        public BrandTypeEnumDto Type { get; set; }
    }
}
