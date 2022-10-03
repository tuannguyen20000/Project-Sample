using HotChocolate;
using Services.Brands.BrandsSPA.Rookie.AssetManagement.DataAccessor.Enums;
using System.ComponentModel.DataAnnotations;

namespace Services.Brands.BrandsSPA.Rookie.AssetManagement.DataAccessor.Entities
{
    public class Brand
    {
        public int Id { get; set; }

        [Required]
        [GraphQLNonNullType]
        [StringLength(maximumLength: 50)]
        public string Name { get; set; }

        [Required]
        [GraphQLNonNullType]
        public BrandTypeEnum Type { get; set; }

        public bool IsDeleted { get; set; }
    }
}
