using System;
using System.Collections.Generic;
using Services.Brands.BrandsSPA.Rookie.AssetManagement.Contracts.Dtos.EnumDtos;

namespace Services.Brands.BrandsSPA.Rookie.AssetManagement.Contracts.Dtos.BrandDtos
{
    public class BrandUpdateDto
    {
        public BrandTypeEnumDto Type { get; set; }
    }
}