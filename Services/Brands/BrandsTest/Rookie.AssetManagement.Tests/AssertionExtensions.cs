using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Services.Brands.BrandsTest.Rookie.AssetManagement.Tests.Assertions;
using Services.Brands.BrandsTest.Rookie.AssetManagement.Tests.Validations;

namespace Services.Brands.BrandsTest.Rookie.AssetManagement.Tests
{
    public static class AssertionExtensions
    {
        public static ActionResultAssertions Should(this ActionResult actualValue)
            => new ActionResultAssertions(actualValue);

        public static ValidationResultAssertions Should(this ValidationResult actualValue)
            => new ValidationResultAssertions(actualValue);
    }
}
