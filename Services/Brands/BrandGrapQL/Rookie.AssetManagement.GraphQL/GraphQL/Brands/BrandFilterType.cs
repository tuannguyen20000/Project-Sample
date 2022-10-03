using HotChocolate.Data.Filters;
using Services.Brands.BrandsSPA.Rookie.AssetManagement.DataAccessor.Entities;

namespace Services.Brands.BrandsSPA.Rookie.AssetManagement.GraphQL.GraphQL.Brands;

public class UserFilterType : FilterInputType<Brand>
{
    protected override void Configure(
        IFilterInputTypeDescriptor<Brand> descriptor)
    {
        descriptor.BindFieldsExplicitly();
        descriptor.Field(x => x.Name).Name("brand_name");
    }
}