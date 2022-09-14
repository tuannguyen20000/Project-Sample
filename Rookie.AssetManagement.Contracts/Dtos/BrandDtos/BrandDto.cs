using System.Collections.Generic;
using System;
using Rookie.AssetManagement.Contracts.Dtos.EnumDtos;

namespace Rookie.AssetManagement.Contracts.Dtos.BrandDtos
{
    public class BrandDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Type { get; set; }
    }
}
