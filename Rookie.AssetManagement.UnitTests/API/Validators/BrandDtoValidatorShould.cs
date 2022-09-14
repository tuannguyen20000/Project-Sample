using FluentAssertions;
using FluentValidation.Results;
using Moq;
using Rookie.AssetManagement.Business.Interfaces;
using Rookie.AssetManagement.Contracts.Constants;
using Rookie.AssetManagement.Contracts.Dtos;
using Rookie.AssetManagement.Contracts.Dtos.BrandDtos;
using Rookie.AssetManagement.Tests.Validations;
using Rookie.AssetManagement.UnitTests.API.Validators.TestData;
using Rookie.AssetManagement.Validators;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Rookie.AssetManagement.UnitTests.API.Validators
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
