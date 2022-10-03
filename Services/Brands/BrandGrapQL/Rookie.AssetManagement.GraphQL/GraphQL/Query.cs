using Services.Brands.BrandsSPA.Rookie.AssetManagement.DataAccessor.Data;
using Services.Brands.BrandsSPA.Rookie.AssetManagement.DataAccessor.Entities;

namespace Services.Brands.BrandsSPA.Rookie.AssetManagement.GraphQL.GraphQL
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
