using AutoMapper;
using FluentAssertions;
using Services.Brands.BrandsSPA.Rookie.AssetManagement.Business;
using System;
using Xunit;

namespace Services.Brands.BrandsTest.Rookie.AssetManagement.UnitTests.Business
{
    public class AutoMapperProfileShould
    {
        [Fact]
        public void BeValid()
        {
            // Arrange
            var config = new MapperConfiguration(cfg => cfg.AddProfile<AutoMapperProfile>());
            IMapper mapper = config.CreateMapper();

            // Act
            Action act = () => mapper.ConfigurationProvider.AssertConfigurationIsValid();

            // Assert
            act.Should().NotThrow();
        }
    }
}
