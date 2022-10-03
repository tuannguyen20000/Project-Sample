
using Services.Brands.BrandsSPA.Rookie.AssetManagement.DataAccessor.Enums;

namespace Services.Brands.BrandsSPA.Rookie.AssetManagement.GraphQL.GraphQL.Brands
{
    public record AddBrandInput(string Name, BrandTypeEnum Type);
}