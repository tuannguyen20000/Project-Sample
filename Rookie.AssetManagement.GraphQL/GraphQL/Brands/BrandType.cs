using Rookie.AssetManagement.DataAccessor.Entities;

namespace Rookie.AssetManagement.GraphQL.GraphQL.Brands
{
    public class BrandType : ObjectType<Brand>
    {
        protected override void Configure(IObjectTypeDescriptor<Brand> descriptor)
        {
            descriptor.Description("Represents any software or service that has a command line interface.");
            // descriptor.Field(p => p.IsDeleted).Ignore();
        }
    }
}