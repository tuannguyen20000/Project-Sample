using AutoMapper;
using FluentAssertions;
using MockQueryable.Moq;
using Moq;
using Rookie.AssetManagement.Business;
using Rookie.AssetManagement.Business.Interfaces;
using Rookie.AssetManagement.Business.Services;
using Rookie.AssetManagement.Contracts;
using Rookie.AssetManagement.Contracts.Dtos;
using Rookie.AssetManagement.Contracts.Dtos.BrandDtos;
using Rookie.AssetManagement.Contracts.Dtos.EnumDtos;
using Rookie.AssetManagement.DataAccessor.Entities;
using Rookie.AssetManagement.DataAccessor.Enums;
using Rookie.AssetManagement.UnitTests.API.Validators.TestData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Xunit;

namespace Rookie.AssetManagement.UnitTests.Business
{
    /// <summary>
    /// https://codewithshadman.com/repository-pattern-csharp/
    /// https://dotnettutorials.net/lesson/generic-repository-pattern-csharp-mvc/
    /// https://fluentassertions.com/exceptions/
    /// https://stackoverflow.com/questions/37422476/moq-expression-with-constraint-it-isexpressionfunct-bool
    /// </summary>
    public class BrandServiceShould
    {
        private readonly BrandService _brandService;
        private readonly Mock<IBaseRepository<Brand>> _brandRepository;

        private readonly IMapper _mapper;

        public BrandServiceShould()
        {
            _brandRepository = new Mock<IBaseRepository<Brand>>();

            var config = new MapperConfiguration(cfg => cfg.AddProfile<AutoMapperProfile>());
            _mapper = config.CreateMapper();

            _brandService = new BrandService(
                    _brandRepository.Object,
                    _mapper
                );
        }

        [Fact]
        public async Task GetByIdAsyncShouldThrowException()
        {
            //Arrange
            var unExistedBrandId = 3;
            var brandsMock = BrandTestsData.GetBrands().AsQueryable().BuildMock();

            _brandRepository
                  .Setup(x => x.Entities)
                  .Returns(brandsMock);

            //Act 
            Func<Task> act = () => _brandService.GetByIdAsync(unExistedBrandId);

            //Assert
            NotFoundException ex = await Assert.ThrowsAsync<NotFoundException>(act);
            Assert.Contains($"Brand {unExistedBrandId} is not found", ex.Message);
        }

        [Fact]
        public async Task GetByIdAsyncShouldReturnObjectAsync()
        {
            //Arrange
            var existedBrandId = 1;
            var brandsMock = BrandTestsData.GetBrands().AsQueryable().BuildMock();

            _brandRepository
                  .Setup(x => x.Entities)
                  .Returns(brandsMock);

            //Act
            var result = await _brandService.GetByIdAsync(existedBrandId);

            //Assert
            result.Should().NotBeNull();
            _brandRepository.Verify(mock => mock.Entities, Times.Once());
        }

        [Fact]
        public async Task AddAsyncShouldThrowExceptionAsync()
        {
            Func<Task> act = async () => await _brandService.AddAsync(null);
            await act.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task AddAsyncShouldBeSuccessfullyAsync()
        {
            //Arrange
            var newBrandId = 1;
            _brandRepository
                .Setup(x => x.Add(It.IsAny<Brand>()))
                .Returns(Task.FromResult<Brand>(BrandTestsData.GetBrand(newBrandId)));

            //Act
            var result = await _brandService.AddAsync(BrandTestsData.GetCreateBrandDto());

            //Assert
            result.Should().NotBeNull();
            _brandRepository.Verify(mock => mock.Add(It.IsAny<Brand>()), Times.Once);
        }

        [Fact]
        public async Task UpdateAsyncShouldThrowNotFoundException()
        {
            //Arrange
            var brandsMock = BrandTestsData.GetBrands().AsQueryable().BuildMock();

            _brandRepository
                  .Setup(x => x.Entities)
                  .Returns(brandsMock);

            //Act
            Func<Task> act = async () => await _brandService.UpdateAsync(
                BrandTestsData.UnExistedBrandId,
                BrandTestsData.GetUpdateBrandDto()
            );

            //Assert
            await act.Should().ThrowAsync<NotFoundException>();
        }

        [Fact]
        public async Task UpdateAsyncShouldSuccess()
        {
            //Arrange
            var brandsMock = BrandTestsData.GetBrands().AsQueryable().BuildMock();

            _brandRepository
                  .Setup(x => x.Entities)
                  .Returns(brandsMock);

            _brandRepository
                .Setup(x => x.Update(It.IsAny<Brand>()))
                .Returns(Task.FromResult(BrandTestsData.GetUpdateBrand()));

            //Act
            var result = await _brandService.UpdateAsync(
                BrandTestsData.ExistedBrandId,
                BrandTestsData.GetUpdateBrandDto()
            );

            //Assert
            Assert.Equal(result.Type, (int)BrandTypeEnumDto.Luxury);
        }
    }
}
