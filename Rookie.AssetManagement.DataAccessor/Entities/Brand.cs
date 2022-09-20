using HotChocolate;
using Rookie.AssetManagement.DataAccessor.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace Rookie.AssetManagement.DataAccessor.Entities
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
