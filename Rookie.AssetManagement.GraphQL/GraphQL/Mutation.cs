using Rookie.AssetManagement.DataAccessor.Data;
using Rookie.AssetManagement.DataAccessor.Entities;
using Rookie.AssetManagement.GraphQL.GraphQL.Brands;

namespace Rookie.AssetManagement.GraphQL.GraphQL
{
    public class Mutation
    {
        public async Task<AddBrandPayLoad> AddBrandAsync(AddBrandInput input,
             [Service] ApplicationDbContext context,
             CancellationToken cancellationToken)
        {
            var brand = new Brand
            {
                Name = input.Name,
                Type = input.Type,
            };
            context.Brands.Add(brand);
            await context.SaveChangesAsync(cancellationToken);

            return new AddBrandPayLoad(brand);
        }
    }
}
