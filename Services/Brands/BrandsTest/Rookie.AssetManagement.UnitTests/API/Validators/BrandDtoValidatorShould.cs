using Services.Brands.BrandsSPA.Rookie.AssetManagement.Contracts.Dtos.BrandDtos;
using Services.Brands.BrandsSPA.Rookie.AssetManagement.Validators;
using Services.Brands.BrandsTest.Rookie.AssetManagement.Tests.Validations;
using Services.Brands.BrandsTest.Rookie.AssetManagement.UnitTests.API.Validators.TestData;
using Xunit;

namespace Services.Brands.BrandsTest.Rookie.AssetManagement.UnitTests.API.Validators
{
    public class BrandDtoValidatoreShould : BaseValidatorShould
    {
        private readonly ValidationTestRunner<BrandDtoValidator, BrandDto> _testRunner;

        public BrandDtoValidatoreShould()
        {
            _testRunner = ValidationTestRunner
                .Create<BrandDtoValidator, BrandDto>(new BrandDtoValidator());
        }

        [Theory]
        [MemberData(nameof(BrandTestsData.ValidTexts), MemberType = typeof(BrandTestsData))]
        public void NotHaveErrorWhenNameIsvalid(string name) =>
            _testRunner
                .For(m => m.Name = name)
                .ShouldNotHaveErrorsFor(m => m.Name);

        [Theory]
        [MemberData(nameof(BrandTestsData.ValidIds), MemberType = typeof(BrandTestsData))]
        public void NotHaveErrorWhenIdsIsvalid(int id) =>
            _testRunner
                .For(m => m.Id = id)
                .ShouldNotHaveErrorsFor(m => m.Id);

        [Theory]
        [MemberData(nameof(BrandTestsData.InvalidIds), MemberType = typeof(BrandTestsData))]
        public void HaveErrorWhenIdsIsinvalid(int id, string errorMessage) =>
            _testRunner
                .For(m => m.Id = id)
                .ShouldHaveErrorsFor(m => m.Id, errorMessage);
    }
}
