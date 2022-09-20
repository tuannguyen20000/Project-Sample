
using Rookie.AssetManagement.DataAccessor.Enums;

namespace Rookie.AssetManagement.GraphQL.GraphQL.Brands
{
    public record AddBrandInput(string Name, BrandTypeEnum Type);
}