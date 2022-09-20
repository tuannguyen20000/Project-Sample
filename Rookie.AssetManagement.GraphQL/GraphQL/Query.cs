using Rookie.AssetManagement.DataAccessor.Data;
using Rookie.AssetManagement.DataAccessor.Entities;

namespace Rookie.AssetManagement.GraphQL.GraphQL
{
    public class Query
    {
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Brand> GetBrands([Service] ApplicationDbContext context)
            => context.Brands;


        [UsePaging]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Brand> GetBrandsPaging([Service] ApplicationDbContext context)
            => context.Brands.Where(x => !x.IsDeleted).AsQueryable();

    }
}
