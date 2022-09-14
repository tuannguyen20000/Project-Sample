using AutoMapper;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Rookie.AssetManagement.Business;
using Rookie.AssetManagement.Business.Services;
using Rookie.AssetManagement.Contracts;
using Rookie.AssetManagement.Contracts.Dtos;
using Rookie.AssetManagement.Controllers;
using Rookie.AssetManagement.DataAccessor.Data;
using Rookie.AssetManagement.DataAccessor.Entities;
using Rookie.AssetManagement.IntegrationTests.Common;
using Rookie.AssetManagement.IntegrationTests.TestData;
using Rookie.AssetManagement.Contracts.Dtos.BrandDtos;
using Rookie.AssetManagement.Tests;
using System;
using System.Threading.Tasks;
using Xunit;
using System.Threading;
using System.Collections.Generic;

namespace Rookie.AssetManagement.IntegrationTests
{
    public class AssetControllerShould : IClassFixture<SqliteInMemoryFixture>
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly BaseRepository<Brand> _brandRepository;
        private readonly IMapper _mapper;
        private readonly BrandService _brandService;
        private readonly BrandsController _brandController;

        public AssetControllerShould(SqliteInMemoryFixture fixture)
        {
            fixture.CreateDatabase();
            _dbContext = fixture.Context;
            _brandRepository = new BaseRepository<Brand>(_dbContext);
            var config = new MapperConfiguration(cfg => cfg.AddProfile<AutoMapperProfile>());
            _mapper = config.CreateMapper();

            _brandService = new BrandService(_brandRepository, _mapper);
            _brandController = new BrandsController(_brandService);
            //BrandArrangeData.InitBrandsData(_dbContext);
        }

        [Fact]
        public async Task GetBrands_Success()
        {
            //Arrange
            var BrandQueryCriteriaDto = BrandArrangeData.GetBrandQueryCriteriaDto();

            // Act
            var result = await _brandController.GetBrands(BrandQueryCriteriaDto, new CancellationToken());

            // Assert
            result.Result.Should().HaveStatusCode(StatusCodes.Status200OK);
            result.Should().NotBeNull();

            var actionResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnValue = Assert.IsType<PagedResponseModel<BrandDto>>(actionResult.Value);
            Assert.Equal(returnValue.TotalItems, 6);
        }

    }
}