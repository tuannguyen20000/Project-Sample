using Services.Brands.BrandsSPA.Rookie.AssetManagement.GraphQL.GraphQL;
using Services.Brands.BrandsSPA.Rookie.AssetManagement.GraphQL.GraphQL.Brands;

namespace Services.Brands.BrandsSPA.Rookie.AssetManagement.GraphQL
{
    public static class ServiceRegisterGraphQL
    {
        public static void AddBusinessLayer(this IServiceCollection services)
        {
            services.AddGraphQLServer()
                .AddQueryType<Query>()
                .AddMutationType<Mutation>()
                .AddType<BrandType>()
                .AddProjections()
                .AddFiltering()
                .AddSorting();
        }
    }
}